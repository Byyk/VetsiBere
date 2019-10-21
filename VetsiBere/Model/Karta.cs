using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetsiBere.Model
{
    public class Karta
    {
        public Karta(int barva, int typKarty)
        {
            Barva = (Barva) barva;
            TypKarty = (TypyKaret) typKarty;
        }
        public Barva Barva { get; set; }
        public TypyKaret TypKarty { get; set; }
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
}
