using System.Collections.Generic;
using System.Runtime.Serialization;
using MyJetWallet.Unlimint.Base;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public enum AcctTypeEnum
{
    NotApplicable,
    Credit,
    Debit
};