using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MoreLinq;

namespace EventFlow.Mongo
{
	partial class Program
	{
		static void Main(string[] args)
		{
			// connect mongo
			var client = new MongoClient(
				"mongodb://blumenkraft:vdNDU8F4LxJTsjGJ@iceis.blumenkraft.me:27017"
				//"mongodb://localhost:27017"
			);
			var database = client.GetDatabase("IceIS-Prod-01");		
		
			//DeleteTailEventsWithWrongSequenceNumber(database);
			
//			GenerateMapAutoCats(database, "Tool");
//			GenerateMapAutoCats(database, "Supply");
			
//			RenderEnsuringCommandsSourceAndToolIds(database, "Tool", ToolsMap());
//			RenderEnsuringCommandsSourceAndToolIds(database, "Supply", SuppliesMap());
//
			PatchEvents(database, "Tool", ToolsMap(), "toolsku-22c8ea4a-d3e6-42a6-ae6b-e93866b6cd8e");
			PatchEvents(database, "Supply", SuppliesMap(), "supplysku-3e847eb7-fbdc-4dab-aeb3-0d316086d58b");
		}

		private static void PatchEvents(IMongoDatabase database, string type, Dictionary<string, string> catToSkuMap,
			string defaultSkuId)
		{
			var collection = database.GetCollection<BsonDocument>("eventflow.events");
			var events = collection.Find(new BsonDocument()).ToList();

			var adjustments = events.Where(e => e["Data"].AsString.Contains($"{type}ClaimAdjustmentUpdated")).ToArray();
			var claims = events.Where(e => e["Data"].AsString.Contains($"{type}ClaimUpdated")).ToArray();

			string FixAdjustmentData(string data)
			{
				var claimRegex = new Regex(
					$@"""Adjustment"":{{""Category"":""(?<cat>{type.ToLowerInvariant()}category-[-\w\d]+)"""
				);

				return claimRegex.Replace(data, m => $@"""Adjustment"":{{""SkuId"":""{SkuFor(m.Groups["cat"].Value)}""");
			}
			
			
			string FixClaimData(string data)
			{
				var claimRegex = new Regex(
					$@"""Claim"":{{""Category"":""(?<cat>{type.ToLowerInvariant()}category-[-\w\d]+)"""
				);

				return claimRegex.Replace(data, m => $@"""Claim"":{{""RequestedSku"":""{SkuFor(m.Groups["cat"].Value)}""");
			}

			string SkuFor(string catId)
			{
				if (catToSkuMap.ContainsKey(catId))
					return catToSkuMap[catId];
				else
				{
					Console.WriteLine("No sku for " + catId);
					return defaultSkuId;
				}
			}

			foreach (var e in adjustments)
			{
//				Console.WriteLine();
//				Console.WriteLine(e["Data"].AsString);
//				Console.WriteLine("→");
//				Console.WriteLine(FixAdjustmentData(e["Data"].AsString));

				var filterDefinition = new BsonDocument("_id", e["_id"].AsInt64);

				var res = e.Set("Data", FixAdjustmentData(e["Data"].AsString));
				
				Console.WriteLine(collection.ReplaceOne(
					filterDefinition, res
				).ModifiedCount);
				
			}

			foreach (var e in claims)
			{
//				Console.WriteLine();
//				Console.WriteLine(e["Data"].AsString);
//				Console.WriteLine("→");
//				Console.WriteLine(FixClaimData(e["Data"].AsString));

				var filterDefinition = new BsonDocument("_id", e["_id"].AsInt64);
				
				var res = e.Set("Data", FixClaimData(e["Data"].AsString));
				
				Console.WriteLine(collection.ReplaceOne(
					filterDefinition, res
				).ModifiedCount);

			}
		}
	}
}