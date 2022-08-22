using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Payments;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region PaymentsAlternative

        public WebCallResult<PaymentGatewayCreationResponse> CreateAlternativePayment(
            List<string> paymentAlternativeMethods, string merchantOrderId,
            string requestId, decimal amount,
            string currency, bool useThreeDsChallengeIndicator, string description,
            string verificationUrlSuccess, string verificationUrlFailure, string verificationUrlCancel,
            string verificationUrlInProcess, string verificationUrlReturn, DateTime time,
            PaymentRequestCustomer customer, CancellationToken cancellationToken = default) =>
            CreateAlternativePaymentAsync(paymentAlternativeMethods, merchantOrderId, requestId, amount,
                currency, useThreeDsChallengeIndicator,
                description, verificationUrlSuccess, verificationUrlFailure, verificationUrlCancel,
                verificationUrlInProcess, verificationUrlReturn, time, customer, cancellationToken = default).Result;

        public async Task<WebCallResult<PaymentGatewayCreationResponse>> CreateAlternativePaymentAsync(
            List<string> methods,
            string merchantOrderId,
            string requestId,
            decimal amount,
            string currency,
            bool useThreeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            string verificationUrlCancel,
            string verificationUrlInProcess,
            string verificationUrlReturn,
            DateTime time,
            PaymentRequestCustomer customer,
            CancellationToken cancellationToken = default)
        {
            var request = CreateAlternativePaymentRequest(
                methods,
                merchantOrderId,
                requestId,
                amount,
                currency,
                useThreeDsChallengeIndicator,
                description,
                verificationUrlSuccess,
                verificationUrlFailure,
                verificationUrlCancel,
                verificationUrlInProcess,
                verificationUrlReturn,
                time,
                customer,
                cancellationToken);
            return await PostAsync<PaymentGatewayCreationResponse>($"{EndpointUrl}/payments", request,
                cancellationToken);
        }

        private PaymentRequest CreateAlternativePaymentRequest(
            List<string> paymentMethods,
            string merchantOrderId,
            string requestId,
            decimal amount,
            string currency,
            bool useThreeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            string verificationUrlCancel,
            string verificationUrlInProcess,
            string verificationUrlReturn,
            DateTime time,
            PaymentRequestCustomer customer,
            CancellationToken cancellationToken = default)
        {
            var request = new PaymentRequest
            {
                Request = new Request
                {
                    Id = requestId,
                    Time = time
                },
                MerchantOrder = new PaymentRequestMerchantOrder
                {
                    Description = description,
                    Id = merchantOrderId,
                },
                PaymentData = new PaymentRequestPaymentData
                {
                    Amount = amount.ToString(CultureInfo.InvariantCulture),
                    Currency = currency,
                    Note = description,
                    ThreeDsChallengeIndicator = useThreeDsChallengeIndicator == false ? "01" : "04"
                },
                PaymentMethod = null,
                PaymentMethods = paymentMethods,
                ReturnUrls = new ReturnUrls()
                {
                    SuccessUrl = verificationUrlSuccess,
                    DeclineUrl = verificationUrlFailure,
                    CancelUrl = verificationUrlCancel,
                    InprocessUrl = verificationUrlInProcess,
                    ReturnUrl = verificationUrlReturn
                },
                Customer = customer
            };
            return request;
        }


        public static string ToString(PaymentAlternativeType paymentAlternativeType)
        {
            string method;
            switch (paymentAlternativeType)
            {
                case PaymentAlternativeType.Boleto:
                    method = "BOLETO";
                    break;
                case PaymentAlternativeType.Baloto:
                    method = "BALOTO";
                    break;
                case PaymentAlternativeType.Davivienda:
                    method = "DAVIVIENDA";
                    break;
                case PaymentAlternativeType.Loterica:
                    method = "LOTERICA";
                    break;
                case PaymentAlternativeType.Spei:
                    method = "SPEI";
                    break;
                case PaymentAlternativeType.Oxxo:
                    method = "OXXO";
                    break;
                case PaymentAlternativeType.Efecty:
                    method = "EFECTY";
                    break;
                case PaymentAlternativeType.DepositExpressBrasil:
                    method = "DEPOSITEXPRESSBRL";
                    break;
                case PaymentAlternativeType.PagoEfectivo:
                    method = "PAGOEFECTIVO";
                    break;
                case PaymentAlternativeType.Pix:
                    method = "PIX";
                    break;
                case PaymentAlternativeType.QqCodePicPay:
                    method = "PICPAY";
                    break;
                case PaymentAlternativeType.Codi:
                    method = "CODI";
                    break;
                case PaymentAlternativeType.Pse:
                    method = "PSE";
                    break;
                case PaymentAlternativeType.Soriana:
                    method = "SORIANA";
                    break;
                case PaymentAlternativeType.ComercialMexicana:
                    method = "COMERCIALMEXICANA";
                    break;
                case PaymentAlternativeType.Bancomer:
                    method = "BANCOMER";
                    break;
                case PaymentAlternativeType.Walmart:
                    method = "WALMART";
                    break;
                case PaymentAlternativeType.BodegaAurrera:
                    method = "BODEGA";
                    break;
                case PaymentAlternativeType.SamsClub:
                    method = "SAMSCLUB";
                    break;
                case PaymentAlternativeType.Superama:
                    method = "SUPERAMA";
                    break;
                case PaymentAlternativeType.Calimax:
                    method = "CALIMAX";
                    break;
                case PaymentAlternativeType.TiendasExtra:
                    method = "EXTRA";
                    break;
                case PaymentAlternativeType.CirculoK:
                    method = "CIRCULOK";
                    break;
                case PaymentAlternativeType.SevenEleven:
                    method = "7ELEVEN";
                    break;
                case PaymentAlternativeType.Telecomm:
                    method = "TELECOMM";
                    break;
                case PaymentAlternativeType.Banorte:
                    method = "BANORTE";
                    break;
                case PaymentAlternativeType.FarmaciasBenavides:
                    method = "BENAVIDES";
                    break;
                case PaymentAlternativeType.FarmaciasdelAhorro:
                    method = "DELAHORRO";
                    break;
                case PaymentAlternativeType.ElAsturiano:
                    method = "ELASTURIANO";
                    break;
                case PaymentAlternativeType.Waldos:
                    method = "WALDOS";
                    break;
                case PaymentAlternativeType.Alsuper:
                    method = "ALSUPER";
                    break;
                case PaymentAlternativeType.Kiosko:
                    method = "KIOSKO";
                    break;
                case PaymentAlternativeType.FarmaciasSantaMaria:
                    method = "STAMARIA";
                    break;
                case PaymentAlternativeType.FarmaciasLaMasBarata:
                    method = "LAMASBARATA";
                    break;
                case PaymentAlternativeType.FarmaciasRoma:
                    method = "FARMROMA";
                    break;
                case PaymentAlternativeType.Farmacias911:
                    method = "FARM911";
                    break;
                case PaymentAlternativeType.FarmaciasEconomicas:
                    method = "FARMECONOMICAS";
                    break;
                case PaymentAlternativeType.FarmaciasMedicity:
                    method = "FARMMEDICITY";
                    break;
                case PaymentAlternativeType.Rianxeira:
                    method = "RIANXEIRA";
                    break;
                case PaymentAlternativeType.WesternUnion:
                    method = "WESTERNUNION";
                    break;
                case PaymentAlternativeType.ZonaPago:
                    method = "ZONAPAGO";
                    break;
                default:
                    throw new Exception($"Unlimited unknown method {paymentAlternativeType.ToString()}");
            }

            return method;
        }
    }

    #endregion
}