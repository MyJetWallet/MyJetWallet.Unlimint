using System.Collections.Generic;
using MyJetWallet.Unlimint.Base;
using MyJetWallet.Unlimint.Models.BusinessAccounts;

namespace MyJetWallet.Unlimint.Converters
{
    public class DepositStatusConverter : BaseConverter<DepositStatus>
    {
        public DepositStatusConverter() : this(true)
        {
        }

        public DepositStatusConverter(bool quotes) : base(quotes)
        {
        }

        protected override List<KeyValuePair<DepositStatus, string>> Mapping => new()
        {
            new KeyValuePair<DepositStatus, string>(DepositStatus.Pending, "pending"),
            new KeyValuePair<DepositStatus, string>(DepositStatus.Complete, "complete"),
            new KeyValuePair<DepositStatus, string>(DepositStatus.Failed, "failed"),
        };
    }
}