using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using VetsiBere.Model.Components;
using VetsiBere.Model.Static;

namespace VetsiBere.Model.Popups
{
    public partial class Nastaveni : Form
    {
        public Nastaveni()
        {
            InitializeComponent();
            button1.BackColor = ColorGen.GetRandomColor();
            flowLayoutPanel1.Width = flowLayoutPanel1.Width + SystemInformation.VerticalScrollBarWidth;
            LoadFromXml();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AddPlayer(GameManager.Insatance.AddHrac(textBox1.Text, button1.BackColor));
            button1.BackColor = ColorGen.GetRandomColor();
        }

        private void AddPlayer(Hrac h)
        {
            flowLayoutPanel1.Controls.Add(new Player(h));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();
            cd.Color = button1.BackColor;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = cd.Color;
            }
        }

        private void Nastaveni_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }


        private void SaveToXml()
        {
            var serializer = new XmlSerializer(typeof(NastaveniXml));
            using (var s = XmlWriter.Create("setings.xml"))
            {
                var set = new NastaveniXml();
                set.Hraci = GameManager.Insatance.Hraci.Select(h => new HracXml(h)).ToArray();
                serializer.Serialize(s, set);
            }
        }

        private void LoadFromXml()
        {
            if (!File.Exists("setings.xml")) return;

            var serializer = new XmlSerializer(typeof(NastaveniXml));
            using (var r = XmlReader.Create("setings.xml"))
            {
                var set = (NastaveniXml)serializer.Deserialize(r);
                var hraci = set.Hraci.Select(h => h.Hrac).ToArray();
                GameManager.Insatance.SetHraci(hraci);
                ClearPlayers();
                AddPlayers(hraci);
            }
        }

        private void AddPlayers(Hrac[] h)
        {
            foreach (Hrac hrac in h) AddPlayer(hrac);
        }

        private void ClearPlayers()
        {
            flowLayoutPanel1.Controls.Clear();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
            SaveToXml();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
            LoadFromXml();
        }
    }
}
