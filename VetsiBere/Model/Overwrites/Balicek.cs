using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetsiBere.Model.Overwrites
{
    public class Balicek : List<Karta>
    {
        public void Shufle()
        {
            for (int i = 0; i < 32; i++) ShufleOnce();
        }

        private void ShufleOnce()
        {
            Karta pom;
            int rand;
            var r = new Random();
            for (int i = 0; i < Count; i++)
            {
                rand = r.Next(0, Count);
                pom = this[i];
                this[i] = this[rand];
                this[rand] = pom;
            }
        }

        public Karta TakeCard()
        {
          if (Count == 0) return null;
            var first = this[0];
            this.RemoveAt(0);
            return first;
        }
    }
}
