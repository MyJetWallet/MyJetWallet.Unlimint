using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.Cards
{
    [DataContract]
    public enum CardFundingType
    {
        Credit,
        Debit,
        Prepaid,
        Unknown
    }
}