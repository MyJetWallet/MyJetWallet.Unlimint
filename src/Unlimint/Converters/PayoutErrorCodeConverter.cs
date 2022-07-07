using System.Collections.Generic;
using MyJetWallet.Unlimint.Models.Payments;
using MyJetWallet.Unlimint.Base;
using MyJetWallet.Unlimint.Models.Payouts;

namespace MyJetWallet.Unlimint.Converters
{
    public class PayoutErrorCodeConverter : BaseConverter<PayoutErrorCode>
    {
        public PayoutErrorCodeConverter() : this(true)
        {
        }

        public PayoutErrorCodeConverter(bool quotes) : base(quotes)
        {
        }

        protected override List<KeyValuePair<PayoutErrorCode, string>> Mapping => new()
        {
            new KeyValuePair<PayoutErrorCode, string>(PayoutErrorCode.BankTransactionError, "bank_transaction_error"),
            new KeyValuePair<PayoutErrorCode, string>(PayoutErrorCode.InvalidWireRtn, "invalid_wire_rtn"),
            new KeyValuePair<PayoutErrorCode, string>(PayoutErrorCode.InvalidAchRtn, "invalid_ach_rtn"),

            new KeyValuePair<PayoutErrorCode, string>(PayoutErrorCode.InsufficientFunds, "insufficient_funds"),
            new KeyValuePair<PayoutErrorCode, string>(PayoutErrorCode.TransactionDenied, "transaction_denied"),
            new KeyValuePair<PayoutErrorCode, string>(PayoutErrorCode.TransactionFailed, "transaction_failed"),
            new KeyValuePair<PayoutErrorCode, string>(PayoutErrorCode.TransactionReturned, "transaction_returned"),
            new KeyValuePair<PayoutErrorCode, string>(PayoutErrorCode.FiatAccountLimitExceeded, "fiat_account_limit_exceeded"),
            new KeyValuePair<PayoutErrorCode, string>(PayoutErrorCode.InvalidBankAccountNumber, "invalid_bank_account_number"),
            new KeyValuePair<PayoutErrorCode, string>(PayoutErrorCode.VendorInactive, "vendor_inactive"),
        };
    }
    
}