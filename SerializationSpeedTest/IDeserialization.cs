using Invenda.Domain.Models.Shared.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationSpeedTest
{
	public interface IDeserialization
	{
		Transaction Deserialize(string json);
	}
}
