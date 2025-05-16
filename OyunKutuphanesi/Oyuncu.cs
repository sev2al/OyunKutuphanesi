namespace OyunKutuphanesi
{
    public class Oyuncu
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Oyuncu(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void HareketEt(int dx, int dy, LabirentZorlukModu labirent)
        {
            int yeniX = X + dx;
            int yeniY = Y + dy;
            if (yeniX >= 0 && yeniX < labirent.SatirSayisi && yeniY >= 0 && yeniY < labirent.SutunSayisi)
            {
                if (labirent.Harita[yeniX, yeniY] != 1)
                {
                    X = yeniX;
                    Y = yeniY;
                }
            }
        }
    }
} 