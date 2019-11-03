using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetsiBere.Model
{
  public class VyhozenaKarta
  {
    public Hrac Hrac { get; set; }
    public Karta Karta { get; set; }

    public VyhozenaKarta(Hrac h, Karta k)
    {
      Hrac = h;
      Karta = k;
    }
  }
}
