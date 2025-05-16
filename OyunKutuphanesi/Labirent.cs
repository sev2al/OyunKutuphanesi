using System.Collections.Generic;

namespace OyunKutuphanesi
{
    public abstract class Labirent
    {
        public int SatirSayisi { get; protected set; }
        public int SutunSayisi { get; protected set; }
        public int[,] Harita { get; protected set; } // 0: boş, 1: duvar, 2: çıkış
        public (int x, int y) BaslangicNoktasi { get; protected set; }
        public (int x, int y) CikisNoktasi { get; protected set; }

        public abstract void HaritayiOlustur();
        public bool DuvarMi(int x, int y)
        {
            return Harita[x, y] == 1;
        }
        public bool CikisMi(int x, int y)
        {
            return Harita[x, y] == 2;
        }
    }
} 