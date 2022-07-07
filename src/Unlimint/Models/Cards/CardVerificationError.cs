using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.Cards
{
    [DataContract]
    public enum CardVerificationError
    {
        VerificationFailed,
        VerificationFraudDetected,
        RiskDenied,
        VerificationNotSupportedByIssuer,
        VerificationStoppedByIssuer,
        CardFailed,
        CardInvalid,
        CardAddressMismatch,
        CardZipMismatch,
        CardCvvInvalid,
        CardExpired,
        CardLimitViolated,
        CardNotHonored,
        CardCvvRequired,
        CreditCardNotAllowed,
        CardAccountIneligible,
        CardNetworkUnsupported,
        ThreeDSecureNotSupported,
        ThreeDSecureRequired,
        ThreeDSecureFailure,
        ThreeDSecureActionExpired,
        ThreeDSecureInvalidRequest,
    }
}