using System;

namespace OyunKutuphanesi
{
    public class ZorLabirent : Labirent
    {
        public ZorLabirent()
        {
            SatirSayisi = 11;
            SutunSayisi = 11;
            Harita = new int[SatirSayisi, SutunSayisi];
            HaritayiOlustur();
        }

        public override void HaritayiOlustur()
        {
            // 0: boş, 1: duvar, 2: çıkış
            int[,] zorHarita = new int[11, 11]
            {
                {1,1,1,1,1,1,1,1,1,1,1},
                {1,0,0,1,0,0,1,0,0,0,1},
                {1,1,0,1,0,1,1,0,1,0,1},
                {1,1,0,0,0,1,0,0,1,0,1},
                {1,0,1,1,0,1,0,1,1,0,1},
                {1,0,1,0,0,0,0,1,0,0,1},
                {1,0,1,0,1,1,1,1,0,1,1},
                {1,0,0,0,0,0,1,0,0,0,1},
                {1,1,1,1,1,0,1,1,1,0,1},
                {1,0,0,0,1,0,0,0,0,2,1},
                {1,1,1,1,1,1,1,1,1,1,1}
            };
            for (int i = 0; i < SatirSayisi; i++)
                for (int j = 0; j < SutunSayisi; j++)
                    Harita[i, j] = zorHarita[i, j];
            BaslangicNoktasi = (1, 1);
            CikisNoktasi = (9, 9); // 2'nin olduğu yer
        }
    }
} 