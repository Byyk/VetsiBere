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
    public partial class HracInterface : UserControl
    {

        private readonly Hrac _hrac;
        public HracInterface(Hrac hrac)
        {
            InitializeComponent();
            _hrac = hrac;
            label1.Text = hrac.Nazev;
            label2.Text = hrac.PocetKaret.ToString();
            this.BackColor = hrac.Barva;
            
        }

        public HracInterface() { }

        private void HracInterface_Load(object sender, EventArgs e)
        {
            _hrac.ColorChanged += (Color b) => BackColor = b;
            _hrac.NameChanged += (string j) => label1.Text = j;
            _hrac.CardCountChanged += (int p) => label2.Text = p.ToString();

            
            pictureBox1.BackColor = _hrac.Barva;
            pictureBox2.BackColor = _hrac.Barva;
            pictureBox3.BackColor = _hrac.Barva;
            pictureBox4.BackColor = _hrac.Barva;
        }

        public void prohral()
        {
            pictureBox1.BackColor = Color.Red;
            pictureBox2.BackColor = Color.Red;
            pictureBox3.BackColor = Color.Red;
            pictureBox4.BackColor = Color.Red;
        }

        public void vyhral(Hrac vyherce)
        {
            pictureBox1.BackColor = Color.Green;
            pictureBox2.BackColor = Color.Green;
            pictureBox3.BackColor = Color.Green;
            pictureBox4.BackColor = Color.Green;
        }
    }
}
