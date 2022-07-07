using System.Collections.Generic;
using MyJetWallet.Unlimint.Base;
using MyJetWallet.Unlimint.Models.ChargeBacks;

namespace MyJetWallet.Unlimint.Converters
{
    public class ChargeBackCategoryConverter : BaseConverter<ChargeBackCategory>
    {
        public ChargeBackCategoryConverter() : this(true)
        {
        }

        public ChargeBackCategoryConverter(bool quotes) : base(quotes)
        {
        }

        protected override List<KeyValuePair<ChargeBackCategory, string>> Mapping => new()
        {
            new KeyValuePair<ChargeBackCategory, string>(ChargeBackCategory.CanceledRecurringPayment, "Canceled Recurring Payment"),
            new KeyValuePair<ChargeBackCategory, string>(ChargeBackCategory.NotDefined, "Not Defined"),
            new KeyValuePair<ChargeBackCategory, string>(ChargeBackCategory.ProcessingError, "Processing Error"),
            new KeyValuePair<ChargeBackCategory, string>(ChargeBackCategory.General, "General"),
            new KeyValuePair<ChargeBackCategory, string>(ChargeBackCategory.Fraudulent, "Fraudulent"),
            new KeyValuePair<ChargeBackCategory, string>(ChargeBackCategory.CustomerDispute, "Customer Dispute"),
        };
    }
    
}