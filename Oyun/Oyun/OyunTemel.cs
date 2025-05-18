using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyun
{
    internal class OyunTemel
    {
        
            public string SecilenKelime { get; set; }
            public string GosterilenKelime { get; set; }
            public int KalanHak { get; set; }
            public List<char> YanlisHarfler { get; set; } = new List<char>();

            public void OyunaBasla(string kelime)
            {
                SecilenKelime = kelime;
                GosterilenKelime = new string('_', kelime.Length);
                KalanHak = 6;
                YanlisHarfler.Clear();
            }

            public void HarfTahminEt(char harf)
            {
                if (SecilenKelime.Contains(harf))
                {
                    char[] goster = GosterilenKelime.ToCharArray();
                    for (int i = 0; i < SecilenKelime.Length; i++)
                    {
                        if (SecilenKelime[i] == harf)
                            goster[i] = harf;
                    }
                    GosterilenKelime = new string(goster);
                }
                else
                {
                    if (!YanlisHarfler.Contains(harf))
                    {
                        YanlisHarfler.Add(harf);
                        KalanHak--;
                    }
                }
            }

            public bool OyunBittiMi()
            {
                return KalanHak == 0 || !GosterilenKelime.Contains('_');
            }
        }

    }

