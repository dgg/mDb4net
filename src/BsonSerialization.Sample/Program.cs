using System;
using System.Diagnostics;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace BsonSerialization.Sample
{
	class Program
	{
		static void Main(string[] args)
		{
			var o = new TopLevel
			{
				Id = Guid.Empty,
				Name = "top",
				Number = 3.1416m,
				Children = new[]
				{
					new SecondLevel { Name = "normal", Priority = ProcessPriorityClass.Normal },
					new SecondLevel { Name = "high", Priority = ProcessPriorityClass.High },
					new SecondLevel { Name = "real time", Priority = ProcessPriorityClass.RealTime }
				}
			};

			BsonClassMap.RegisterClassMap<TopLevel>(map =>
			{
				// important to get default behavior
				map.AutoMap();
				map.GetMemberMap(tl => tl.Name).SetElementName("display_name");
			});

			var camelize = new ConventionPack
			{
				new CamelCaseElementNameConvention(),
				new WeirdEnumCasingConvention()
			};
			ConventionRegistry.Register("camelize", camelize, _=> true);

			string json = o.ToJson();
			Console.WriteLine(json);

			o = BsonSerializer.Deserialize<TopLevel>(json);
			Console.WriteLine(o.Children[0].Priority);

			Console.WriteLine("\n...INTRO...");
			Console.ReadLine();
		}
	}
}
