using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetsiBere.Model.Overwrites;

namespace VetsiBere.Model
{
    public class Hrac
    {
        public Hrac(string nazev, Color barva)
        {
            Ruka = new Balicek();
        }

        public int PoradoveCislo { get; set; }
        public Color Barva { get; set; }
        public string Nazev { get; set; }
        public Balicek Ruka { get; set; }

        public int PocetKaret => Ruka.Count;
        public void GetCard(Karta karta)
        {
            Ruka.Add(karta);
        }
        public Karta ThrowCard()
        {
            return Ruka.TakeCard();
        }
    }
}
