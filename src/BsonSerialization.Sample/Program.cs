using System;
using System.Diagnostics;
using MongoDB.Bson;

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
			new SecondLevel { Name = "real time", Priority = ProcessPriorityClass.RealTime },
		}
			};
			Console.WriteLine(o.ToJson());

			Console.WriteLine("\n...INTRO...");
			Console.ReadLine();
		}
	}
}
