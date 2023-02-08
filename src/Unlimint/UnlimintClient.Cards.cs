using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Payments;
using System.Linq;
using System.Security.Principal;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region Cards

        public async Task<WebCallResult<List<CardInfo>>> GetCardInfoAsync(
            CardBinRequest cardBinRequest, CancellationToken cancellationToken = default)
        {
            return await PostAsync<List<CardInfo>>($"{EndpointUrl}/card_info", cardBinRequest, cancellationToken);
        }
    }

    #endregion
}