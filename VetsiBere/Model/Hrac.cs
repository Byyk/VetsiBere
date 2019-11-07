using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VetsiBere.Model.Overwrites;
using VetsiBere.Model.Static;

namespace VetsiBere.Model
{
    public class Hrac
    {
        public event Action<string> NameChanged;
        public event Action<Color> ColorChanged;
        public event Action<int> CardCountChanged;

        public Karta PosledniZahranaKarta;

        public Hrac(string nazev, Color barva)
        {
            Ruka = new Balicek();
            Nazev = nazev;
            Barva = barva;
        }

        public int Poradi { get; set; }

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

        public bool VeHre = true;

        public Balicek Ruka { get; set; }

        public int PocetKaret => Ruka.Count;
        public void GetCard(Karta karta)
        {
            Ruka.Add(karta);
            CardCountChanged?.Invoke(Ruka.Count);
        }

        public void GetCards(List<VyhozenaKarta> k)
        {
            Ruka.AddRange(k.Select(ka => ka.Karta));
            CardCountChanged?.Invoke(Ruka.Count);
        }

        public VyhozenaKarta ThrowCard()
        {
            PosledniZahranaKarta = Ruka.TakeCard();
            CardCountChanged?.Invoke(Ruka.Count);
            if (PosledniZahranaKarta == null)
            {
              VeHre = false;
              return null;
            }
            return new VyhozenaKarta(this, PosledniZahranaKarta);
        }

        public void SpalKarty()
        {
            Ruka.Clear();
        }

        public void Prohraj(int poradi)
        {
          VeHre = false;
          Poradi = poradi;
        }
    }
}
