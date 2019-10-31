using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VetsiBere.Model;
using VetsiBere.Model.Popups;

namespace VetsiBere
{
    public partial class Form1 : Form
    {
        private readonly Hra _hra;
        private readonly Nastaveni _nastaveni;

        public Form1()
        {
            InitializeComponent();

            _hra = new Hra();
            _hra.Closing += (sender, args) => Show();

            _nastaveni = new Nastaveni();
            _nastaveni.Closing += (sender, args) => Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            GameManager.Insatance.ZacniHru();
            _hra.Show();
            Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            _nastaveni.Show();
            Hide();
        }
    }
}
