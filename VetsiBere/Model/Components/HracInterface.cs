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
        }

        public HracInterface() { }

        private void HracInterface_Load(object sender, EventArgs e)
        {
            _hrac.ColorChanged += (Color b) => BackColor = b;
            _hrac.NameChanged += (string j) => label1.Text = j;
            _hrac.CardCountChanged += (int p) => label2.Text = p.ToString();
        }
    }
}
