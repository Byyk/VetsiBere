using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetsiBere.Model.Overwrites;
using VetsiBere.Model.Static;

namespace VetsiBere.Model
{
    public class GameManager
    {
        public static GameManager Insatance = new GameManager();
        private readonly Balicek _balicek;
        private readonly List<Hrac> _hraci;

        public Hrac[] Hraci => _hraci.ToArray();
        public int PocetHracu => _hraci.Count;

        public void SetHraci(Hrac[] h) {
            _hraci.Clear();
            _hraci.AddRange(h);
        }

        private GameManager()
        {
            _balicek = new Balicek();
            _hraci = new List<Hrac>();
        }

        public Hrac AddHrac(string nazev, Color barva)
        {
            _hraci.Add(new Hrac(nazev, barva));
            return _hraci.Last();
        }

        public void RemoveHrac(Hrac hrac)
        {
            _hraci.Remove(hrac);
        }

        public void GivePlayerCard(Hrac hrac)
        {
            hrac.GetCard(_balicek.TakeCard());
        }

        public void ZacniHru()
        {
            Rozdej();
        }

        private void Rozdej()
        {
            Refresh();
            while (_balicek.Count >= _hraci.Count)
            {
                foreach (Hrac hrac in _hraci)
                {
                    hrac.GetCard(_balicek.TakeCard());
                }
            }
        }


        private void Refresh()
        {
            _balicek.Clear();
            for (int i = 0; i < 4; i++)
            for (int j = 0; j < 8; j++)
                _balicek.Add(new Karta(i, j));
            _balicek.Shufle();

            foreach (Hrac hrac in _hraci)
            {
                hrac.SpalKarty();
            }
        }
    }
}
