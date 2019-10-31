using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VetsiBere.Properties;

namespace VetsiBere.Model
{
    public class Karta
    {
        public Karta() { }
        public Karta(int barva, int typKarty)
        {
            Barva = (Barva) barva;
            TypKarty = (TypyKaret) typKarty;
        }
        public Barva Barva { get; set; }
        public TypyKaret TypKarty { get; set; }

        public void DrawYourSelf(Graphics g, int x, int y)
        {
            var a = CardImages.cards[new DKey(Barva, TypKarty)];
            g.DrawImage(a , new Point(x,y));
        }
    }

    public enum Barva
    {
        Srdce = 0,
        Zaludy = 1,
        Listy = 2,
        Kule = 3
    }

    public enum TypyKaret
    {
        Spodek = 0,
        Svrsek = 1,
        Kral = 2,
        Sedmicka = 3,
        Osmicka = 4,
        Devitka = 5,
        Desitka = 6,
        Eso = 7
    }

    public class DKey : IEquatable<DKey>
    {
        public DKey(int b, int t)
        {
            Barva = (Barva) b;
            TypyKaret = (TypyKaret) t;
        }

        public DKey(Barva b, TypyKaret t)
        {
            Barva = b;
            TypyKaret = t;
        }

        public Barva Barva;
        public TypyKaret TypyKaret;
        public override int GetHashCode()
        {
            return 1;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as DKey);
        }
        public bool Equals(DKey k)
        {
            return k.Barva == Barva && k.TypyKaret == TypyKaret;
        }

    }

    public static class CardImages {
        public static Dictionary<DKey, Bitmap> cards = new Dictionary<DKey, Bitmap>
        {
            { new DKey(0, 0), Resources.c_spodek },
            { new DKey(0, 1), Resources.c_svrsek },
            { new DKey(0, 2), Resources.c_kral },
            { new DKey(0, 3), Resources.c_sedma },
            { new DKey(0, 4), Resources.c_osma },
            { new DKey(0, 5), Resources.c_devitka },
            { new DKey(0, 6), Resources.c_desitka },
            { new DKey(0, 7), Resources.c_eso },

            { new DKey(1, 0), Resources.z_spodek },
            { new DKey(1, 1), Resources.z_svrsek },
            { new DKey(1, 2), Resources.z_kral },
            { new DKey(1, 3), Resources.z_sedma },
            { new DKey(1, 4), Resources.z_osma },
            { new DKey(1, 5), Resources.z_devitka },
            { new DKey(1, 6), Resources.z_desitka },
            { new DKey(1, 7), Resources.z_eso },

            { new DKey(2, 0), Resources.e_spodek },
            { new DKey(2, 1), Resources.e_svrsek },
            { new DKey(2, 2), Resources.e_kral },
            { new DKey(2, 3), Resources.e_sedma },
            { new DKey(2, 4), Resources.e_osma },
            { new DKey(2, 5), Resources.e_devitka },
            { new DKey(2, 6), Resources.e_desitka },
            { new DKey(2, 7), Resources.e_eso },

            { new DKey(3, 0), Resources.k_spodek },
            { new DKey(3, 1), Resources.k_svrsek },
            { new DKey(3, 2), Resources.k_kral },
            { new DKey(3, 3), Resources.k_sedma },
            { new DKey(3, 4), Resources.k_osma },
            { new DKey(3, 5), Resources.k_devitka },
            { new DKey(3, 6), Resources.k_desitka },
            { new DKey(3, 7), Resources.k_eso },
        };
    }
}
