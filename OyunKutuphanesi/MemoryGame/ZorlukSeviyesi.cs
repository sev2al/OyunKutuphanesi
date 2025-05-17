using System;

namespace OyunKutuphanesi.HafizaOyunu
{
    public abstract class ZorlukSeviyesi
    {
        public string Ad { get; protected set; }
        public int SatirSayisi { get; protected set; }
        public int SutunSayisi { get; protected set; }
        public int KartCiftSayisi { get; protected set; }
        public int PuanCarpani { get; protected set; }

        public abstract int SkorHesapla(int sure, int hamle);
    }

    public class KolayZorluk : ZorlukSeviyesi
    {
        public KolayZorluk()
        {
            Ad = "Kolay";
            SatirSayisi = 4;
            SutunSayisi = 4;
            KartCiftSayisi = 8;
            PuanCarpani = 1;
        }

        public override int SkorHesapla(int sure, int hamle)
        {
            return (1000 - sure) + (KartCiftSayisi * 100) - (hamle * 10);
        }
    }

    public class OrtaZorluk : ZorlukSeviyesi
    {
        public OrtaZorluk()
        {
            Ad = "Orta";
            SatirSayisi = 4;
            SutunSayisi = 6;
            KartCiftSayisi = 12;
            PuanCarpani = 2;
        }

        public override int SkorHesapla(int sure, int hamle)
        {
            return ((1000 - sure) + (KartCiftSayisi * 100) - (hamle * 10)) * PuanCarpani;
        }
    }

    public class ZorZorluk : ZorlukSeviyesi
    {
        public ZorZorluk()
        {
            Ad = "Zor";
            SatirSayisi = 6;
            SutunSayisi = 6;
            KartCiftSayisi = 18;
            PuanCarpani = 3;
        }

        public override int SkorHesapla(int sure, int hamle)
        {
            return ((1000 - sure) + (KartCiftSayisi * 100) - (hamle * 10)) * PuanCarpani;
        }
    }
} 