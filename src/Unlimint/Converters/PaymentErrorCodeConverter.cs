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
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.PaymentFailed, "payment_failed"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.PaymentFraudDetected, "payment_fraud_detected"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.PaymentDenied, "payment_denied"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.PaymentNotSupportedByIssuer,
                "payment_not_supported_by_issuer"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.PaymentNotFunded, "payment_not_funded"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.PaymentUnprocessable, "payment_unprocessable"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.PaymentStoppedByIssuer,
                "payment_stopped_by_issuer"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.PaymentCanceled, "payment_canceled"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.PaymentReturned, "payment_returned"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.PaymentFailedBalanceCheck,
                "payment_failed_balance_check"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardFailed, "card_failed"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardInvalid, "card_invalid"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardAddressMismatch, "card_address_mismatch"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardZipMismatch, "card_zip_mismatch"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardCvvInvalid, "card_cvv_invalid"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardExpired, "card_expired"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardLimitViolated, "card_limit_violated"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardNotHonored, "card_not_honored"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardCvvRequired, "card_cvv_required"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CreditCardNotAllowed,
                "credit_card_not_allowed"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardAccountIneligible,
                "card_account_ineligible"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardNetworkUnsupported,
                "card_network_unsupported"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.ChannelInvalid, "channel_invalid"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.UnauthorizedTransaction,
                "unauthorized_transaction"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.BankAccountIneligible,
                "bank_account_ineligible"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.BankTransactionError, "bank_transaction_error"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.RefIdInvalid, "ref_id_invalid"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.AccountNameMismatch, "account_name_mismatch"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.AccountIneligible, "account_ineligible"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.WalletAddressMismatch, "wallet_address_mismatch"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CustomerNameMismatch, "customer_name_mismatch"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.InstitutionNameMismatch, "institution_name_mismatch"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.InvalidAccountNumber, "invalid_account_number"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.InvalidWireRtn, "invalid_wire_rtn"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.InvalidAchRtn, "invalid_ach_rtn"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.VerificationFailed, "verification_failed"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.VerificationFraudDetected, "verification_fraud_detected"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.VerificationDenied, "verification_denied"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.VerificationNotSupportedByIssuer, "verification_not_supported_by_issuer"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.VerificationStoppedByIssuer, "verification_stopped_by_issuer"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.ThreeDSecureNotSupported, "three_d_secure_not_supported"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.ThreeDSecureRequired, "three_d_secure_required"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.ThreeDSecureFailure, "three_d_secure_failure"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.ThreeDSecureActionExpired, "three_d_secure_action_expired"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.ThreeDSecureInvalidRequest, "three_d_secure_invalid_request"),
            new KeyValuePair<PaymentErrorCode, string>(PaymentErrorCode.CardRestricted, "card_restricted"),

        };
    }
}