using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetsiBere.Model.Overwrites;

namespace VetsiBere.Model
{
    public class GameManager
    {
        public static GameManager Insatance = new GameManager();
        private readonly Balicek _balicek;
        private readonly List<Hrac> _hraci;

        private GameManager()
        {
            _balicek = new Balicek();

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 8; j++)
                    _balicek.Add(new Karta(i,j));
            _balicek.Shufle();
        }

        public void Write()
        {
            foreach (var karta in _balicek)
            {
                Console.WriteLine(karta.Barva + " : " + karta.TypKarty);
            }
        }

        public void AddHrac(string nazev, Color barva)
        {
            _hraci.Add(new Hrac(nazev, barva));
        }

        public void RemoveHrac(Hrac hrac)
        {
            _hraci.Remove(hrac);
        }

        public void GivePlayerCard(Hrac hrac)
        {
            hrac.GetCard(_balicek.TakeCard());
        }
    }
}
