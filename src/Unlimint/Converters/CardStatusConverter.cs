using System.Collections.Generic;
using MyJetWallet.Unlimint.Base;
using MyJetWallet.Unlimint.Models.Cards;

namespace MyJetWallet.Unlimint.Converters
{
    public class CardStatusConverter : BaseConverter<CardStatus>
    {
        public CardStatusConverter() : this(true)
        {
        }

        public CardStatusConverter(bool quotes) : base(quotes)
        {
        }

        protected override List<KeyValuePair<CardStatus, string>> Mapping => new()
        {
            new KeyValuePair<CardStatus, string>(CardStatus.Pending, "pending"),
            new KeyValuePair<CardStatus, string>(CardStatus.Complete, "complete"),
            new KeyValuePair<CardStatus, string>(CardStatus.Failed, "failed"),
        };
    }
}