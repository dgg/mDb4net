using System;
using System.Diagnostics;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace BsonSerialization.Sample
{
	class Program
	{
		static void Main(string[] args)
		{
			var o = new TopLevel
			{
				Name = "top",
				Number = 3.1416m,
				Children = new[]
				{
					new SecondLevel { Name = "normal", Priority = ProcessPriorityClass.Normal },
					new SecondLevel { Name = "high", Priority = ProcessPriorityClass.High },
					new SecondLevel { Name = "real time", Priority = ProcessPriorityClass.RealTime }
				}
			};

			string json = o.ToJson();
			Console.WriteLine(json);

			o = BsonSerializer.Deserialize<TopLevel>(json);
			Console.WriteLine("\n" + o.Children[0].Priority);

			Console.WriteLine("\n...INTRO...");
			Console.ReadLine();
		}
	}
}
