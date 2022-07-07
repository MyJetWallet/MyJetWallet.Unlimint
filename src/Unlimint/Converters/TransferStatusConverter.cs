using System.Collections.Generic;
using MyJetWallet.Unlimint.Models.Cards;
using MyJetWallet.Unlimint.Base;
using MyJetWallet.Unlimint.Models.Transfers;

namespace MyJetWallet.Unlimint.Converters
{
    public class TransferStatusConverter : BaseConverter<TransferStatus>
    {
        public TransferStatusConverter() : this(true)
        {
        }

        public TransferStatusConverter(bool quotes) : base(quotes)
        {
        }

        protected override List<KeyValuePair<TransferStatus, string>> Mapping => new()
        {
            new KeyValuePair<TransferStatus, string>(TransferStatus.Pending, "pending"),
            new KeyValuePair<TransferStatus, string>(TransferStatus.Complete, "complete"),
            new KeyValuePair<TransferStatus, string>(TransferStatus.Failed, "failed"),
        };
    }
}