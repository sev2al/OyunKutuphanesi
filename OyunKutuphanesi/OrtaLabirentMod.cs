namespace OyunKutuphanesi
{
    public class OrtaLabirentMod : LabirentZorlukModu
    {
        protected override void HaritayiOlustur()
        {
            SatirSayisi = 9;
            SutunSayisi = 9;
            Harita = new int[SatirSayisi, SutunSayisi];
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
            CikisNoktasi = (7, 7);
        }
    }
} 