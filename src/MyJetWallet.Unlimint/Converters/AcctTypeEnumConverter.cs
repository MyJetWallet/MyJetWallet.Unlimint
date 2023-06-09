using System.Collections.Generic;
using MyJetWallet.Unlimint.Models.Payments;
using MyJetWallet.Unlimint.Base;

namespace MyJetWallet.Unlimint.Converters
{
    public class AcctTypeEnumConverter : BaseConverter<AcctTypeEnum>
    {
        public AcctTypeEnumConverter() : this(true)
        {
        }

        public AcctTypeEnumConverter(bool quotes) : base(quotes)
        {
        }

        protected override List<KeyValuePair<AcctTypeEnum, string>> Mapping => new()
        {
            new KeyValuePair<AcctTypeEnum, string>(AcctTypeEnum.NotApplicable, "01"),
            new KeyValuePair<AcctTypeEnum, string>(AcctTypeEnum.Credit, "02"),
            new KeyValuePair<AcctTypeEnum, string>(AcctTypeEnum.Debit, "03"),
        };
    }
    
}