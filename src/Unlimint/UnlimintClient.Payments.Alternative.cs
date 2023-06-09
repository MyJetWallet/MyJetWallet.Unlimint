using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Payments;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region PaymentsAlternative

        public WebCallResult<PaymentGatewayCreationResponse> CreateAlternativePayment(
            string paymentMethod, string merchantOrderId,
            string requestId, decimal amount,
            string currency, bool useThreeDsChallengeIndicator, string description,
            string verificationUrlSuccess, string verificationUrlFailure, string verificationUrlCancel,
            string verificationUrlInProcess, string verificationUrlReturn, DateTime time,
            PaymentRequestCustomer customer, ShippingAddress shippingAddress = null, CancellationToken cancellationToken = default) =>
            CreateAlternativePaymentAsync(paymentMethod, merchantOrderId, requestId, amount,
                currency, useThreeDsChallengeIndicator,
                description, verificationUrlSuccess, verificationUrlFailure, verificationUrlCancel,
                verificationUrlInProcess, verificationUrlReturn, time, customer, shippingAddress = null ,cancellationToken = default).Result;

        public async Task<WebCallResult<PaymentGatewayCreationResponse>> CreateAlternativePaymentAsync(
            string paymentMethod,
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
            ShippingAddress shippingAddress = null,
            CancellationToken cancellationToken = default)
        {
            var request = CreateAlternativePaymentRequest(
                paymentMethod,
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
                shippingAddress,
                cancellationToken);
            return await PostAsync<PaymentGatewayCreationResponse>($"{EndpointUrl}/payments", request,
                cancellationToken);
        }

        private PaymentRequest CreateAlternativePaymentRequest(
            string paymentMethod,
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
            ShippingAddress shippingAddress = null,
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
                    ShippingAddress = shippingAddress,
                },
                PaymentData = new PaymentRequestPaymentData
                {
                    Amount = amount.ToString(CultureInfo.InvariantCulture),
                    Currency = currency,
                    Note = description,
                    ThreeDsChallengeIndicator = useThreeDsChallengeIndicator == false ? "01" : "04"
                },
                PaymentMethod = paymentMethod,
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
        
        public const string PaymentAlternativeTypeBoleto = "BOLETO";
        public const string PaymentAlternativeTypeBaloto = "BALOTO";
        public const string PaymentAlternativeTypeDavivienda = "DAVIVIENDA";
        public const string PaymentAlternativeTypeLoterica = "LOTERICA";
        public const string PaymentAlternativeTypeSpei = "SPEI";
        public const string PaymentAlternativeTypeOxxo = "OXXO";
        public const string PaymentAlternativeTypeEfecty = "EFECTY";
        public const string PaymentAlternativeTypeDepositExpressBrasil = "DEPOSITEXPRESSBRL";
        public const string PaymentAlternativeTypePagoEfectivo = "PAGOEFECTIVO";
        public const string PaymentAlternativeTypePix = "PIX";
        public const string PaymentAlternativeTypeQqCodePicPay = "PICPAY";
        public const string PaymentAlternativeTypeCodi = "CODI";
        public const string PaymentAlternativeTypePse = "PSE";
        public const string PaymentAlternativeTypeSoriana = "SORIANA";
        public const string PaymentAlternativeTypeComercialMexicana = "COMERCIALMEXICANA";
        public const string PaymentAlternativeTypeBancomer = "BANCOMER";
        public const string PaymentAlternativeTypeWalmart = "WALMART";
        public const string PaymentAlternativeTypeBodegaAurrera = "BODEGA";
        public const string PaymentAlternativeTypeSamsClub = "SAMSCLUB";
        public const string PaymentAlternativeTypeSuperama = "SUPERAMA";
        public const string PaymentAlternativeTypeCalimax = "CALIMAX";
        public const string PaymentAlternativeTypeTiendasExtra = "EXTRA";
        public const string PaymentAlternativeTypeCirculoK = "CIRCULOK";
        public const string PaymentAlternativeTypeSevenEleven = "7ELEVEN";
        public const string PaymentAlternativeTypeTelecomm = "TELECOMM";
        public const string PaymentAlternativeTypeBanorte = "BANORTE";
        public const string PaymentAlternativeTypeFarmaciasBenavides = "BENAVIDES";
        public const string PaymentAlternativeTypeFarmaciasdelAhorro = "DELAHORRO";
        public const string PaymentAlternativeTypeElAsturiano = "ELASTURIANO";
        public const string PaymentAlternativeTypeWaldos = "WALDOS";
        public const string PaymentAlternativeTypeAlsuper = "ALSUPER";
        public const string PaymentAlternativeTypeKiosko = "KIOSKO";
        public const string PaymentAlternativeTypeFarmaciasSantaMaria = "STAMARIA";
        public const string PaymentAlternativeTypeFarmaciasLaMasBarata = "LAMASBARATA";
        public const string PaymentAlternativeTypeFarmaciasRoma = "FARMROMA";
        public const string PaymentAlternativeTypeFarmacias911 = "FARM911";
        public const string PaymentAlternativeTypeFarmaciasEconomicas = "FARMECONOMICAS";
        public const string PaymentAlternativeTypeFarmaciasMedicity = "FARMMEDICITY";
        public const string PaymentAlternativeTypeRianxeira = "RIANXEIRA";
        public const string PaymentAlternativeTypeWesternUnion = "WESTERNUNION";
        public const string PaymentAlternativeTypeZonaPago = "ZONAPAGO";
    }

    #endregion
}