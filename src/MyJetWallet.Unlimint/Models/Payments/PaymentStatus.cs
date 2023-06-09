namespace MyJetWallet.Unlimint.Models.Payments
{
    public enum PaymentStatus
    {
        New,
        InProgress,
        Declined,
        Authorized,
        Completed,
        Cancelled,
        Refunded,
        Voided,
        Terminated,
        ChargedBack,
        ChargedBackResolved
    }
}