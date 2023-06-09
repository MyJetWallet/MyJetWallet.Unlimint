using System.Collections.Generic;
using MyJetWallet.Unlimint.Models.Payments;
using MyJetWallet.Unlimint.Base;

namespace MyJetWallet.Unlimint.Converters
{
    public class TransTypeEnumConverter : BaseConverter<TransTypeEnum>
    {
        public TransTypeEnumConverter() : this(true)
        {
        }

        public TransTypeEnumConverter(bool quotes) : base(quotes)
        {
        }

        protected override List<KeyValuePair<TransTypeEnum, string>> Mapping => new()
        {
            new KeyValuePair<TransTypeEnum, string>(TransTypeEnum._01, "01"),
            new KeyValuePair<TransTypeEnum, string>(TransTypeEnum._03, "03"),
            new KeyValuePair<TransTypeEnum, string>(TransTypeEnum._10, "10"),
            new KeyValuePair<TransTypeEnum, string>(TransTypeEnum._11, "11"),
            new KeyValuePair<TransTypeEnum, string>(TransTypeEnum._28, "28"),
        };
    }
    
}