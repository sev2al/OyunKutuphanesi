namespace OyunKutuphanesi
{
    public class KolayLabirentMod : LabirentZorlukModu
    {
        protected override void HaritayiOlustur()
        {
            SatirSayisi = 7;
            SutunSayisi = 7;
            Harita = new int[SatirSayisi, SutunSayisi];
            int[,] kolayHarita = new int[7, 7]
            {
                {1,1,1,1,1,1,1},
                {1,0,0,0,1,0,1},
                {1,0,1,0,1,0,1},
                {1,0,1,0,0,0,1},
                {1,0,1,1,1,0,1},
                {1,0,0,0,0,0,2},
                {1,1,1,1,1,1,1}
            };
            for (int i = 0; i < SatirSayisi; i++)
                for (int j = 0; j < SutunSayisi; j++)
                    Harita[i, j] = kolayHarita[i, j];
            BaslangicNoktasi = (1, 1);
            CikisNoktasi = (5, 6);
        }
    }
} 