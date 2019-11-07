using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VetsiBere.Model.Overwrites;

namespace VetsiBere.Model.Components
{
    public partial class HracInterface : UserControl
    {

        private readonly Hrac _hrac;

        private int lastCardCount;
        private int posledniPocet;

        public HracInterface(Hrac hrac)
        {
            InitializeComponent();
            _hrac = hrac;
            label1.Text = hrac.Nazev;
            label2.Text = hrac.PocetKaret.ToString();
            lastCardCount = hrac.PocetKaret;
            this.BackColor = hrac.Barva;
            DoubleBuffered = true;
        }

        public HracInterface() { }

        private void HracInterface_Load(object sender, EventArgs e)
        {
            _hrac.Prohral += () => label3.Text = ":(";
            _hrac.ColorChanged += (Color b) => BackColor = b;
            _hrac.NameChanged += (string j) => label1.Text = j;
            _hrac.CardCountChanged += (int p) =>
            {
              label2.Text = p.ToString();
              posledniPocet += (p - lastCardCount);
              if (posledniPocet < 0) label3.Text = "- " + Math.Abs(posledniPocet);
              else if (posledniPocet == 0) label3.Text = 0.ToString();
              else label3.Text = "+ " + posledniPocet;
              lastCardCount = p;
            };

            Hra.KonecKola += () => posledniPocet = 0;
            GameManager.Insatance.HraZacala += () => label3.Text = 0.ToString();
        }

    private void HracInterface_Paint(object sender, PaintEventArgs e)
    {
      var g = e.Graphics;
      g.DrawRectangle(new Pen(Color.Black, 2f), 1, 1, Width - 2, Height - 2);
    }
  }
}
