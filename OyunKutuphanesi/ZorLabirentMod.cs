namespace OyunKutuphanesi
{
    public class ZorLabirentMod : LabirentZorlukModu
    {
        protected override void HaritayiOlustur()
        {
            SatirSayisi = 11;
            SutunSayisi = 11;
            Harita = new int[SatirSayisi, SutunSayisi];
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
            CikisNoktasi = (9, 9);
        }
    }
} 