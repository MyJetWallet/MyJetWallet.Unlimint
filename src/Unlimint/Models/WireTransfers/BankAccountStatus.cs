namespace MyJetWallet.Unlimint.Models.WireTransfers
{
    public enum BankAccountStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"pending")]
        Pending,
        [System.Runtime.Serialization.EnumMember(Value = @"complete")]
        Complete,
        [System.Runtime.Serialization.EnumMember(Value = @"failed")]
        Failed,
    }
}
