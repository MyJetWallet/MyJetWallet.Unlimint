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
using MyJetWallet.Unlimint.Models.Banks;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region Banks

        public async Task<WebCallResult<BanksResponse>> GetBanksAsync(string method, string currency, string country, CancellationToken cancellationToken = default)
        {
            var url = $"{EndpointUrl}/banks/{method}/{currency}";

            if (country != null)
            {
                url += $"?country={country}";
            }
            
            return await GetAsync<BanksResponse>(url, cancellationToken);
        }
        
        #endregion
    }
}