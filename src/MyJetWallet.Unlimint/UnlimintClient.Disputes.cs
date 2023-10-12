using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Payments;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MyJetWallet.Unlimint;

public partial class UnlimintClient
{
    #region Disputes

    public async Task<WebCallResult<DisputeInfos>> GetDisputesInfo(
        DisputeInfoRequest request,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new Dictionary<string, string>();

        // Add query parameters based on the DisputeInfoRequest properties
        if (request.MaxCount > 0)
        {
            queryParams.Add("max_count", request.MaxCount.ToString());
        }

        if (request.Offset > 0)
        {
            queryParams.Add("offset", request.Offset.ToString());
        }

        if (!string.IsNullOrWhiteSpace(request.RegistrationEndTime))
        {
            queryParams.Add("reg_end_time", request.RegistrationEndTime);
        }

        if (!string.IsNullOrWhiteSpace(request.RegistrationStartTime))
        {
            queryParams.Add("reg_start_time", request.RegistrationStartTime);
        }

        if (!string.IsNullOrWhiteSpace(request.SortOrder))
        {
            queryParams.Add("sort_order", request.SortOrder);
        }

        if (!string.IsNullOrWhiteSpace(request.RequestId))
        {
            queryParams.Add("request_id", request.RequestId);
        }

        if (!string.IsNullOrWhiteSpace(request.Type.ToString()))
        {
            queryParams.Add("type", request.Type.ToString());
        }

        // Build the query string
        string queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}"));

        // Construct the full URL with query parameters
        string apiUrl = $"{EndpointUrl}/disputes";
        if (!string.IsNullOrEmpty(queryString))
        {
            apiUrl += $"?{queryString}";
        }

        // Make the GET request with the constructed URL
        return await GetAsync<DisputeInfos>(apiUrl, cancellationToken);
    }
    
    #endregion
}