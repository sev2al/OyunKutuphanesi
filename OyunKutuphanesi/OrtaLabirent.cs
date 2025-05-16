using System;

namespace OyunKutuphanesi
{
    public class OrtaLabirent : Labirent
    {
        public OrtaLabirent()
        {
            SatirSayisi = 9;
            SutunSayisi = 9;
            Harita = new int[SatirSayisi, SutunSayisi];
            HaritayiOlustur();
        }

        public override void HaritayiOlustur()
        {
            // 0: boş, 1: duvar, 2: çıkış
            int[,] ortaHarita = new int[9, 9]
            {
                {1,1,1,1,1,1,1,1,1},
                {1,0,0,1,0,0,0,0,1},
                {1,0,1,1,0,1,1,0,1},
                {1,0,1,0,0,0,1,0,1},
                {1,0,1,0,1,0,1,0,1},
                {1,0,0,0,1,0,1,0,1},
                {1,1,1,0,1,0,1,0,1},
                {1,0,0,0,0,0,1,2,1},
                {1,1,1,1,1,1,1,1,1}
            };
            for (int i = 0; i < SatirSayisi; i++)
                for (int j = 0; j < SutunSayisi; j++)
                    Harita[i, j] = ortaHarita[i, j];
            BaslangicNoktasi = (1, 1);
            CikisNoktasi = (7, 7); // 2'nin olduğu yer
        }
    }
} 