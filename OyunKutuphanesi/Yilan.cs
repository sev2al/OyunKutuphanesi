using System;
using System.Collections.Generic;
using System.Drawing;

namespace OyunKutuphanesi
{
    // Yılanın temel özellikleri ve hareketi
    public abstract class Yilan
    {
        public List<Point> Govde { get; set; } = new List<Point>();
        public string Yon { get; set; } = "Sag";
        public abstract void HareketEt();
        public abstract void Buyu();
    }

    // Standart yılan
    public class StandartYilan : Yilan
    {
        public override void HareketEt() { /* Standart hareket mantığı ana formda */ }
        public override void Buyu() { /* Standart büyüme ana formda */ }
    }

    // Hızlı yılan (her tick'te iki kare ilerler)
    public class HizliYilan : Yilan
    {
        public override void HareketEt() { /* Hızlı hareket mantığı ana formda */ }
        public override void Buyu() { /* Standart büyüme */ }
    }

    // Yavaş yılan (her iki tick'te bir hareket eder)
    public class YavasYilan : Yilan
    {
        private int tickSayac = 0;
        public override void HareketEt() { tickSayac++; /* Yavaş hareket mantığı ana formda */ }
        public override void Buyu() { /* Standart büyüme */ }
    }

    // Uzayan yılan (her yem yediğinde iki kare büyür)
    public class UzayanYilan : Yilan
    {
        public override void HareketEt() { /* Standart hareket */ }
        public override void Buyu() { /* Uzun büyüme ana formda */ }
    }

    // Yemek nesnesi
    public class Yemek
    {
        public Point Konum { get; set; }
        public void YeniKonum(int genislik, int yukseklik) { /* Rastgele konum üretilecek */ }
    }

    // Oyun alanı ve temel kontrol
    public class OyunAlani
    {
        public int Genislik { get; set; }
        public int Yukseklik { get; set; }
        public Yilan Yilan { get; set; }
        public Yemek Yemek { get; set; }
        public int Skor { get; set; }
        public void Baslat() { /* Oyun başlatma mantığı */ }
        public void Guncelle() { /* Oyun güncelleme mantığı */ }
        public bool OyunBittiMi() { return false; /* Çarpışma kontrolü */ }
    }

    // Zorluk seviyesi base class
    public abstract class ZorlukModu
    {
        public abstract int Hiz { get; }
        public abstract int AlanGenisligi { get; }
        public abstract int AlanYuksekligi { get; }
    }

    public class YilanKolayMod : ZorlukModu
    {
        public override int Hiz => 150; // ms cinsinden
        public override int AlanGenisligi => 30;
        public override int AlanYuksekligi => 30;
    }
    public class YilanOrtaMod : ZorlukModu
    {
        public override int Hiz => 100;
        public override int AlanGenisligi => 30;
        public override int AlanYuksekligi => 30;
    }
    public class YilanZorMod : ZorlukModu
    {
        public override int Hiz => 60;
        public override int AlanGenisligi => 30;
        public override int AlanYuksekligi => 30;
    }
} 