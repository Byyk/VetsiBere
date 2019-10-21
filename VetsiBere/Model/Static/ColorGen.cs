using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetsiBere.Model.Static
{
    public static class ColorGen
    {
        private static readonly Random _random = new Random();
        public static Color GetRandomColor()
        {
            return Color.FromArgb(
                _random.Next(0,256),
                _random.Next(0, 256),
                _random.Next(0, 256)
                );
        }
    }
}
