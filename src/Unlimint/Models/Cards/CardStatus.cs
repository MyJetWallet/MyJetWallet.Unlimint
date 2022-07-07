using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.Cards
{
    [DataContract]
    public enum CardStatus
    {
        Pending,
        Complete,
        Failed
    }
}