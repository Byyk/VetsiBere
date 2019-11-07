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
        public event Action HraZacala;

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

            Components.Console.commandEntered += (s, strings) =>
            {
                Hrac hrac;
                switch (s)
                {
                    case "kill":
                        hrac = Hraci.FirstOrDefault(h => h.Nazev == strings[0]);
                        if (hrac != null) hrac.Prohraj(Hraci.Count(h => h.VeHre));
                        else Components.Console.LogToConsole("Neplatný název hráče");
                        break;
                    case "make-god":
                        hrac = Hraci.FirstOrDefault(h => h.Nazev == strings[0]);
                        foreach (Karta karta in hrac.Ruka)
                        {
                            karta.TypKarty = TypyKaret.GodCard;
                        }
                        break;
                    case "give-card":
                        int typ, barva = 0;
                        if(strings.Length < 2) Components.Console.LogToConsole("give-card musí mít alespoň 2 argumenty. (název hráče a typ karty)");
                        if (strings.Length == 2) barva = 0;
                        if (strings.Length == 3)
                            if(!int.TryParse(strings[2], out barva)) Components.Console.LogToConsole("2. argument musí být čislo");
                        if (!int.TryParse(strings[1], out typ)) Components.Console.LogToConsole("1. argument musí být čislo");

                        hrac = Hraci.FirstOrDefault(f => f.Nazev == strings[0]);
                        if(hrac == null) Components.Console.LogToConsole("Hráč: " + strings[0] + " neexistuje!");
                        hrac.GetCard(new Karta(barva, typ));
                        break;
                }
            };
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
            foreach (var hrac in Hraci)
            {
                hrac.VeHre = true;
            }
            HraZacala?.Invoke();
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
