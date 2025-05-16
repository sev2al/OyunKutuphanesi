namespace OyunKutuphanesi
{
    public abstract class LabirentZorlukModu
    {
        public int SatirSayisi { get; protected set; }
        public int SutunSayisi { get; protected set; }
        public int[,] Harita { get; protected set; }
        public (int x, int y) BaslangicNoktasi { get; protected set; }
        public (int x, int y) CikisNoktasi { get; protected set; }

        public LabirentZorlukModu()
        {
            HaritayiOlustur();
        }

        protected abstract void HaritayiOlustur();
    }
} 