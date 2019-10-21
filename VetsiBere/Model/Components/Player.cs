using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetsiBere.Model.Components
{
    public partial class Player : UserControl
    {
        private readonly Hrac _hrac;

        public Player()
        {
            InitializeComponent();
        }

        public Player(Hrac hrac)
        {
            InitializeComponent();
            _hrac = hrac;
            label1.Text = hrac.Nazev;
            button2.BackColor = hrac.Barva;

            hrac.NameChanged += s => label1.Text = s;
            hrac.ColorChanged += color => button2.BackColor = color;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            GameManager.Insatance.RemoveHrac(_hrac);
            Dispose();
        }
    }
}
