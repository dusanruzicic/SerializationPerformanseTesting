using Invenda.Domain.Models.Shared;
using Invenda.Domain.Models.Shared.Transactions;
using Invenda.Domain.Models.Shared.Transactions.TransactionMetrics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SerializationSpeedTest
{
	public class DynamicDeserialization : IDeserialization
	{
		public Transaction Deserialize(string json)
		{
			dynamic messageObject = JsonConvert.DeserializeObject(json);
			//return messageObject.ToObject<Transaction>(); //Deserialize object without changes
			var transaction = CopyObject(messageObject);

			return transaction;
		}

		dynamic DynamicCast(object entity, Type to)
		{
			var openCast = this.GetType().GetMethod("Cast", BindingFlags.Static | BindingFlags.NonPublic);
			var closeCast = openCast.MakeGenericMethod(to);
			return closeCast.Invoke(entity, new[] { entity });
		}
		static T Cast<T>(object entity) where T : class
		{
			return entity as T;
		}

		private Transaction CopyObject(dynamic messageObject)
		{
			var transaction = new Transaction();
			transaction.AgeVerificationStatus = messageObject.AgeVerificationStatus.ToObject<AgeVerificationStatus>();
			transaction.ChangeGivenHistory = messageObject.ChangeGivenHistory.ToObject<List<ChangeGiven>>();
			transaction.ChangeMode = messageObject.ChangeMode;
			transaction.CreatedAt = messageObject.CreatedAt;
			transaction.CreatedByUserId = messageObject.CreatedByUserId;
			transaction.CreditAfterTransaction = messageObject.CreditAfterTransaction;
			transaction.CreditBeforeTransaction = messageObject.CreditBeforeTransaction;
			transaction.CurrencyId = messageObject.CurrencyId;
			transaction.CustomerDemographic = messageObject.CustomerDemographic.ToObject<CustomerDemographic>();
			transaction.CustomerId = messageObject.CustomerId;
			transaction.EndedAt = messageObject.EndedAt;
			transaction.Id = messageObject.Id;
			transaction.IsDeleted = messageObject.IsDeleted;
			transaction.LastPlayedVideoProductId = messageObject.LastPlayedVideoProductId;
			transaction.MoneyInsertedHistory = messageObject.MoneyInsertedHistory.ToObject<List<MoneyInserted>>();
			transaction.OfferedProducts = messageObject.OfferedProducts.ToObject<List<OfferedProduct>>();
			transaction.PaymentMethod = messageObject.PaymentMethod;
			transaction.PriceListInternalCode = messageObject.PriceListInternalCode;
			transaction.ProductReservationHistory = messageObject.ProductReservationHistory.ToObject<List<ProductReservationDetails>>();
			transaction.ProductSelectionHistory = messageObject.ProductSelectionHistory.ToObject<List<ProductSelection>>();
			transaction.SalesAppConfigurationInternalCode = messageObject.SalesAppConfigurationInternalCode;
			transaction.StartedAt = messageObject.StartedAt;
			transaction.StartMethod = messageObject.StartMethod;
			transaction.SyncedAt = messageObject.SyncedAt;
			transaction.TerminalConfigurationInternalCode = messageObject.TerminalConfigurationInternalCode;
			transaction.TerminalId = messageObject.TerminalId;
			transaction.TransactionMetrics = messageObject.TransactionMetrics.ToObject<TransactionMetrics>();
			transaction.TransactionState = messageObject.TransactionState;
			transaction.UpdatedAt = messageObject.UpdatedAt;
			transaction.UpdatedByUserId = messageObject.UpdatedByUserId;
			transaction.UserFeedback = messageObject.UserFeedback.ToObject<UserFeedback>();
			transaction.UtcOffsetInHours = messageObject.UtcOffsetInHours;
			transaction.Version = messageObject.Version.ToObject<Invenda.Domain.Version>();

			return transaction;
		}
	}
}
