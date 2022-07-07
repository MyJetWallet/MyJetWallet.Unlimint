using System.Collections.Generic;
using MyJetWallet.Unlimint.Base;
using MyJetWallet.Unlimint.Models.Payouts;

namespace MyJetWallet.Unlimint.Converters
{
    public class PayoutStatusConverter : BaseConverter<PayoutStatus>
    {
        public PayoutStatusConverter() : this(true)
        {
        }

        public PayoutStatusConverter(bool quotes) : base(quotes)
        {
        }

        protected override List<KeyValuePair<PayoutStatus, string>> Mapping => new()
        {
            new KeyValuePair<PayoutStatus, string>(PayoutStatus.Pending, "pending"),
            new KeyValuePair<PayoutStatus, string>(PayoutStatus.Complete, "complete"),
            new KeyValuePair<PayoutStatus, string>(PayoutStatus.Failed, "failed"),
        };
    }

    
}