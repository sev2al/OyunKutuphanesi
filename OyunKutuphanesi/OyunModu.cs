using System;
using System.Collections.Generic;

namespace OyunKutuphanesi
{
    // Temel oyun modu sınıfı (base class)
    public abstract class OyunModu
    {
        public List<string> Kelimeler { get; protected set; }
        public int MaksimumKelimeUzunlugu { get; protected set; }
        public int MinimumKelimeUzunlugu { get; protected set; }

        protected OyunModu()
        {
            Kelimeler = new List<string>();
            KelimeleriYukle();
        }

        protected abstract void KelimeleriYukle();
    }

    // Kolay mod: 4 harfli Türkçe kelimeler
    public class KolayMod : OyunModu
    {
        public KolayMod()
        {
            MaksimumKelimeUzunlugu = 4;
            MinimumKelimeUzunlugu = 3;
        }

        protected override void KelimeleriYukle()
        {
            Kelimeler.AddRange(new[] {
                "elma", "arzu", "masa", "kedi", "yurt", "bile", "yeni", "baba", "kafa", "saat",
                "kalp", "göz", "ayak", "kafa", "dil", "göl", "dağ", "deniz", "güneş", "ay"
            });
        }
    }

    // Orta mod: 5-6 harfli Türkçe kelimeler
    public class OrtaMod : OyunModu
    {
        public OrtaMod()
        {
            MaksimumKelimeUzunlugu = 6;
            MinimumKelimeUzunlugu = 5;
        }

        protected override void KelimeleriYukle()
        {
            Kelimeler.AddRange(new[] {
                "araba", "kalem", "meyve", "simit", "kavun", "sabah", "kargo", "biber", "ceviz", "koyun",
                "kitap", "masal", "çanta", "kalem", "defter", "silgi", "okul", "sınıf", "öğrenci", "öğretmen"
            });
        }
    }

    // Zor mod: 7 ve daha fazla harfli Türkçe kelimeler
    public class ZorMod : OyunModu
    {
        public ZorMod()
        {
            MaksimumKelimeUzunlugu = 8;
            MinimumKelimeUzunlugu = 7;
        }

        protected override void KelimeleriYukle()
        {
            Kelimeler.AddRange(new[] {
                "bilgisayar", "kitaplık", "oyuncak", "karpuz", "televizyon", "uçurtma", "çalışkan", "yazılım", "gözlükçü", "kütüphane",
                "öğrencilik", "öğretmenlik", "mühendislik", "doktorluk", "avukatlık", "hemşirelik", "eczacılık", "dişçilik", "veterinerlik", "mimarlık"
            });
        }
    }
} 