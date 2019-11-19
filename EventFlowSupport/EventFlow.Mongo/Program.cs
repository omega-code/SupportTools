using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MoreLinq;

namespace EventFlow.Mongo
{
	class Program
	{
		static void Main(string[] args)
		{
			// connect mongo
			var client = new MongoClient(
				"mongodb://blumenkraft:vdNDU8F4LxJTsjGJ@iceis.blumenkraft.me:27017"
			);
			var database = client.GetDatabase("IceIS-Prod-01");
			
			
			// load all events
			var collection = database.GetCollection<BsonDocument>("eventflow.events");
			var events = collection.Find(new BsonDocument()).ToList();
		
			// group by agg id
			var aggregates = events
				.GroupBy(e => e["AggregateId"])
				.Select(g => new
				{
					AggregateId = g.Key, 
					Events = g.ToArray()
				})
				.Select(a => new
					{
						a.AggregateId, 
						Events = a.Events
							.GroupBy(e => e["AggregateSequenceNumber"])
							.Select(g => new
							{
								AggregateSequenceNumber = g.Key, 
								Events = g.ToArray()
							})
							.ToArray()
					}
				)
				.Select(a => new
					{
						a.AggregateId, 
						a.Events,
						BadEvents = a.Events
							.Where(e => e.Events.Length > 1)
							.SelectMany(e => e.Events.Skip(1))
							.ToArray()
					}
				)
				.ToArray();

			var badAggregates = aggregates
				.Where(a => a.BadEvents.Any())
				.ToArray();
			
			Console.WriteLine($"Bad: {badAggregates.Length}");

			badAggregates.ForEach(a => Console.WriteLine($"{a.AggregateId}: {a.BadEvents.Length}"));

			var badEvents = badAggregates.SelectMany(b => b.BadEvents).ToArray();
			badEvents.ForEach(Console.WriteLine);
			Console.WriteLine("Плохих событий:");
			Console.WriteLine(badEvents.Length);

			//  delete extra
			badEvents
				.Select(be => be["_id"])
				.Select(id => Builders<BsonDocument>.Filter.Eq("_id", id))
				.ForEach(f => collection.DeleteOne(f));
			
			// repeat again check no logging
			
			//Console.WriteLine(aggregates.Length);
		}
	}
}