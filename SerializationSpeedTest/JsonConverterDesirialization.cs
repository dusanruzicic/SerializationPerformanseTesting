using Invenda.Domain.Models.Shared.Transactions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationSpeedTest
{
	public class JsonConverterDesirialization : IDeserialization
	{
		public Transaction Deserialize(string json)
		{
			var transaction = JsonConvert.DeserializeObject<Transaction>(json, new TransactionConverter());

			return transaction;
		}
	}

	public class TransactionConverter : JsonConverter<Transaction>
	{
		public override void WriteJson(JsonWriter writer, Transaction value, JsonSerializer serializer)
		{
			writer.WriteValue(value.ToString());
		}

		public override Transaction ReadJson(JsonReader reader, Type objectType, Transaction existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			string s = (string)reader.Value;

			return new Transaction();
		}
	}
}
