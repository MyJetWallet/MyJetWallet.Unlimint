using System.Collections.Generic;
using MyJetWallet.Unlimint.Base;
using MyJetWallet.Unlimint.Models.Payments;

namespace MyJetWallet.Unlimint.Converters
{
    public class PaymentStatusConverter : BaseConverter<PaymentStatus>
    {
        public PaymentStatusConverter() : this(true)
        {
        }

        public PaymentStatusConverter(bool quotes) : base(quotes)
        {
        }

        protected override List<KeyValuePair<PaymentStatus, string>> Mapping => new()
        {
            new KeyValuePair<PaymentStatus, string>(PaymentStatus.New, "NEW"),
            new KeyValuePair<PaymentStatus, string>(PaymentStatus.InProgress, "IN_PROGRESS"),
            new KeyValuePair<PaymentStatus, string>(PaymentStatus.Declined, "DECLINED"),
            new KeyValuePair<PaymentStatus, string>(PaymentStatus.Authorized, "AUTHORIZED"),
            new KeyValuePair<PaymentStatus, string>(PaymentStatus.Completed, "COMPLETED"),
            new KeyValuePair<PaymentStatus, string>(PaymentStatus.Refunded, "REFUNDED"),
            new KeyValuePair<PaymentStatus, string>(PaymentStatus.Voided, "VOIDED"),
            new KeyValuePair<PaymentStatus, string>(PaymentStatus.Terminated, "TERMINATED"),
            new KeyValuePair<PaymentStatus, string>(PaymentStatus.ChargedBack, "CHARGED_BACK"),
            new KeyValuePair<PaymentStatus, string>(PaymentStatus.ChargedBackResolved, "CHARGEBACK_RESOLVED")
        };
    }
}
