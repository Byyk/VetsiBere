using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using VetsiBere.Model;
using VetsiBere.Model.Components;
using VetsiBere.Model.Overwrites;
using VetsiBere.Properties;

namespace VetsiBere
{
    public partial class Hra : Form
    {
        private readonly float _tableBorder;

        private readonly Brush _tableBrush;
        private readonly Pen _tablePen;

        private int kolo = 1;

        public Hra()
        {
            InitializeComponent();
            _tableBrush = new SolidBrush(Color.Coral);
            _tablePen = new Pen(Color.DarkSalmon, 2f);
            _tableBorder = 50f;
        }


        private void Hra_Load(object sender, EventArgs e)
        {
        }

        private void Hra_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void Hra_Shown(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var hrac in GameManager.Insatance.Hraci) flowLayoutPanel2.Controls.Add(new HracInterface(hrac));
        }

        private void Hra_Click(object sender, EventArgs e)
        {
            StartRound();
        }

        private void StartRound()
        {
            Play(GameManager.Insatance.Hraci.Where(h => h.VeHre).ToList());
            if(kolo % 11 == 10)
                foreach (var hrac in GameManager.Insatance.Hraci) hrac.Ruka.Shufle();
            kolo++;
        }

        private void Play(List<Hrac> h, List<VyhozenaKarta> vyhozene = null)
        {
            if (vyhozene == null)
            {
                vyhozene = new List<VyhozenaKarta>();
                flowLayoutPanel1.Controls.Clear();
            }

            var akumulator = -10;


            for (var i = 0; i < h.Count; i++)
            {
                var hrac = h[i];
                var thrownCard = hrac.ThrowCard();
                if (thrownCard == null) continue;
                vyhozene.Add(thrownCard);
                flowLayoutPanel1.Controls.Add(new HraciKarta(thrownCard.Karta));
            }

            foreach (var vk in vyhozene.GetRange(vyhozene.Count - h.Count, h.Count))
                if ((int) vk.Karta.TypKarty > akumulator)
                    akumulator = (int) vk.Karta.TypKarty;

            var vyherci = vyhozene.Where(v => (int) v.Karta.TypKarty == akumulator)
                .Select(v => v.Hrac).ToList();

            if (vyherci.Count == 0) throw new NullReferenceException();
            if (vyherci.Count == 1)
                vyherci[0].GetCards(vyhozene);

            if (vyherci.Count > 1) Play(vyherci, vyhozene);
            CheckDefeat();
        }

        private void CheckDefeat()
        {
            var hraci = GameManager.Insatance.Hraci.Where(h => h.VeHre).ToList();
            var misto = hraci.Count(h => h.VeHre) - hraci.Count(h => h.PocetKaret == 0) + 1;
            foreach (var hrac in hraci)
                if (hrac.PocetKaret == 0)
                    hrac.Prohraj(misto);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            StartRound();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = (20 - trackBar1.Value) * 25;
            timer1.Start();
        }
    }
}