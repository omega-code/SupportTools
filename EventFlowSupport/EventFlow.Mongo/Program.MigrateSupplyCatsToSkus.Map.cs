using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EventFlow.Mongo
{
	partial class Program
	{
		private static Dictionary<string, string> SuppliesMap()
		{
			var map = new Dictionary<string, string>
			{
				{
					"supplycategory-00000000-0000-0000-0000-000000000032",
					"supplysku-77d503fa-e62e-43e1-82e7-5001f4880009"
				}, // Болт глушителя малой пилы: Болт глушителя STIHL MS 180

				{
					"supplycategory-00000000-0000-0000-0000-000000000017",
					"supplysku-de65c963-209b-4cae-af34-e4c1622a77af"
				}, // Воздушный фильтр малой пилы: Воздушный фильтр STIHL MS 170-180

				{
					"supplycategory-00000000-0000-0000-0000-000000000023",
					"supplysku-f4a72f24-7a77-4d13-9078-c75fb8116af8"
				}, // Гайка М8: Гайка крепления шины 026-66  М8

				{
					"supplycategory-00000000-0000-0000-0000-000000000005",
					"supplysku-a456a5fe-1c53-4e54-aaec-78dc929bbe6b"
				}, // Заклёпки для цепи малой пилы: Ремкомплект цепи STIHL 3/8P щетка + вилка ( мал. цепи)

				{
					"supplycategory-00000000-0000-0000-0000-000000000006",
					"supplysku-88dd09f3-5b31-4582-b1e8-15be17212bd2"
				}, // Заклёпки для цепи основной пилы: Ремкомплект цепи STIHL 3/8 щетка + вилка ( бол. цепи)

				{
					"supplycategory-00000000-0000-0000-0000-000000000028",
					"supplysku-588283a0-afa9-491c-b652-c2b171946fae"
				}, // Глушитель малой пилы: Глушитель STIHL 180

				{
					"supplycategory-00000000-0000-0000-0000-000000000018",
					"supplysku-764e30c8-4d9a-4838-a2b5-9e817f79b5f5"
				}, // Звёздочка малой пилы: Звёздочка цепи STIHL 180

				{
					"supplycategory-00000000-0000-0000-0000-000000000016",
					"supplysku-392cdf56-6cb4-4789-bf9a-85c3008ce960"
				}, // Карбюратор STIHL 180 

// → supplysku-392cdf56-6cb4-4789-bf9a-85c3008ce960 Карбюратор STIHL 180 

// → supplysku-0a344184-9f73-4ba2-8625-d7cf4e2a7660 Рем.комплект  карбюратора  MS 018/180

				{
					"supplycategory-00000000-0000-0000-0000-000000000009",
					"supplysku-bf1bb1b4-e3ce-4e0f-a4e5-f0f1cada9688"
				}, // Ограничительная лента: Сигнальная лента 50*150 мм 

				{
					"supplycategory-00000000-0000-0000-0000-000000000007",
					"supplysku-ed42335c-fdec-4a06-b1c9-f8feb84d5133"
				}, // Круг для заточки цепи 145*3,2*22,2

// → supplysku-a9e5efc1-6816-41bc-8558-e6638a9ef005 Круг для заточки цепи 104*3,2*23,2

// → supplysku-507abcfa-79dc-47a3-9f20-cf9523f1f1fe Круг для заточки цепи 145*4,5*22,2

// → supplysku-ed42335c-fdec-4a06-b1c9-f8feb84d5133 Круг для заточки цепи 145*3,2*22,2

				{
					"supplycategory-00000000-0000-0000-0000-000000000008",
					"supplysku-bafa08c1-8591-4ff6-8f7f-c0cd1d9fbf87"
				}, // Круг войлочный

// → supplysku-8c8f1236-7fb2-4fb3-99ae-360152cc9bc3 Круг точильный белый

// → supplysku-ec8926ca-5d86-437a-b1cf-42f3f8e6f512 Круг точильный серый

// → supplysku-bafa08c1-8591-4ff6-8f7f-c0cd1d9fbf87 Круг войлочный

				{
					"supplycategory-00000000-0000-0000-0000-000000000037",
					"supplysku-09b6bafb-380e-4a4d-a13d-1a6400e266b4"
				}, // Коннектор ленты: Коннекторы

				{
					"supplycategory-00000000-0000-0000-0000-000000000004",
					"supplysku-23ecaedb-7267-464f-855f-572944d094f4"
				}, // Лента шлифовальная Р-120

// → supplysku-41bca375-23fd-47ed-83ca-9d7f80780ef4  Лента шлифовальная Р-36

// → supplysku-3ae40814-6c68-400d-aacb-3f0d6b8d365e Лента шлифовальная Р-80

// → supplysku-23ecaedb-7267-464f-855f-572944d094f4 Лента шлифовальная Р-120

// → supplysku-a5b342b9-05b1-4f52-9028-b66cb7188aef Лента шлифовальная Р-180

// → supplysku-6009e44f-2d9a-4d65-9930-6e49159b3f7e Лента шлифовальная 10-Н

// → supplysku-c77f4c90-c331-43f6-8fca-cdaff7d181a7  Лента шлифовальная 40-Н

				{
					"supplycategory-00000000-0000-0000-0000-000000000002",
					"supplysku-47e209c3-8440-4e94-8dbf-a051955579a2"
				}, // Присадка к топливу STIHL HP

// → supplysku-47e209c3-8440-4e94-8dbf-a051955579a2 Присадка к топливу STIHL HP

// → supplysku-36059295-6966-4951-b957-a46d56256443 Стаканчик мерный

// → supplysku-38a74f10-778d-4c3d-8e8c-c1b653f0b95c Стаканчик мерный

				{
					"supplycategory-00000000-0000-0000-0000-000000000012",
					"supplysku-d390305a-738a-4579-ad07-e99103fd4bd0"
				}, // Паста ГОИ: Паста гои

				{
					"supplycategory-00000000-0000-0000-0000-000000000027",
					"supplysku-72dceafc-3825-413b-ab2a-f7e17599dd81"
				}, // Венец основной пилы: Венец Сменный 3/8 73 361 341 360

				{
					"supplycategory-00000000-0000-0000-0000-000000000035",
					"supplysku-1a17f1da-cbeb-4002-9465-077c5a5080a2"
				}, // Кабель КГ- ХЛ 2х1.5

// → supplysku-03eac5c2-74c9-46f8-891a-92b33eb92c7b Провод 0,75 ГХЛ

// → supplysku-1a17f1da-cbeb-4002-9465-077c5a5080a2 Кабель КГ- ХЛ 2х1.5

				{
					"supplycategory-00000000-0000-0000-0000-000000000036",
					"supplysku-5e0188a6-6119-4a63-a826-e6d83b3f25c9"
				}, // Прожектор 10W

// → supplysku-5e0188a6-6119-4a63-a826-e6d83b3f25c9 Прожектор 10W

// → supplysku-57f8c822-dcbc-4128-a4f5-55019a9541b9 Прожектор 15W RGB

// → supplysku-16e55a20-1910-45c8-b0eb-33c43cb7d427 Прожектор 20W

// → supplysku-f66533c8-b998-4f21-835a-de0e6aea6d49 Прожектор 30W

// → supplysku-c5e4d836-3ec5-4701-8547-d57b55137c30 Прожектор 50W

// → supplysku-033e2363-a210-4bf9-8dc7-e0959d89b9c3 Прожектор 75W RGB

// → supplysku-a79e626c-f0bf-47d1-8aa8-506fc3aef6ba Прожектор 150W галогеновый

// → supplysku-6c903a06-2f47-4cc8-90da-93011fdbfb05 Прожектор светодиодный RGB 30 Вт 12 В IP 65

				{
					"supplycategory-00000000-0000-0000-0000-000000000030",
					"supplysku-c73df860-6267-44c2-83ba-b539d17ef9fd"
				}, // Пробка топливного бака универсальная MS 150,181-461,880

// → supplysku-c5390c56-1bde-4eb0-b5ee-1cd29b135f71 Пробка топливного бака STIHL MS 180

// → supplysku-17714004-393a-4a0f-a179-3fc37b405f5d Пробка топливного бака STIHL MS 440

// → supplysku-4c01c472-c68b-4a16-91f0-6ccd53869597 Пробка топливного бака STIHL MS 660

// → supplysku-c73df860-6267-44c2-83ba-b539d17ef9fd Пробка топливного бака универсальная MS 150,181-461,880

				{
					"supplycategory-00000000-0000-0000-0000-000000000022",
					"supplysku-1bc30107-4d32-430a-965b-f0cb3beca920"
				}, // Пружина сцепления малой пилы: Пружина муфты сцепления STIHL MS 180

				{
					"supplycategory-00000000-0000-0000-0000-000000000021",
					"supplysku-0a4a0044-6468-48bc-bea2-2210426af297"
				}, // Пружина муфты сцепления STIHL MS 660

// → supplysku-0a4a0044-6468-48bc-bea2-2210426af297 Пружина муфты сцепления STIHL MS 660

// → supplysku-4f661ff1-a1ed-43ae-8d95-e2f52577f93c Пружина муфты сцепления STIHL MS 420

				{
					"supplycategory-00000000-0000-0000-0000-000000000031",
					"supplysku-987cb8f7-06fa-4cff-b735-ae0f4de45c1e"
				}, // Ручка стартера:  Рукоятка STIHL MS 180-660

				{
					"supplycategory-00000000-0000-0000-0000-000000000029",
					"supplysku-3c5cdf71-e2a9-4824-8304-3b513b013fde"
				}, // Червяк маслонасоса малой пилы: Червяк маслонасоса STIHL MS 170-251

				{
					"supplycategory-00000000-0000-0000-0000-000000000034",
					"supplysku-d19b0f0a-fb81-42be-94ae-badc6c4fee4b"
				}, // Лента RGB SMD 5050 60 Led/м 14.4 Вт 12 Вольт

// → supplysku-0017edf7-5048-47bd-8917-b17572647bc4 RGB

// → supplysku-d19b0f0a-fb81-42be-94ae-badc6c4fee4b Лента RGB SMD 5050 60 Led/м 14.4 Вт 12 Вольт

				{
					"supplycategory-00000000-0000-0000-0000-000000000026",
					"supplysku-16720cec-3ec1-463a-8f69-e5860ae8d6fe"
				}, // Шайба стопорная чашки сцепления 170-660 арт. 94606240801

// → supplysku-64025d92-6765-4aee-a07f-b63cd1822276 Стопорная шайба MS 440/660

// → supplysku-9c362f41-c37c-4238-87ca-fe46613a3463 Стопорная шайба  MS 180

// → supplysku-16720cec-3ec1-463a-8f69-e5860ae8d6fe Шайба стопорная чашки сцепления 170-660 арт. 94606240801

				{
					"supplycategory-00000000-0000-0000-0000-000000000019",
					"supplysku-9d2b832b-449e-4cf5-a1b2-b0e9009e0892"
				}, // Подшипник игольчатый малой пилы: Подшипник игольчатый чашки MS 170-291,390(10х13х10)

				{
					"supplycategory-00000000-0000-0000-0000-000000000020",
					"supplysku-355364a9-e229-410f-b9af-5135088f6106"
				}, // Подшипник игольчатый чашки MS 660-661(10х16х13)

// → supplysku-c406e010-a7be-441c-82df-59ed31c7870c Подшипник игольчатый STIHL MS 361/440

// → supplysku-355364a9-e229-410f-b9af-5135088f6106 Подшипник игольчатый чашки MS 660-661(10х16х13)

				{
					"supplycategory-00000000-0000-0000-0000-000000000024",
					"supplysku-bc473fe4-3cde-4eb4-b05c-1fe130da205b"
				}, // Гайка крепления карбюратора: Гайка крепления карбюратора М5 170- 250

				{
					"supplycategory-00000000-0000-0000-0000-000000000033",
					"supplysku-f878d5af-6c7f-49e9-b65d-afa9317bb144"
				}, // Очиститель карбюратора: Очиститель Карбюратора

				{
					"supplycategory-00000000-0000-0000-0000-000000000015",
					"supplysku-bc0024ac-4509-4aa6-bd93-bff1d2cc9206"
				}, // Свечи зажигания: Свеча зажигания NGK BPM7A 

				{
					"supplycategory-00000000-0000-0000-0000-000000000013",
					"supplysku-94b917c5-e397-4292-a312-9d1f1ef4b0a1"
				}, // Батарейки: Батарейки тип ААА

				{
					"supplycategory-00000000-0000-0000-0000-000000000010",
					"supplysku-9ff52a7f-6a76-42e3-9f8a-0db68b362b6d"
				}, // Изолента пластиковая: Изолента 15х20 мм синяя 

				{
					"supplycategory-00000000-0000-0000-0000-000000000014",
					"supplysku-de6b4dd7-ab1b-4f19-a74e-b97fb0b45b68"
				}, // Трос стартера: Трос стартера запускной Champion 3.5 1м.

				{
					"supplycategory-00000000-0000-0000-0000-000000000011",
					"supplysku-1bf6576f-998d-4dbb-af12-a2e79212884d"
				}, // Изолента тканевая: Изолента тканевая

				{
					"supplycategory-00000000-0000-0000-0000-000000000025",
					"supplysku-95d93cf5-2222-481c-b568-85e655e49332"
				}, // Шайба сцепления малой пилы: Шайба сцепления малой пилы

				{
					"supplycategory-00000000-0000-0000-0000-000000000003",
					"supplysku-3e847eb7-fbdc-4dab-aeb3-0d316086d58b"
				}, // Масло для цепи: Масло для цепи

				
				// ----------------- manual ----------
				
				
				
        { "supplycategory-9d6041fd-a147-4fb7-b1e8-f61411902fe0", "supplysku-b2111d5f-2195-47bf-a0bb-6fd136f65797" }, // Отбивная нить: Отбивная нить STAYER для строит. работ на катушке 50 м.

        { "supplycategory-70bfb53d-622e-4c2f-89d0-2b31dc844258", "supplysku-f652ced8-348c-4e3c-a12d-489527c72da1" }, // !!! Червяк маслонасоса основной пилы: ??? Червяк маслонасоса STIHL MS 660

// → supplysku-f652ced8-348c-4e3c-a12d-489527c72da1 Червяк маслонасоса STIHL MS 660

// → supplysku-2bbf3103-eb27-4b9b-9cb9-2385f6ea446b Червяк маслонасоса STIHL MS 440

        { "supplycategory-e8d61b59-4ddd-497b-b14b-56d6c17b0e30", "supplysku-4f85e9b4-1452-40c1-ae2e-2054ef56156c" }, // Крышка стартера в сборе: Крышка стартера в сборе STIHL MS 180

        { "supplycategory-a5c7c941-63e0-4110-8689-b4d98abaaf9d", "supplysku-615ecc3d-31a0-47ca-a38b-1b89f21fa249" }, // Отвертка для карбюратора: Отвертка для карбюратора STIHL

        { "supplycategory-30532223-ce6d-4053-a103-04d35a855752", "supplysku-061c1e77-d64b-41d4-8637-2ff5deb18e25" }, // Поддон картера: Поддон картера STIHL MS 180

        { "supplycategory-2b71d4b6-2203-4669-888b-a36f18859329", "supplysku-6f1b2c5c-8b8f-4e87-973f-2a66bcc8b421" }, // !!! Собачка стартера: ??? Собачка стартера STIHL MS 170-462

// → supplysku-6f1b2c5c-8b8f-4e87-973f-2a66bcc8b421 Собачка стартера STIHL MS 170-462

// → supplysku-9c8fd043-50b0-4a9f-83db-765874cf159d Собачка стартера STIHL MS 462-880

        { "supplycategory-f4f85bf3-4448-4e54-a187-3bd3bd653156", "supplysku-6194fe27-0e0b-44df-ab53-9c9c03037218" }, // !!! Сцепление : ??? Сцепление STIHL MS 180

// → supplysku-6194fe27-0e0b-44df-ab53-9c9c03037218 Сцепление STIHL MS 180

// → supplysku-3bc27399-afa0-441a-949f-c3bec295ad46 Сцепление STIHL MS 660

// → supplysku-302e667d-c49a-45e0-8043-2414b014e50e Сцепление STIHL MS 361

// → supplysku-c88656ab-efd3-4c41-818c-5f9ae2dae106 Сцепление STIHL MS 440

        { "supplycategory-89054c9e-b160-4bec-a109-9b4bda9b5a9d", "supplysku-e3b01df4-2182-4e8d-a36b-50c5c1896fb1" }, // !!! Цилиндро-поршневая группа: ??? Цилиндро-поршневая группа STIHL MS 180

// → supplysku-e3b01df4-2182-4e8d-a36b-50c5c1896fb1 Цилиндро-поршневая группа STIHL MS 180

// → supplysku-a8899aac-4fc1-4db7-9b9f-691ff5635098 Цилиндр с поршнем MS 660 (54мм)

        { "supplycategory-6897d442-9fe5-4388-ada7-46e197331e1c", "supplysku-bbf2e5b3-dff8-4acd-b7f0-1ede3cccd7f1" }, // !!! Колено карбюратора: ??? STIHL MS 180

// → supplysku-bbf2e5b3-dff8-4acd-b7f0-1ede3cccd7f1 STIHL MS 180

// → supplysku-c6dd1b02-9b31-40b5-b5e8-66d04aaa390e Колено STIHL MS 440

// → supplysku-9fffe602-0f26-4a47-adab-1310a2846f31 Колено STIHL MS 660

// → supplysku-aae2e954-3b7d-4e74-a557-0ac43b364e1f Колено SHTIL 170-180

        { "supplycategory-21763803-a913-4ea1-9a37-8df4d634e7e5", "supplysku-ae4d374a-ba00-4077-a7fe-a5687e1c4258" }, // !!! Шайба звездочки: ??? Шайба чашки сцепления  MS 180-290 STIHL

// → supplysku-ae4d374a-ba00-4077-a7fe-a5687e1c4258 Шайба чашки сцепления  MS 180-290 STIHL

// → supplysku-affa5e72-4397-4965-ac39-5f132837b6a8 Шайба чашки сцепления 341-660 MS STIHL

        { "supplycategory-a8a92220-5b52-400b-ae51-e08c4038a89b", "supplysku-abf363a0-4d4e-4b9c-be6f-99b6c8d33110" }, // Фильтр топливный: STIHL MS 180-250

        { "supplycategory-1a336dfb-5379-45b1-abf7-a0ab4383205b", "supplysku-a1bcfce2-98ef-4568-b983-dde2a1327aea" }, // Коленвал: Коленвал STIHL MS 660

        { "supplycategory-a77d7ada-b54c-41ca-9a5a-84f8d0106187", "supplysku-73ad7736-b74d-4743-a3c2-af755352b893" }, // !!! Лента тормоза: ??? Лента тормоза STIHL MS 180

// → supplysku-73ad7736-b74d-4743-a3c2-af755352b893 Лента тормоза STIHL MS 180

// → supplysku-75306fee-e964-41cb-9c17-a5ff3a8fbcc5 Лента тормоза STIHL MS 660

        { "supplycategory-4b7983ff-ff29-41df-b8e9-19669c6b927b", "supplysku-dca08e26-cf28-41af-81e7-aae7748b0516" }, // Глушитель: Глушитель STIHL MS 180

        { "supplycategory-60defe6e-b89b-4664-b7af-bbca11e343ca", "supplysku-c7e53801-ce67-4173-b917-8317b2b0de5f" }, // Натяжитель цепи: Натяжитель цепи STIHL MS 180

        { "supplycategory-dbb58a9c-ed3b-4c24-8ed4-932cd4fb2f2b", "supplysku-7a5fb687-3279-4038-94ea-7182432e2101" }, // Ручка тормоза: Рукоятка STIHL MS 180

        { "supplycategory-c0ed7353-001d-4666-95a4-28c574effe3c", "supplysku-5e84f0f3-8479-4862-a587-b23290dbd1a0" }, // Рукоятка: Рукоятка STIHL MS 180

        { "supplycategory-2568d03d-b822-483b-aa22-6440b1d84ad7", "supplysku-a539cadb-ed98-4ef8-8ab7-42590f466c3f" }, // Вилки: Вилка

        { "supplycategory-949b279a-20b6-4042-9587-7ad2b58e3a8d", "supplysku-88558209-f58f-4d2d-b118-8252ec8d2683" }, // Розетки: Розетки

        { "supplycategory-fc49c7c8-4a57-4a3c-a718-ff72e29406f9", "supplysku-1a6a9a41-feed-4446-86a3-dac9a62f6249" }, // !!! Рем комплект карбюратора MS 361-660 : ??? Карбюратор MS 440 ( HD17C)

// → supplysku-1a6a9a41-feed-4446-86a3-dac9a62f6249 Карбюратор MS 440 ( HD17C)

// → supplysku-be4af47e-ffb8-4749-9db3-3ef9b06aac7d Рем комплект карбюратора MS 660 арт. 1122 007 1060 

        { "supplycategory-2eb94921-2681-4293-b026-396f86ea29ee", "supplysku-c57881b2-f031-47c3-9152-b87e895f75d8" }, // Звездочка  STIHL MS 341-361: Звездочка цепная 3/8 7Z 341-361

        { "supplycategory-526c164c-0052-4319-90ad-bde7d7d66e9c", "supplysku-67bddd80-0500-4c22-be5b-61c526a37ab2" }, // !!! Ножи концелярские: ??? Нож выдвижной   арт. 78913

// → supplysku-67bddd80-0500-4c22-be5b-61c526a37ab2 Нож выдвижной   арт. 78913

// → supplysku-175460f1-e04e-4e53-bf28-2db97f999c57 Лезвия 25 мм 10 шт в уп. MATRIX

        { "supplycategory-e407d3f6-0ed4-49e4-811b-36339d5619f4", "supplysku-3d53f529-f92d-47a7-b0d2-694bfd60afe7" }, // !!! Блоки питания: ??? Блок питания 400 Вт 12 V IP 20

// → supplysku-3d53f529-f92d-47a7-b0d2-694bfd60afe7 Блок питания 400 Вт 12 V IP 20

// → supplysku-ed1c6495-4cf6-4dbb-915b-0af4fe61205f Блок питания 300 Вт 12 V IP 20

// → supplysku-42a84086-6ad7-45b9-9281-2dbd81fb89fb Блок питания 200 Вт 12 V IP 20

        { "supplycategory-9e9f1d1c-2a23-4509-9117-dd2556b9d6ac", "supplysku-c6a14e86-2963-441a-b3ae-4a1227676fcc" }, // Сальники: Сальник Shtil MS 170-250

        { "supplycategory-d76c39fb-0c0c-477c-8e08-6f4551df566a", "supplysku-8d49797e-cfc1-4bc9-897f-a9d0d0406cba" }, // Муфта сцепления MS 660: Муфта сцепления MS 660

        { "supplycategory-7d640be8-9e35-4b5e-9d36-e1995b1da6ed", "supplysku-71c4d479-ac94-46bd-8f5d-44055dbcdf3f" }, // Воздушный фильтр основной пилы: Фильтр воздушный SHTIL MS 441,660,880 MSA

        { "supplycategory-aaa0d8f1-8d02-4e69-8a08-6f4f497ff813", "supplysku-da5a6ff2-f8be-4a26-8d3e-7f6f4a273e14" }, // !!! Пробка маслобака: ??? Пробка маслобака SHTIL MS 170-180

// → supplysku-da5a6ff2-f8be-4a26-8d3e-7f6f4a273e14 Пробка маслобака SHTIL MS 170-180

// → supplysku-72e5b67a-49c5-41a4-a073-f81e0bba3568 Пробка маслобака  SHTIL MS 660

        { "supplycategory-30ff4fa4-3001-4d5a-866c-31e5bf12307a", "supplysku-f0310740-7c2c-4505-b2c3-40b34bcfd0cc" }, // Червяк привода маслонасоса: Червяк привода маслонасоса STIHL MS 361

        { "supplycategory-f1ddde7a-abdd-4efa-924b-aea7c52a59db", "supplysku-ca1f50e8-bf43-4938-bfda-ffcf698a1b35" }, // Модуль зажигания: Модуль зажигания STIHL MS 170-180 арт. 44396

        { "supplycategory-6742ea2c-2f53-4a16-b72b-4eb588ad7e42", "supplysku-f6988cf7-762d-4121-ad79-22538d078c6c" }, // Рем. комплект карбюратора малой пилы: Рем.комплект  карбюратора  MS 018/180

        { "supplycategory-33b213ea-c035-4d43-8272-6a2b71990ce6", "supplysku-762d3a1b-d4bc-4b40-9521-5c5a756b7789" }, // Звездочка  STIHL MS 440: Звездочка STIHL MS 440 

        { "supplycategory-079b10b0-d5a5-4f3b-a6ee-ade08119d855", "supplysku-68ff5f20-8cf9-4fee-82f5-0c77a41b6283" }, // Звездочка  STIHL MS 660: Звездочка  STIHL MS 660


			};

			return map;
		}

	}
}