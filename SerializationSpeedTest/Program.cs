using Invenda.Domain.Models.Shared.Transactions;
using System;
using System.Diagnostics;

namespace SerializationSpeedTest
{
	class Program
	{
		private const int _iterations = 100000;

		static void Main(string[] args)
		{
			Console.WriteLine("Program starting...");
			string[] lines = System.IO.File.ReadAllLines(@"transaction.json");
			string json = string.Join("", lines);


			Console.WriteLine("");
			Console.WriteLine("**** Round 1 ****");

			//Test type serialization
			var typeSer = new TypeSerialization();
			MeasurePerformance(typeSer, json, "Type Serialization");

			//Test dynamic serialization
			var dynamicSer = new DynamicSerialization();
			MeasurePerformance(dynamicSer, json, "Dynamic Serialization");

			//Test bson serialization
			var bsonSer = new BsonSerialization();
			MeasurePerformance(bsonSer, json, "Bson Serialization");

			Console.WriteLine("");
			Console.WriteLine("**** Round 2 ****");

			//Test type serialization
			typeSer = new TypeSerialization();
			MeasurePerformance(typeSer, json, "Type Serialization");

			//Test dynamic serialization
			dynamicSer = new DynamicSerialization();
			MeasurePerformance(dynamicSer, json, "Dynamic Serialization");

			//Test bson serialization
			bsonSer = new BsonSerialization();
			MeasurePerformance(bsonSer, json, "Bson Serialization");
			
			Console.WriteLine("");
			Console.WriteLine("Press ENTER to exit...");
			Console.ReadLine();
		}

		static void MeasurePerformance(ISerialization serializator, string json, string message)
		{
			Stopwatch stopWatch = new Stopwatch();

			stopWatch.Start();
			for (int i = 0; i < _iterations; i++)
			{
				var transaction = serializator.Serialize(json);
			}
			stopWatch.Stop();
			DisplayTime(stopWatch, message);
		}

		static void DisplayTime(Stopwatch stopWatch, string message)
		{
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = stopWatch.Elapsed;

			// Format and display the TimeSpan value.
			string elapsedTime = String.Format("\t{0:00}:{1:00}:{2:00}.{3:00}",
				ts.Hours, ts.Minutes, ts.Seconds,
				ts.Milliseconds / 10);
			Console.WriteLine($"{message} RunTime: {elapsedTime}");
		}
	}
}
