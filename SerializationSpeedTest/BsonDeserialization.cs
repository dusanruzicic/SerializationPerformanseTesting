using Invenda.Domain.Model.Invoicing;
using Invenda.Domain.Model.Transaction;
using Invenda.Domain.Models.Shared.Transactions;
using Invenda.Domain.Models.Shared.Transactions.TransactionMetrics;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializationSpeedTest
{
	public class BsonDeserialization : IDeserialization
	{
		public Transaction Deserialize(string json)
		{
			BsonDocument messageObject = BsonSerializer.Deserialize<BsonDocument>(json);
			//return BsonSerializer.Deserialize<Transaction>(messageObject); //Deserialize object without changes
			var transaction = CopyObject(messageObject);

			return transaction;
		}

		private T CastBsonToReferenceType<T>(BsonValue document)
		{
			T retType = default(T);

			if (document.IsBsonNull)
			{
				return retType;
			}

			if (document.IsBsonDocument)
			{
				retType = BsonSerializer.Deserialize<T>(document.AsBsonDocument);
			}

			return retType;
		}

		private List<T> CastBsonToListType<T>(BsonValue document) where T : class
		{
			List<T> retType = default(List<T>);

			if (document.IsBsonNull)
			{
				return retType;
			}

			if (document.IsBsonArray)
			{
				return document.AsBsonArray.Select(val => BsonSerializer.Deserialize<T>(val.AsBsonDocument)).ToList();
			}

			return retType;
		}

		private T CastBsonToValueType<T>(BsonValue document)
		{
			T retType = default(T);

			if (document.IsBsonNull)
			{
				return retType;
			}

			if (document.IsBsonDocument)
			{
				retType = BsonSerializer.Deserialize<T>(document.AsBsonDocument);
			}

			if (document.IsString)
			{
				retType = (T)Enum.Parse(typeof(T), document.AsString);
			}

			return retType;
		}

		private Transaction CopyObject(BsonDocument messageObject)
		{
			var transaction = new Transaction();
			transaction.AgeVerificationStatus = CastBsonToReferenceType<AgeVerificationStatus>(messageObject["AgeVerificationStatus"]);
			transaction.ChangeGivenHistory = CastBsonToListType<ChangeGiven>(messageObject["ChangeGivenHistory"]);
			transaction.ChangeMode = CastBsonToValueType<ChangeMode>(messageObject["ChangeMode"]);
			transaction.CreatedAt = DateTime.Parse(messageObject["CreatedAt"].AsString);
			transaction.CreatedByUserId = messageObject["CreatedAt"].AsString;
			transaction.CreditAfterTransaction = messageObject["CreditAfterTransaction"].AsInt32;
			transaction.CreditBeforeTransaction = messageObject["CreditBeforeTransaction"].AsInt32;
			transaction.CurrencyId = messageObject["CurrencyId"].AsString;
			transaction.CustomerDemographic = CastBsonToReferenceType<CustomerDemographic>(messageObject["CustomerDemographic"]);
			transaction.CustomerId = messageObject["CustomerId"].AsString;
			transaction.EndedAt = messageObject["EndedAt"].IsString ? (DateTime?)DateTime.Parse(messageObject["EndedAt"].AsString) : null;
			transaction.Id = null;
			transaction.IsDeleted = messageObject["IsDeleted"].AsBoolean;
			transaction.LastPlayedVideoProductId = messageObject["LastPlayedVideoProductId"].IsString ? messageObject["LastPlayedVideoProductId"].AsString : null;
			transaction.MoneyInsertedHistory = CastBsonToListType<MoneyInserted>(messageObject["MoneyInsertedHistory"]);
			transaction.OfferedProducts = CastBsonToListType<OfferedProduct>(messageObject["OfferedProducts"]);
			transaction.PaymentMethod = CastBsonToValueType<TransactionPaymentMethod>(messageObject["PaymentMethod"]);
			transaction.PriceListInternalCode = messageObject["PriceListInternalCode"].AsString;
			transaction.ProductReservationHistory = CastBsonToListType<ProductReservationDetails>(messageObject["ProductReservationHistory"]);
			transaction.ProductSelectionHistory = CastBsonToListType<ProductSelection>(messageObject["ProductSelectionHistory"]);
			transaction.SalesAppConfigurationInternalCode = messageObject["SalesAppConfigurationInternalCode"].AsString;
			transaction.StartedAt = DateTime.Parse(messageObject["StartedAt"].AsString);
			transaction.StartMethod = CastBsonToValueType<TransactionStartMethod>(messageObject["StartMethod"]);
			transaction.SyncedAt = messageObject["SyncedAt"].IsString ? (DateTime?)DateTime.Parse(messageObject["SyncedAt"].AsString) : null;
			transaction.TerminalConfigurationInternalCode = messageObject["TerminalConfigurationInternalCode"].AsString;
			transaction.TerminalId = messageObject["TerminalId"].AsString;
			transaction.TransactionMetrics = CastBsonToReferenceType<TransactionMetrics>(messageObject["TransactionMetrics"]);
			transaction.TransactionState = CastBsonToValueType<TransactionState>(messageObject["TransactionState"]);
			transaction.UpdatedAt = DateTime.Parse(messageObject["UpdatedAt"].AsString);
			transaction.UpdatedByUserId = null;
			transaction.UserFeedback = CastBsonToReferenceType<Invenda.Domain.Models.Shared.UserFeedback>(messageObject["UserFeedback"]);
			transaction.UtcOffsetInHours = messageObject["UtcOffsetInHours"].AsInt32;
			transaction.Version = CastBsonToReferenceType<Invenda.Domain.Version>(messageObject["Version"]);

			return transaction;
		}
	}
}
