using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetsiBere.Model
{
    public class HracXml
    {
        public HracXml() { }

        public HracXml(Hrac h)
        {
            Nazev = h.Nazev;
            Barva = new ColorXml(h.Barva);
        }

        public string Nazev { get; set; }
        public ColorXml Barva { get; set; }

        public Hrac Hrac => new Hrac(Nazev, Barva.Color);
    }

    public class ColorXml
    {
        public ColorXml() { }
        public ColorXml(Color c)
        {
            R = c.R;
            G = c.G;
            B = c.B;
        }

        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public Color Color => Color.FromArgb(R, G, B);
    }
}
