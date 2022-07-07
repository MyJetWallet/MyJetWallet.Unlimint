using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Cards;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region Cards

        /// <summary>
        /// Create a card.
        /// </summary>
        /// <param name="idempotencyKey">Unique idempotency key. This key is utilized to ensure exactly-once execution of mutating requests.</param>
        /// <param name="keyId">Unique identifier of the public key used in encryption.</param>
        /// <param name="encryptedData">PGP encrypted json string. The object format given here needs to be stringified and PGP encrypted before it is sent to the server, so encryptedData will end up as a string, rather than an object.</param>
        /// <param name="billingName">Full name of the card or bank account holder.</param>
        /// <param name="billingCity">City portion of the address.</param>
        /// <param name="billingCountry">Country portion of the address. Formatted as a two-letter country code specified in ISO 3166-1 alpha-2.</param>
        /// <param name="billingLine1">Line one of the street address.</param>
        /// <param name="billingLine2">Line two of the street address.</param>
        /// <param name="billingDistrict">State / County / Province / Region portion of the address. If the country is US or Canada district is required and should use the two-letter code for the subdivision.</param>
        /// <param name="billingPostalCode">Postal / ZIP code of the address.</param>
        /// <param name="expMonth">Two digit number representing the card's expiration month.</param>
        /// <param name="expYear">Four digit number representing the card's expiration year.</param>
        /// <param name="email">Email of the user</param>
        /// <param name="phoneNumber">Phone number of the user in E.164 format. We recommend using a library such as libphonenumber to parse and validate phone numbers.</param>
        /// <param name="sessionId">Hash of the session identifier; typically of the end user. This helps us make risk decisions and prevent fraud. IMPORTANT: Please hash the session identifier to prevent sending us actual session identifiers.</param>
        /// <param name="ipAddress">Single IPv4 or IPv6 address of user</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public WebCallResult<CardInfo> CreateCard(
            string idempotencyKey,
            string keyId,
            string encryptedData,
            string billingName,
            string billingCity,
            string billingCountry,
            string billingLine1,
            string billingLine2,
            string billingDistrict,
            string billingPostalCode,
            int expMonth,
            int expYear,
            string email,
            string phoneNumber,
            string sessionId,
            string ipAddress,
            CancellationToken cancellationToken = default) => CreateCardAsync(idempotencyKey, keyId, encryptedData,
            billingName, billingCity, billingCountry, billingLine1, billingLine2, billingDistrict, billingPostalCode,
            expMonth, expYear, email, phoneNumber, sessionId, ipAddress, cancellationToken).Result;

        public async Task<WebCallResult<CardInfo>> CreateCardAsync(
            string idempotencyKey,
            string keyId,
            string encryptedData,
            string billingName,
            string billingCity,
            string billingCountry,
            string billingLine1,
            string billingLine2,
            string billingDistrict,
            string billingPostalCode,
            int expMonth,
            int expYear,
            string email,
            string phoneNumber,
            string sessionId,
            string ipAddress,
            CancellationToken cancellationToken = default)
        {
            var data = new CreateCardRequest()
            {
                IdempotencyKey = idempotencyKey,
                KeyId = keyId,
                EncryptedData = encryptedData,
                BillingDetails = new CardBillingDetails
                {
                    Name = billingName,
                    City = billingCity,
                    Country = billingCountry,
                    District = billingDistrict,
                    Line1 = billingLine1,
                    Line2 = billingLine2,
                    PostalCode = billingPostalCode
                },
                ExpMonth = expMonth,
                ExpYear = expYear,
                Metadata = new Metadata
                {
                    Email = email,
                    PhoneNumber = phoneNumber,
                    SessionId = sessionId,
                    IpAddress = ipAddress
                }
            };
            return await PostAsync<CardInfo>($"{EndpointUrl}/cards", data, cancellationToken);
        }

        /// <summary>
        /// List receive addresses on a wallet
        /// </summary>
        /// <param name="pageBefore">It marks the exclusive end of a page. When provided, the collection resource will return the next n items before the id, with n being specified by pageSize.</param>
        /// <param name="pageAfter">It marks the exclusive begin of a page. When provided, the collection resource will return the next n items after the id, with n being specified by pageSize.</param>
        /// <param name="pageSize">Limits the number of items to be returned.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public WebCallResult<List<CardInfo>> GetListOfCards(
            string pageBefore,
            string pageAfter,
            int pageSize,
            CancellationToken cancellationToken = default) =>
            GetListOfCardsAsync(pageBefore, pageAfter, pageSize, cancellationToken).Result;

        public async Task<WebCallResult<List<CardInfo>>> GetListOfCardsAsync(
            string pageBefore,
            string pageAfter,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            var query = ConvertToQueryString(new Dictionary<string, object>()
            {
                { "pageBefore", pageBefore },
                { "pageAfter", pageAfter },
                { "pageSize", pageSize }
            });

            return await GetAsync<List<CardInfo>>($"{EndpointUrl}/cards" + query, cancellationToken);
        }

        /// <summary>
        /// Get a card.
        /// </summary>
        /// <param name="id">It marks the exclusive end of a page. When provided, the collection resource will return the next n items before the id, with n being specified by pageSize.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public WebCallResult<CardInfo> GetCard(
            string id,
            CancellationToken cancellationToken = default) =>
            GetCardAsync(id, cancellationToken).Result;

        public async Task<WebCallResult<CardInfo>> GetCardAsync(
            string id,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<CardInfo>($"{EndpointUrl}/cards/{id}", cancellationToken);
        }


        /// <summary>
        /// Update a card.
        /// </summary>
        /// <param name="id">Unique identifier of the card.</param>
        /// <param name="keyId">Unique identifier of the public key used in encryption.</param>
        /// <param name="encryptedData">PGP encrypted json string. The object format given here needs to be stringified and PGP encrypted before it is sent to the server, so encryptedData will end up as a string, rather than an object.</param>
        /// <param name="expMonth">Two digit number representing the card's expiration month.</param>
        /// <param name="expYear">Four digit number representing the card's expiration year.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public WebCallResult<CardInfo> UpdateCard(
            string id,
            string keyId,
            string encryptedData,
            int expMonth,
            int expYear,
            CancellationToken cancellationToken = default) =>
            UpdateCardAsync(id, keyId, encryptedData, expMonth, expYear, cancellationToken).Result;

        public async Task<WebCallResult<CardInfo>> UpdateCardAsync(
            string id,
            string keyId,
            string encryptedData,
            int expMonth,
            int expYear,
            CancellationToken cancellationToken = default)
        {
            var data = new UpdateCardRequest()
            {
                KeyId = keyId,
                EncryptedData = encryptedData,
                ExpMonth = expMonth,
                ExpYear = expYear
            };
            return await PutAsync<CardInfo>($"{EndpointUrl}/cards/{id}", data, cancellationToken);
        }

        #endregion
    }
}