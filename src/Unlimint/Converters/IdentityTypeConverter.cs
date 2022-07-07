using System.Collections.Generic;
using MyJetWallet.Unlimint.Base;
using MyJetWallet.Unlimint.Models.Transfers;

namespace MyJetWallet.Unlimint.Converters
{
    public class IdentityTypeConverter : BaseConverter<IdentityType>
    {
        public IdentityTypeConverter() : this(true)
        {
        }

        public IdentityTypeConverter(bool quotes) : base(quotes)
        {
        }

        protected override List<KeyValuePair<IdentityType, string>> Mapping => new()
        {
            new KeyValuePair<IdentityType, string>(IdentityType.Business, "business"),
            new KeyValuePair<IdentityType, string>(IdentityType.Individual, "individual"),

        };
    }
}