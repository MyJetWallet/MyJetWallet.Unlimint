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
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.SystemMalfunction, "1"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CancelledByCustomer, "2"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.DeclinedByAntifraud, "3"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.DeclinedBy3DSecure, "4"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.Only3DSecureTransactionsAllowed, "5"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.Availability3DSecureUnknown, "6"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.LimitReached, "7"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.RequestedOperationNotSupported, "8"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.DeclinedByBank, "10"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CommonDeclineByBank, "11"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.SoftDecline, "12"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.InsufficientFunds, "13"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardLimitReached, "14"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.IncorrectCardData, "15"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.DeclinedByAntifraud, "16"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.BankMalfunction, "17"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.ConnectionProblem, "18"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.BitcoinNoPaymentReceived, "21"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.BitcoinWrongPaymentReceived, "22"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.BitcoinConfirmationsPaymentTimeout, "23"),
        };
    }
}