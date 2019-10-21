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
        public event Action<string> NameChanged;
        public event Action<Color> ColorChanged;

        public Hrac(string nazev, Color barva)
        {
            Ruka = new Balicek();
            Nazev = nazev;
            Barva = barva;
        }

        public int PoradoveCislo { get; set; }

        private Color barva;
        public Color Barva
        {
            get => barva;
            set
            {
                barva = value;
                ColorChanged?.Invoke(value);
            }
        }

        private string nazev;
        public string Nazev
        {
            get => nazev;
            set
            {
                nazev = value;
                NameChanged?.Invoke(value);
            }
        }

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

        public void SpalKarty()
        {
            Ruka.Clear();
        }
    }
}
