using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EventFlow.Mongo
{
	partial class Program
	{
		private static Dictionary<string, string> ToolsMap()
		{
			var map = new Dictionary<string, string>
			{
				{
					"toolcategory-00000000-0000-0000-0000-000000000037", "toolsku-3e89d8f8-140c-414a-ab01-0bc7d4beed28"
				}, // Бахилы:  Озк бахилы
				{
					"toolcategory-00000000-0000-0000-0000-000000000020", "toolsku-77d6bf53-b7ca-4c6d-8a06-e9bd710ebc25"
				}, // Чайник: Чайник Indesit

				{
					"toolcategory-00000000-0000-0000-0000-000000000003", "toolsku-d67137e0-64f7-4876-8fe2-e35ff403b1c8"
				}, // Вспомогательная пила: Stihl MS 361

// → toolsku-3e8ea8cb-edc9-42f1-811a-44f48228196d Stihl MS 290

// → toolsku-a404c3a4-0e22-45a2-a417-eadb6cc1301e Stihl MS 230

// → toolsku-d67137e0-64f7-4876-8fe2-e35ff403b1c8 Stihl MS 361

				{
					"toolcategory-00000000-0000-0000-0000-000000000022", "toolsku-2e9bf32b-0324-4335-8f48-97c2b9fd0a15"
				}, // Ведро: Ведро 12 л

// → toolsku-2e9bf32b-0324-4335-8f48-97c2b9fd0a15 Ведро 12 л

// → toolsku-d3da7cd2-c38f-4090-8e03-9b21c4a5d5d8 Лейка

				{
					"toolcategory-00000000-0000-0000-0000-000000000011", "toolsku-38d214bd-3d44-42b4-ad6c-752e60bc11fa"
				}, // Заточной для стамесок: Заточной станок для стамесок

// → toolsku-38d214bd-3d44-42b4-ad6c-752e60bc11fa Заточной станок для стамесок

// → toolsku-d6210cd3-56c3-462d-af8e-fb0b26c2a8f9 

				{
					"toolcategory-00000000-0000-0000-0000-000000000013", "toolsku-cf96a6e8-d214-45b5-ac36-3e37a08754b8"
				}, // Заточной для цепей: Заточной станок для цепей

				{
					"toolcategory-00000000-0000-0000-0000-000000000034", "toolsku-d00e9a4c-fa2c-4db3-a5f3-2421903fad67"
				}, // Канистра 10 л: Канистра 10 л

				{
					"toolcategory-00000000-0000-0000-0000-000000000033", "toolsku-a5c34f9e-d35c-45a9-a5dd-4f463361f186"
				}, // Канистра 20 л: Канистра 20 л

				{
					"toolcategory-00000000-0000-0000-0000-000000000030", "toolsku-f456a9a4-f3de-4b47-9af4-235d8b767cbd"
				}, // Клепальный станок: Станок клепальный для цепей

// → toolsku-f456a9a4-f3de-4b47-9af4-235d8b767cbd Станок клепальный для цепей

// → toolsku-0dce7594-26bc-4251-a379-92c8a0319171 

				{
					"toolcategory-00000000-0000-0000-0000-000000000032", "toolsku-c769b50f-ad8b-4fb6-b01e-c40e7c77c782"
				}, // Ковш: Ковш строительный круглый

// → toolsku-6a963f0c-282c-4c7c-b262-22c936211849 Ковш металлический

// → toolsku-c769b50f-ad8b-4fb6-b01e-c40e7c77c782 Ковш строительный круглый

				{
					"toolcategory-00000000-0000-0000-0000-000000000046", "toolsku-b1075d88-f8e6-49a4-bbcf-46e57c4e066b"
				}, // Лом строительный D25 L 1300

// → toolsku-0fa9cfcc-a75a-40ae-8e76-ec1d43760222 Лом 

// → toolsku-1c9f1047-9074-4b32-839a-dad826e814b7 Лом-гвоздодёр

// → toolsku-eaaf2c9c-c82d-4afe-a2c5-b325b2e18f99 Ледокол

// → toolsku-b1075d88-f8e6-49a4-bbcf-46e57c4e066b Лом строительный D25 L 1300

				{
					"toolcategory-00000000-0000-0000-0000-000000000029", "toolsku-75c5abf2-44a7-4c67-927c-813f5d656846"
				}, // Лопата совковая без черенка

// → toolsku-37d2a1a8-9061-4e60-a1b6-36abeb35c280 Лопата снежная пластиковая

// → toolsku-33ea5707-cd45-489a-911d-3e578eed89be Лопата снежная металлическая

// → toolsku-1d5bcd41-1f28-4cdf-ad7d-f2125f0ebc93 Лопата ластиковая без черенка

// → toolsku-c30ded14-a30c-4710-82b2-52c92355eeb4 Лопата штыковая без черенка

// → toolsku-75c5abf2-44a7-4c67-927c-813f5d656846 Лопата совковая без черенка

				{
					"toolcategory-00000000-0000-0000-0000-000000000024", "toolsku-8ab8a99f-1e43-4d1b-ad84-a24fde5c3306"
				}, // Налобный фонарь: Налобный фонарь

				{
					"toolcategory-00000000-0000-0000-0000-000000000041", "toolsku-75b3b991-4966-499b-a9a5-02d93c6cba7e"
				}, // Плоская отвёртка: Плоская отвёртка

				{
					"toolcategory-00000000-0000-0000-0000-000000000025", "toolsku-9cd91301-44a7-4a3b-8961-f2433f45cce9"
				}, // Рулетка 5м

// → toolsku-e69d80c6-f984-4d60-9ef0-5c9ff58d264f Рулетка 3м

// → toolsku-9cd91301-44a7-4a3b-8961-f2433f45cce9 Рулетка 5м

// → toolsku-05b06fed-fd9f-4811-b169-67936630a619 Рулетка 8м

				{
					"toolcategory-00000000-0000-0000-0000-000000000017", "toolsku-6d1dedec-efa8-45c0-b082-8a43dce9c37d"
				}, // Ручной фрезер: Ручной фрейзер 

				{
					"toolcategory-00000000-0000-0000-0000-000000000026", "toolsku-5eb33a7b-4446-453b-8db0-ab3e7745b51b"
				}, // Стамеска-зубило: Стамеска-зубило

				{
					"toolcategory-00000000-0000-0000-0000-000000000028", "toolsku-71ffc138-da44-47a8-9010-f2c808a0acec"
				}, // Стамеска-лопатка: Стамеска плоская

				{
					"toolcategory-00000000-0000-0000-0000-000000000027", "toolsku-946578a4-1227-4ceb-9e0c-c27cf3fdec63"
				}, // Стамеска-уголок: Стамеска уголок

				{
					"toolcategory-00000000-0000-0000-0000-000000000019", "toolsku-130630cd-668d-4cfa-a18f-b7ecc5baef6b"
				}, // Строительный фен: Строительный фен

				{
					"toolcategory-00000000-0000-0000-0000-000000000039", "toolsku-c81b5abc-ae27-4c81-9b98-d05a680cbe40"
				}, // Строп текстильный СТП -3,0/5,0

// → toolsku-c81b5abc-ae27-4c81-9b98-d05a680cbe40 Строп текстильный СТП -3,0/5,0

// → toolsku-5fc3e62a-9c46-4630-bab3-da1883ee0442 Ремень стяжной кольцевой 4,0/8,0 т 2,5/5,0 м( лента 50 мм)

				{
					"toolcategory-00000000-0000-0000-0000-000000000014", "toolsku-0572db9b-9fe4-4b36-be28-1e6dab4d544b"
				}, // Тепловентилятор элек. спиральный BH-2000

// → toolsku-41b2a66d-a410-408b-9b30-ca4f73684694 Теплопушка

// → toolsku-0572db9b-9fe4-4b36-be28-1e6dab4d544b Тепловентилятор элек. спиральный BH-2000

// → toolsku-f96c0950-f7ce-4eea-8f78-dc68ad3cdb8d Масленый обогреватель

				{
					"toolcategory-00000000-0000-0000-0000-000000000021", "toolsku-c570508d-5278-47ea-bbf4-87c5df881850"
				}, // Шкуродёр малый

// → toolsku-53192fba-7c9f-4098-8c09-a41d64ab0009 Шкуродёр большой

// → toolsku-c570508d-5278-47ea-bbf4-87c5df881850 Шкуродёр малый

				{
					"toolcategory-00000000-0000-0000-0000-000000000047", "toolsku-758b7481-069b-4ed9-92fe-84fd16d6ec66"
				}, // Удлинитель 50м

// → toolsku-758b7481-069b-4ed9-92fe-84fd16d6ec66 Удлинитель 50м

// → toolsku-01dc1dd6-ef10-4d90-80f4-01cfbd764cb7 Удлинитель 25м

// → toolsku-14ac6a9f-1e2c-4c25-9dd3-8f0a4e0aa6e6 Удлинитель 20м

// → toolsku-e69cd66d-a883-4c1b-a275-4f1e9d91cc8c Удлинитель 3м

				{
					"toolcategory-00000000-0000-0000-0000-000000000035", "toolsku-6206dcd5-3471-4a6d-8d3e-9ebcc46eb014"
				}, // Шубенки: Шубенки

				{
					"toolcategory-00000000-0000-0000-0000-000000000016", "toolsku-3c64dca3-cf7a-487c-8875-958c6050b339"
				}, // Шуруповёрт: Шуруповёрт Makitta

				{
					"toolcategory-00000000-0000-0000-0000-000000000044", "toolsku-f4377469-346f-4511-a0b0-88d81b7ed4e9"
				}, // Плоскогубцы

// → toolsku-f4377469-346f-4511-a0b0-88d81b7ed4e9 Плоскогубцы

// → toolsku-72fb3d77-fda6-4c19-b2b3-7087cccc042e Круглогубцы

				{
					"toolcategory-00000000-0000-0000-0000-000000000036", "toolsku-fdb2524b-2740-444a-b6cf-7a41e5c59307"
				}, // Резиновые перчатки: Перчатки хлопок ПВХ Пламя длина 30 см разм.11 арт. 31-6-22

				{
					"toolcategory-00000000-0000-0000-0000-000000000004", "toolsku-a2097b25-4948-4f77-9267-f7a4341b89c7"
				}, // Малая пила: Stihl MS 180

				{
					"toolcategory-00000000-0000-0000-0000-000000000023", "toolsku-1e3f99f8-a37a-431d-9b5f-9574921e684f"
				}, // Уровень 80см

// → toolsku-73242409-ccef-4ec6-8012-c5f2bf98ae3d Уровень 60см

// → toolsku-f42bd7bb-da01-4a2f-900e-1b17a2cdac11 Уровень 40см

// → toolsku-1e3f99f8-a37a-431d-9b5f-9574921e684f Уровень 80см

// → toolsku-b56ed417-002a-4131-bcb4-ce0a2ea8ce78 Уровень 90см

// → toolsku-e1657883-3870-4421-bef5-5eeddc383b99 Уровень 100см

// → toolsku-d7bf3bf8-5efa-46e8-bcec-2fe5b997733f Уровень 120см

// → toolsku-491e03ca-1685-4ebe-9086-8c940a6beffc Уровень 150см

				{
					"toolcategory-00000000-0000-0000-0000-000000000040", "toolsku-b2024b73-833b-4da1-8287-3043afc194fd"
				}, // Ключ М8: Ключ М8 STIHL

				{
					"toolcategory-00000000-0000-0000-0000-000000000042", "toolsku-c4375be8-ac35-4c04-9024-499a6b79aca6"
				}, // Ключ TORX 27x150мм. Stihl Т-образный

// → toolsku-c4375be8-ac35-4c04-9024-499a6b79aca6 Ключ TORX 27x150мм. Stihl Т-образный

// → toolsku-69849c24-7b6f-42ce-8fad-ec4dc13732d1 Ключ комбинорованный звезда железный 

				{
					"toolcategory-00000000-0000-0000-0000-000000000010", "toolsku-b8eab858-6a09-46bd-952b-407096efea3c"
				}, // Цепь STIHL 40см (63 PS 55)

// → toolsku-e8b8b0bb-b86c-4198-9c15-ab00e8713650 Цепь STIHL 35см

// → toolsku-b8eab858-6a09-46bd-952b-407096efea3c Цепь STIHL 40см (63 PS 55)

				{
					"toolcategory-00000000-0000-0000-0000-000000000002", "toolsku-d862a13c-17f2-48d4-9850-fd37c3c6b756"
				}, // Пила Stihl MS 660

// → toolsku-13437695-e40f-4bc5-b3b3-48ab53d097d0 Пила STIHL MS 440

// → toolsku-d862a13c-17f2-48d4-9850-fd37c3c6b756 Пила Stihl MS 660

// → toolsku-29f9d6b4-87c5-44ab-83c9-68762b670a2e Пила Shtil MS 462 

				{
					"toolcategory-00000000-0000-0000-0000-000000000008", "toolsku-5f819ffd-77f1-4031-b107-c1c09a53e993"
				}, // Цепь STIHL 63 см (36 84 RSC)

// → toolsku-5f819ffd-77f1-4031-b107-c1c09a53e993 Цепь STIHL 63 см (36 84 RSC)

// → toolsku-d862e53f-5103-48cb-b62b-22561fde604f Цепь STIHL 90см (36 RSC 114)

				{
					"toolcategory-00000000-0000-0000-0000-000000000009", "toolsku-40493e25-9d74-478f-8900-1e3901c4d4f0"
				}, // !!! Цепь вспомогательной пилы: ??? Цепь STIHL 45см

// → toolsku-40493e25-9d74-478f-8900-1e3901c4d4f0 Цепь STIHL 45см

// → toolsku-bc5926d5-e5dc-4e71-9450-70aa3fb59c47 Цепь  STIHL 50см

// → toolsku-07d0263b-f22a-49b2-906f-000401fb4152 Цепь  STIHL 70см

// → toolsku-4778cfbf-e26a-4c16-9088-0031acd97c5d Цепь STIHL 75см (36 98 RSC)

				{
					"toolcategory-00000000-0000-0000-0000-000000000038", "toolsku-4fe9bd7e-c381-4879-af8f-b7b94b5244b3"
				}, // Плащ: Озк плащ

				{
					"toolcategory-00000000-0000-0000-0000-000000000007", "toolsku-81f071a7-d6d1-4ef8-9cc1-b6dd540a5882"
				}, // !!! Шина малой пилы: ??? Шина STIHL 40см 1,3 3/8 55зв

// → toolsku-81f071a7-d6d1-4ef8-9cc1-b6dd540a5882 Шина STIHL 40см 1,3 3/8 55зв

// → toolsku-e1d6f9c2-6d29-40be-a75c-7dcf9a417654 Шина STIHL 35см

				{
					"toolcategory-00000000-0000-0000-0000-000000000005", "toolsku-510d14ba-26ea-4fb6-8dd1-664be8dd290a"
				}, // Шина основной пилы: Шина STIHL 25(63см) 1.6 3/8 84 зв

				{
					"toolcategory-00000000-0000-0000-0000-000000000006", "toolsku-579349e7-6173-4fcb-86e2-a6ee75475035"
				}, // Шина STIHL 60см

// → toolsku-091bc87a-d237-49a4-b14a-c9d5b98ed397 Шина STIHL 90см

// → toolsku-62288116-3c21-4950-ae1a-9939a3ce5e88 Шина STIHL 75см

// → toolsku-3f8c069b-c982-4e1d-851d-a73bbf393d0b Шина STIHL 45см

// → toolsku-229b6404-9135-42b4-9fa1-41188cff89ef Шина STIHL 50см

// → toolsku-beb25e87-9837-4370-9256-db7f0a5f05fa Шина REZER 40см

// → toolsku-cd8d4a52-cc6e-4277-87dc-68748a47cfc0 Шина HITACHI 40см

// → toolsku-a5d2a7f2-954d-4bf3-9ce5-df329bf95ae1 Шина HUSQVARNA 40см

// → toolsku-5a4bf86f-7868-4fdd-9809-3179f99fab49 Шина HUSQVARNA 65см

// → toolsku-d1c9c8d1-e76b-40c7-951a-d7a9a150a6df Шина MAKITA 40см

// → toolsku-47c379d1-a541-45d3-bd8d-03e3d46e63fe Шина MAKITA 45см

// → toolsku-579349e7-6173-4fcb-86e2-a6ee75475035 Шина STIHL 60см


				{
					"toolcategory-00000000-0000-0000-0000-000000000031", "toolsku-8c49eaaf-2ab4-4e59-9b5f-fdd578903d74"
				}, // Расклепальный станок: Станок расклепочный

				{
					"toolcategory-00000000-0000-0000-0000-000000000001", "toolsku-22c8ea4a-d3e6-42a6-ae6b-e93866b6cd8e"
				}, // Станок для добычи HONDA GX 270 

// → toolsku-093934f2-2584-45d5-8d9b-bb7d1921e2d5 Станок для добычи SUBARU

// → toolsku-22c8ea4a-d3e6-42a6-ae6b-e93866b6cd8e Станок для добычи HONDA GX 270 

				{
					"toolcategory-00000000-0000-0000-0000-000000000012", "toolsku-4da084cd-f0b9-44fa-8d84-9f4cdf498aad"
				}, // Шлифовальный для стамесок: Ленточно-шлифовальный станок для стамесок

				{
					"toolcategory-00000000-0000-0000-0000-000000000018", "toolsku-9e1d9dd2-29e7-4c7c-bbf8-bb1f940e91a6"
				}, // Фреза: Набор фрез

				{
					"toolcategory-00000000-0000-0000-0000-000000000045", "toolsku-c9fa674e-f54f-44bb-929f-ce6dc8a3e6ad"
				}, // Маркер: Маркер

				{
					"toolcategory-00000000-0000-0000-0000-000000000015", "toolsku-9eaa3eab-ba6f-4eb5-b687-bb9268c8ff1e"
				}, // Уличное освещение: Уличное освещение

				{
					"toolcategory-00000000-0000-0000-0000-000000000043", "toolsku-8a277fc0-d174-4f82-9215-eca516a7de9a"
				}, // Ключ M8 длинный: Ключ M8 длинный
				
				
				
				/////////// manual cats

				
        { "toolcategory-8a3d16f0-13f3-4a28-bf54-30de46af81b7", "toolsku-d673bc6e-5cb2-490e-808e-f944ec289748" }, // Фигурная отвёртка: Фигурная отвёртка

        { "toolcategory-8280f67b-b4c9-4df0-a178-ecd3bf33baa6", "toolsku-ca69af6c-6a7f-4e21-a97c-b1c182619972" }, // Отвёртка универсальная: Отвёртка универсальная

        { "toolcategory-ad2d4f17-1485-494f-b674-d56734aea040", "toolsku-f2dfd69b-f978-48e8-aebb-7d5341c177d6" }, // Молоток: Молоток

        { "toolcategory-dd1e714f-4226-4a7c-8485-0808451a6362", "toolsku-fb8a5783-c3b2-4895-a912-d2cd3ea3af29" }, // Топор: Топор

        { "toolcategory-adde5c9c-7cd8-42ee-b063-461efda80fd7", "toolsku-631de4a5-d57c-4325-94cb-f60f2e48cb63" }, // Перфоратор: Перфоратор Makitta

        { "toolcategory-17b980a5-7701-4e52-8656-bc36cb128b4f", "toolsku-717c4f91-e5c2-48f2-8954-171c5cf68906" }, // Дрель: Дрель

        { "toolcategory-8f8f5518-8aac-418f-8d7d-a63f3ca31bb4", "toolsku-01813fc2-b182-4a05-9feb-842fab8b10c0" }, // Торцовочная ручная пила: Торцовочная ручная пила

        { "toolcategory-b2b9bf7e-6a9c-4726-9d9b-38d3425e1623", "toolsku-90026ed1-17c2-426d-9446-6a2330e18783" }, // Болгарка: Болгарка

        { "toolcategory-115a698b-5265-4ca5-872e-49c88332c5af", "toolsku-60275110-a2ef-4724-ac20-130d380c7274" }, // Ключ M10: Ключ комбинированный STIHL 160 мм (13/19)

        { "toolcategory-a5991fcf-b57b-4cd2-87d5-13eae9714ae8", "toolsku-94b4e915-84b5-4986-974b-bb8c36f34193" }, // Трубчатый ключ: Трубчатый ключ (свечной)

        { "toolcategory-c5b74695-c9da-48f4-acb4-52a75bf8cfc2", "toolsku-9e717067-fadb-40a5-9600-cd31402330c1" }, // Ручная циркулярная пила: Циркулярка ручная (лягушка)

        { "toolcategory-562daf52-837d-40be-b67b-ca7cd9d4a7de", "toolsku-b18cf184-a0f8-47b5-b4d2-c4d1cb3d673b" }, // !!! Набор торцевых головок: ??? Набор торцевых головок

// → toolsku-b18cf184-a0f8-47b5-b4d2-c4d1cb3d673b Набор торцевых головок

// → toolsku-1254d595-3d7b-4f3f-86ea-0078aa30c050 Набор ключей шестигранных

        { "toolcategory-a94f2bc5-23dc-44f9-bd14-75c4e2cc7d18", "toolsku-43bac492-8ba1-46d9-b373-3dbf53fa424e" }, // !!! Щипцы для зачистки изоляции: ??? Щипцы для зачистки изоляции GROSS 17718

// → toolsku-43bac492-8ba1-46d9-b373-3dbf53fa424e Щипцы для зачистки изоляции GROSS 17718

// → toolsku-fc3c813a-74b7-4fd8-a900-817ddd11272b Щипцы для зачистки изоляции

        { "toolcategory-63a6fbc4-bea4-4d60-8fa1-4f9585fb9973", "toolsku-209e1a95-29df-49b2-a2ed-3de6b85d84ac" }, // Щётка по металлу: Щётка по металлу

        { "toolcategory-89606655-1559-43c4-84ae-b183c64e5850", "toolsku-5b30bb2f-aaf0-4653-8a14-8d7921844c1c" }, // Шпатели : Шпатель 

        { "toolcategory-693d3489-5084-49e3-904e-9e535e59a69f", "toolsku-f16e3fbd-9634-4682-adee-4dc9d2c723e5" }, // Стамеска по дереву: Стамеска по дереву

        { "toolcategory-60e281cc-bff9-434c-bea3-55035620abd3", "toolsku-7eaf285d-52a3-497f-be04-07cf498ea397" }, // Напильник : Напильник

        { "toolcategory-717d2ac7-cb74-4243-8139-2b1b45f3d6fb", "toolsku-a67d7265-1eea-4459-8bc7-2bb7d0268885" }, // Пила нож: Пила нож

        { "toolcategory-b3346d4c-22fc-42df-ab35-ba709b3003aa", "toolsku-741552d6-e1c4-4cb1-b350-53c10d341308" }, // !!! Электропила: ??? Электропила Stihl 

// → toolsku-741552d6-e1c4-4cb1-b350-53c10d341308 Электропила Stihl 

// → toolsku-46ea019e-4118-44e7-96e7-34bbc0f4ddba Электропила Makita

        { "toolcategory-18206167-e7e1-4a4c-a5d8-52101690db26", "toolsku-ac8b234c-7835-4290-8b7e-fe6cd5c74d76" }, // Микроволновая печь: Микроволновая печь SUMSUNG

        { "toolcategory-98d6d512-74cd-4681-a43e-d95073977940", "toolsku-5feb85b1-6cb6-4ff2-899f-4e87b9505e9b" }, // Лазерный уровень: Лазерный уровень

        { "toolcategory-c5b5298d-e92a-48c5-a01e-1f713fb7b1a3", "toolsku-6de2e50a-3276-475b-a0d0-b09070daeb91" }, // Воронки: Воронка пластиковая

        { "toolcategory-5b6897b3-b770-4566-9008-fdf83775d7c0", "toolsku-892bfdbd-5d89-4a91-a95d-207947d594d3" }, // Бочка : Бочка для воды 

        { "toolcategory-8cb08681-bfac-4676-967a-31f841ec2346", "toolsku-1df64ea6-ac2c-4717-95c1-3d84cb2a53aa" }, // Щипцы для льда: Щипцы для льда

        { "toolcategory-dd54b017-492f-44cc-9ed6-b15bca02f97a", "toolsku-c690feac-b60c-4f16-b033-678377ee1501" }, // !!! Бензогенератор: ???  Бензиновый генератор elitech бэс 2500Р 

// → toolsku-c690feac-b60c-4f16-b033-678377ee1501  Бензиновый генератор elitech бэс 2500Р 

// → toolsku-29820a2b-3b62-4c8a-9fe1-aca43176c920 Бензиновый генератор Fubag TI 2600

        { "toolcategory-1b1a40fe-44a9-4bd4-b811-81d6c4e37e5a", "toolsku-7b553176-c3fc-459b-b53e-e10ea7bdc7a5" }, // Лебедка ручная: Лебёдка ручная 1,5т

        { "toolcategory-b13b1d65-35f6-4e77-86e6-48ba6704cf1c", "toolsku-32b36467-b9d6-49e2-a514-2baacb56e91d" }, // Сварочный аппарат: Сварочный аппарат

        { "toolcategory-b588a43f-a011-444f-9dec-207c0c5e7956", "toolsku-d59c8328-8611-4ce6-978d-06e87fee7e81" }, // Маска для сварки: Маска для сварки

        { "toolcategory-f5817f1d-14c5-4aa6-a2c7-4fffa467ad9a", "toolsku-716e3684-aa96-4f7f-b142-d9db8a51921c" }, // Паяльная лампа: Паяльная лампа

        { "toolcategory-ba405fbf-e638-40e7-9859-01895f349844", "toolsku-53e012a2-e851-4442-9ba5-2a1c0ba40f46" }, // Компрессор: Компрессор

        { "toolcategory-c612deda-c692-402b-9756-bfbb89c0dc9f", "toolsku-e9656312-fcfe-4d1d-94be-1fa6734b0934" }, // Канистра 5л: Канистра 5л

        { "toolcategory-fbabc972-5470-4ee6-8c33-6693c498fe60", "toolsku-4c066d65-6734-4658-99d0-92f3cb152f20" }, // !!! Ключи разводной: ??? Ключ шестигранный 17*19

// → toolsku-4c066d65-6734-4658-99d0-92f3cb152f20 Ключ шестигранный 17*19

// → toolsku-413acf69-d309-439a-b3b7-1876450de487 Ключ разводной 

        { "toolcategory-e256db4b-5102-43b8-b023-350a520cef3e", "toolsku-7880df12-a5be-4d35-8639-77840e0716a1" }, // Страховочный ремень для высотных работ: Страховочный ремень для высотных работ

        { "toolcategory-c59f40ad-64b5-4868-ab25-c72c788254f9", "toolsku-20fe1988-5dc3-4dbe-a226-caf16631c667" }, // Набор ключей: Набор накидных ключей

        { "toolcategory-e93d649f-ce24-41eb-8008-8da281373112", "toolsku-5bde6d7a-09d3-47f8-9d19-1ddac24cdcb9" }, // Багор для выемки льда: Богор для выемки льда

        { "toolcategory-51c34023-cf4a-4541-9e86-e0a16a6418ee", "toolsku-66a735b1-ce80-4aba-82f7-2daac1b0f89b" }, // Отвертка для карбюратора: Отвертка для карбюратора

        { "toolcategory-811fb66b-77c6-4d66-b3f7-a5d000f1fdc5", "toolsku-24263094-b4a9-4873-87c9-0c20f6185473" }, // ОЗК Куртки: ОЗК Куртки

        { "toolcategory-9a6b2fb0-d105-4b93-b9bf-15228f3e9320", "toolsku-07201513-b294-4d74-bb88-c068a5e5d8b8" }, // Розетки резиновые каучуковые: Розетка двойная каучуковая с заглушкой арт. 106-0400-0110/110

        { "toolcategory-93f70e27-65bd-4b1d-851d-238fc2dfe205", "toolsku-bd7f3cd1-3a70-40cf-bca7-4d32cdf6657d" }, // Вилка влагозащищенная : Вилка влагозащищенная с заземл. контактом каучук

        { "toolcategory-e54f63bd-c42a-4086-9726-f5b2c719923a", "toolsku-f82f2969-d798-4dd1-91b9-1f1675345235" }, // Ключ шестигранный: Ключ шестигранный


			};
			return map;
		}



		private static void GenerateMapAutoCats(IMongoDatabase database, string type)
		{
			var toolCats = database
				.GetCollection<BsonDocument>($"eventflow-{type.ToLowerInvariant()}categoryreadmodel")
				.Find(new BsonDocument())
				.ToList()
				.Select(x => new
				{
					Id = x["_id"].AsString,
					Version = x["Version"].AsInt64,
					Name = x["Name"].AsString,
					Group = x["Group"].AsString,
					IsAuto = x["_id"].AsString.StartsWith($"{type.ToLowerInvariant()}category-00000000-0000-0000-0000")
				})
				.ToArray();

			var toolSkus = database
				.GetCollection<BsonDocument>($"eventflow-{type.ToLowerInvariant()}skureadmodel")
				.Find(new BsonDocument())
				.ToList();

			var toolsBycats = toolSkus
				.GroupBy(e => e["Category"])
				.Select(g => new
				{
					Category = toolCats.First(x => x.Id == g.Key),
					Skus = g
						.Select(x => new {Id = x["_id"], Version = x["Version"], Name = x["Name"]})
						.ToArray()
				})
				.ToArray();

			var emptyCats = toolCats.Except(toolsBycats.Select(c => c.Category)).ToArray();

			Console.WriteLine("var map = new Dictionary<string, string> {");

			foreach (var cat in toolsBycats.Where(x => !x.Category.IsAuto))
			{
				if (cat.Skus.Length == 0)
				{
					//Console.WriteLine($"\t{{ \"{cat.Category.Id}\", \"!!!\" }}, // {cat.Category.Name}: __NO SKU__\n");
				}
				else if (cat.Skus.Length == 1)
				{
					Console.WriteLine(
						$"\t{{ \"{cat.Category.Id}\", \"{cat.Skus.Single().Id}\" }}, // {cat.Category.Name}: {cat.Skus.Single().Name}\n");
				}
				else
				{
					Console.WriteLine(
						$"\t{{ \"{cat.Category.Id}\", \"{cat.Skus.First().Id}\" }}, // !!! {cat.Category.Name}: ??? {cat.Skus.First().Name}\n");
					foreach (var sku in cat.Skus)
					{
						Console.WriteLine($"// → {sku.Id} {sku.Name}\n");
					}
				}
			}

			foreach (var cat in emptyCats)
			{
			//	Console.WriteLine($"\t{{ \"{cat.Id}\", \"!!!\" }}, // {cat.Name}: __NO SKU__\n");

			}

			Console.WriteLine("};");
		}
	}
}