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
        public HracInterface(Hrac hrac)
        {
            InitializeComponent();
            _hrac = hrac;
            label1.Text = hrac.Nazev;
            label2.Text = hrac.PocetKaret.ToString();
            lastCardCount = hrac.PocetKaret;
            this.BackColor = hrac.Barva;
        }

        public HracInterface() { }

        private void HracInterface_Load(object sender, EventArgs e)
        {
            _hrac.ColorChanged += (Color b) => BackColor = b;
            _hrac.NameChanged += (string j) => label1.Text = j;
            _hrac.CardCountChanged += (int p) =>
            {
              label2.Text = p.ToString();
              var change = (p - lastCardCount);
              label3.Text = change < 0 ? "- " + Math.Abs(change) : "+ " + change;
              lastCardCount = p;
            };
        }

    private void HracInterface_Paint(object sender, PaintEventArgs e)
    {
      var g = e.Graphics;
      g.DrawRectangle(new Pen(Color.Black, 2f), 1, 1, Width - 2, Height - 2);
    }
  }
}
