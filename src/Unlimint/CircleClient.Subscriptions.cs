using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Subscriptions;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        /// <summary>
        /// Get a list of notification subscriptions.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// 
        public WebCallResult<List<Subscription>>
            GetListOfSubscriptions(CancellationToken cancellationToken = default) =>
            GetListOfSubscriptionsAsync(cancellationToken).Result;

        public async Task<WebCallResult<List<Subscription>>> GetListOfSubscriptionsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<List<Subscription>>($"{EndpointUrl}/notifications/subscriptions", cancellationToken);
        }

        /// <summary>
        /// Subscribe to receiving notifications at a given endpoint. The endpoint should be able to handle AWS SNS subscription requests. For more details see https://docs.aws.amazon.com/mobile/sdkforxamarin/developerguide/sns-send-http.html.
        /// Note, the sandbox environment allows a maximum of 3 active subscriptions; otherwise, this is limited to 1 active subscription and subsequent create requests will be rejected with a Limit Exceeded error.
        /// </summary>
        /// <param name="endpoint">URL of the subscriber endpoint. Must be publicly accessible and utilize HTTPS.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public WebCallResult<Subscription> CreateSubscription(string endpoint,
            CancellationToken cancellationToken = default) =>
            CreateSubscriptionAsync(endpoint, cancellationToken).Result;

        public async Task<WebCallResult<Subscription>> CreateSubscriptionAsync(string endpoint,
            CancellationToken cancellationToken = default)
        {
            var data = new
            {
                endpoint,
            };
            return await PostAsync<Subscription>($"{EndpointUrl}/notifications/subscriptions", data, cancellationToken);
        }

        /// <summary>
        /// To remove a subscription, all its subscription requests' statuses must be either 'confirmed', 'deleted' or a combination of those. A subscription with at least one 'pending' subscription request cannot be removed.
        /// </summary>
        /// <param name="id">Unique identifier for the subscription.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public WebCallResult<string> RemoveSubscription(string id, CancellationToken cancellationToken = default) =>
            RemoveSubscriptionAsync(id, cancellationToken).Result;

        public async Task<WebCallResult<string>> RemoveSubscriptionAsync(string id,
            CancellationToken cancellationToken = default)
        {
            return await DeleteAsync<string>($"{EndpointUrl}/notifications/subscriptions/{id}", null,
                cancellationToken);
        }
    }
}