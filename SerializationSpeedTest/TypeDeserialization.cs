using Invenda.Domain.Models.Shared.Transactions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationSpeedTest
{
	public class TypeDeserialization : IDeserialization
	{
		public Transaction Deserialize(string json)
		{
			var messageObject = JsonConvert.DeserializeObject<Transaction>(json);
			var transaction = CopyObject(messageObject);

			return transaction;
		}

		private Transaction CopyObject(Transaction messageObject)
		{
			var transaction = new Transaction();
			transaction.AgeVerificationStatus = messageObject.AgeVerificationStatus;
			transaction.ChangeGivenHistory = messageObject.ChangeGivenHistory;
			transaction.ChangeMode = messageObject.ChangeMode;
			transaction.CreatedAt = messageObject.CreatedAt;
			transaction.CreatedByUserId = messageObject.CreatedByUserId;
			transaction.CreditAfterTransaction = messageObject.CreditAfterTransaction;
			transaction.CreditBeforeTransaction = messageObject.CreditBeforeTransaction;
			transaction.CurrencyId = messageObject.CurrencyId;
			transaction.CustomerDemographic = messageObject.CustomerDemographic;
			transaction.CustomerId = messageObject.CustomerId;
			transaction.EndedAt = messageObject.EndedAt;
			transaction.Id = messageObject.Id;
			transaction.IsDeleted = messageObject.IsDeleted;
			transaction.LastPlayedVideoProductId = messageObject.LastPlayedVideoProductId;
			transaction.MoneyInsertedHistory = messageObject.MoneyInsertedHistory;
			transaction.OfferedProducts = messageObject.OfferedProducts;
			transaction.PaymentMethod = messageObject.PaymentMethod;
			transaction.PriceListInternalCode = messageObject.PriceListInternalCode;
			transaction.ProductReservationHistory = messageObject.ProductReservationHistory;
			transaction.ProductSelectionHistory = messageObject.ProductSelectionHistory;
			transaction.SalesAppConfigurationInternalCode = messageObject.SalesAppConfigurationInternalCode;
			transaction.StartedAt = messageObject.StartedAt;
			transaction.StartMethod = messageObject.StartMethod;
			transaction.SyncedAt = messageObject.SyncedAt;
			transaction.TerminalConfigurationInternalCode = messageObject.TerminalConfigurationInternalCode;
			transaction.TerminalId = messageObject.TerminalId;
			transaction.TransactionMetrics = messageObject.TransactionMetrics;
			transaction.TransactionState = messageObject.TransactionState;
			transaction.UpdatedAt = messageObject.UpdatedAt;
			transaction.UpdatedByUserId = messageObject.UpdatedByUserId;
			transaction.UserFeedback = messageObject.UserFeedback;
			transaction.UtcOffsetInHours = messageObject.UtcOffsetInHours;
			transaction.Version = messageObject.Version;

			return transaction;
		}
	}
}
