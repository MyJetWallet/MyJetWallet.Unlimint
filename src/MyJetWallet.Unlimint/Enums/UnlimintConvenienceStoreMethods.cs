using System.Linq;

namespace MyJetWallet.Unlimint.Enums;

public class UnlimintConvenienceStoreMethods
{
    public const string Soriana = "SORIANA";
    public const string ComercialMexicana = "COMERCIALMEXICANA";
    public const string Bancomer = "BANCOMER";
    public const string Walmart = "WALMART";
    public const string BodegaAurrera = "BODEGA";
    public const string SamsClub = "SAMSCLUB";
    public const string Superama = "SUPERAMA";
    public const string Calimax = "CALIMAX";
    public const string TiendasExtra = "EXTRA";
    public const string CirculoK = "CIRCULOK";
    public const string SevenEleven = "7ELEVEN";
    public const string Telecomm = "TELECOMM";
    public const string Banorte = "BANORTE";
    public const string FarmaciasBenavides = "BENAVIDES";
    public const string FarmaciasdelAhorro = "DELAHORRO";
    public const string ElAsturiano = "ELASTURIANO";
    public const string Waldos = "WALDOS";
    public const string Alsuper = "ALSUPER";
    public const string Kiosko = "KIOSKO";
    public const string FarmaciasSantaMaria = "STAMARIA";
    public const string FarmaciasLaMasBarata = "LAMASBARATA";
    public const string FarmaciasRoma = "FARMROMA";
    public const string Farmacias911 = "FARM911";
    public const string FarmaciasEconomicas = "FARMECONOMICAS";
    public const string FarmaciasMedicity = "FARMMEDICITY";
    public const string Rianxeira = "RIANXEIRA";
    public const string WesternUnion = "WESTERNUNION";
    public const string ZonaPago = "ZONAPAGO";
    public const string Cashmx = "CASHMX";
    public const string Farmatodo = "FARMATODO";
    public const string Farmunion = "FARMUNION";
    public const string Paycash = "PAYCASH";
    public const string Paynet = "PAYNET";
    public const string Sfdeasis = "SFDEASIS";

    public static string[] Methods => new[]
        {
            Soriana,
            ComercialMexicana,
            Bancomer,
            Walmart,
            BodegaAurrera,
            SamsClub,
            Superama,
            Calimax,
            TiendasExtra,
            CirculoK,
            SevenEleven,
            Telecomm,
            Banorte,
            FarmaciasBenavides,
            FarmaciasdelAhorro,
            ElAsturiano,
            Waldos,
            Alsuper,
            Kiosko,
            FarmaciasSantaMaria,
            FarmaciasLaMasBarata,
            FarmaciasRoma,
            Farmacias911,
            FarmaciasEconomicas,
            FarmaciasMedicity,
            Rianxeira,
            WesternUnion,
            ZonaPago,
            Cashmx,
            Farmatodo,
            Farmunion,
            Paycash,
            Paynet,
            Sfdeasis,
        }
        .Distinct().OrderBy(x => x).ToArray();
}