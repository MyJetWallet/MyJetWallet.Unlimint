using System.Collections.Generic;
using MyJetWallet.Unlimint.Base;
using MyJetWallet.Unlimint.Models.Payments;

namespace MyJetWallet.Unlimint.Converters
{
    public class PaymentErrorCodeConverter : BaseConverter<PaymentErrorCode>
    {
        public PaymentErrorCodeConverter() : this(true)
        {
        }

        public PaymentErrorCodeConverter(bool quotes) : base(quotes)
        {
        }

        protected override List<KeyValuePair<PaymentErrorCode, string>> Mapping => new()
        {
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.SystemMalfunction, "01"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CancelledByCustomer, "02"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.DeclinedByAntifraud, "03"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.DeclinedBy3DSecure, "04"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.Only3DSecureTransactionsAllowed, "05"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.Availability3DSecureUnknown, "06"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.LimitReached, "07"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.RequestedOperationNotSupported, "08"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.DeclinedByBank, "10"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CommonDeclineByBank, "11"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.SoftDecline, "12"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.InsufficientFunds, "13"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardLimitReached, "14"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.IncorrectCardData, "15"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.DeclinedByAntifraud, "16"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.BankMalfunction, "17"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.ConnectionProblem, "18"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.IncorrectPaymentData, "19"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.BitcoinNoPaymentReceived, "21"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.BitcoinWrongPaymentReceived, "22"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.BitcoinConfirmationsPaymentTimeout, "23"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.MaximumAmountLimitExceeded, "25"),
        };
    }
}