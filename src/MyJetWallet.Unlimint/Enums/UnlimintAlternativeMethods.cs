using System.Linq;

namespace MyJetWallet.Unlimint.Enums;

public class UnlimintAlternativeMethods
{
    public const string Boleto = "BOLETO";
    public const string Baloto = "BALOTO";
    public const string Davivienda = "DAVIVIENDA";
    public const string Loterica = "LOTERICA";
    public const string Spei = "SPEI";
    public const string Oxxo = "OXXO";
    public const string Efecty = "EFECTY";
    public const string DepositExpressBrasil = "DEPOSITEXPRESSBRL";
    public const string PagoEfectivo = "PAGOEFECTIVO";
    public const string Pix = "PIX";
    public const string QqCodePicPay = "PICPAY";
    public const string Codi = "CODI";
    public const string DirectBankingEurope = "DIRECTBANKINGEU";
    public const string Pse = "PSE";
    public const string Ovo = "OVO";
    public const string Dana = "DANA";
    public const string ConvenienceStore = "CONVENIENCESTORE";

    public static string[] Methods => new[]
        {
            Boleto,
            Baloto,
            Davivienda,
            Loterica,
            Spei,
            Oxxo,
            Efecty,
            DepositExpressBrasil,
            PagoEfectivo,
            Pix,
            QqCodePicPay,
            Codi,
            DirectBankingEurope,
            Pse,
            Ovo,
            Dana,
            ConvenienceStore
        }
        .Distinct().OrderBy(x => x).ToArray();
    
}