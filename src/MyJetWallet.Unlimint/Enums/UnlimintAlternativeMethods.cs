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
    public const string Pse = "PSE";
    public const string ConvenienceStore = "CONVENIENCESSTORE";

    
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
            Pse,
            ConvenienceStore
        }
        .Distinct().OrderBy(x => x).ToArray();
    
}