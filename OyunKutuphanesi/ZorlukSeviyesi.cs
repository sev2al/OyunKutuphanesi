using System;

namespace OyunKutuphanesi
{
    public abstract class ZorlukSeviyesi
    {
        public abstract int KartCiftSayisi { get; }
        public abstract int SatirSayisi { get; }
        public abstract int SutunSayisi { get; }

        public virtual int SkorHesapla(int sure, int hamleSayisi)
        {
            // Temel skor hesaplama
            int maxSure = 180; // 3 dakika
            int maxHamle = KartCiftSayisi * 3; // Her çift için ortalama 3 hamle

            int surePuani = Math.Max(0, (maxSure - sure) * 10);
            int hamlePuani = Math.Max(0, (maxHamle - hamleSayisi) * 20);

            return surePuani + hamlePuani;
        }
    }

    public class KolayZorluk : ZorlukSeviyesi
    {
        public override int KartCiftSayisi => 4; // 8 kart
        public override int SatirSayisi => 2;
        public override int SutunSayisi => 4;

        public override int SkorHesapla(int sure, int hamleSayisi)
        {
            return base.SkorHesapla(sure, hamleSayisi);
        }
    }

    public class OrtaZorluk : ZorlukSeviyesi
    {
        public override int KartCiftSayisi => 6; // 12 kart
        public override int SatirSayisi => 3;
        public override int SutunSayisi => 4;

        public override int SkorHesapla(int sure, int hamleSayisi)
        {
            // Orta zorluk için %20 bonus
            return (int)(base.SkorHesapla(sure, hamleSayisi) * 1.2);
        }
    }

    public class ZorZorluk : ZorlukSeviyesi
    {
        public override int KartCiftSayisi => 8; // 16 kart
        public override int SatirSayisi => 4;
        public override int SutunSayisi => 4;

        public override int SkorHesapla(int sure, int hamleSayisi)
        {
            // Zor zorluk için %50 bonus
            return (int)(base.SkorHesapla(sure, hamleSayisi) * 1.5);
        }
    }
} 