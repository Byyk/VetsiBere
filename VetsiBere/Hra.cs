using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using VetsiBere.Model;
using VetsiBere.Model.Components;
using VetsiBere.Model.Overwrites;
using VetsiBere.Properties;
using Timer = System.Threading.Timer;

namespace VetsiBere
{
  public partial class Hra : Form
  {
    private readonly float _tableBorder;

    private readonly Brush _tableBrush;
    private readonly Pen _tablePen;

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

    private void MyPictureBox1_Paint(object sender, PaintEventArgs e)
    {
      var g = e.Graphics;
      g.SmoothingMode = SmoothingMode.AntiAlias;

      #region DrawTable3D

      /*
      g.FillPolygon(_tableBrush,
          new Point[]
          {
              new Point((int)_tableBorder, (int)(PBHeight - _tableBorder)),
              new Point((int)_tableBorder + 10, (int)(PBHeight - _tableBorder + 10)),
              new Point((int)(PBWidth - _tableBorder + 10), (int)(PBHeight - _tableBorder + 10)),
              new Point((int)(PBWidth - _tableBorder), (int)(PBHeight - _tableBorder)),
              new Point((int)(PBWidth - _tableBorder + 10), (int)(PBHeight - _tableBorder + 10)),
              new Point((int)(PBWidth - _tableBorder + 10), (int)_tableBorder + 10),
              new Point((int)(PBWidth - _tableBorder), (int)_tableBorder)
          }
      );
      g.DrawLines(_tablePen,
          new Point[]
          {
              new Point((int)_tableBorder, (int)(PBHeight - _tableBorder)),
              new Point((int)_tableBorder + 10, (int)(PBHeight - _tableBorder + 10)),
              new Point((int)(PBWidth - _tableBorder + 10), (int)(PBHeight - _tableBorder + 10)),
              new Point((int)(PBWidth - _tableBorder), (int)(PBHeight - _tableBorder)),
              new Point((int)(PBWidth - _tableBorder + 10), (int)(PBHeight - _tableBorder + 10)),
              new Point((int)(PBWidth - _tableBorder + 10), (int)_tableBorder + 10),
              new Point((int)(PBWidth - _tableBorder), (int)_tableBorder)
          }
      );
      */

      #endregion

      #region DrawTable2D

      /*g.FillRectangle(_tableBrush,
          _tableBorder,
          _tableBorder,
          PBWidth - 2 * _tableBorder,
          PBHeight - 2 * _tableBorder);
      g.DrawRectangle(_tablePen,
          _tableBorder,
          _tableBorder,
          PBWidth - 2 * _tableBorder,
          PBHeight - 2 * _tableBorder);

      */

      #endregion

      g.DrawImage(Resources.c_kral.Resize(150, 250), new Point(300, 200));
      //g.DrawImage(Resources.z_sedma.Resize(150,250), new Point(300, 200));
    }

    private void Hra_Shown(object sender, EventArgs e)
    {
      flowLayoutPanel1.Controls.Clear();
      foreach (var hrac in GameManager.Insatance.Hraci) flowLayoutPanel2.Controls.Add(new HracInterface(hrac));
    }

    private void Hra_Click(object sender, EventArgs e)
    {
      Play(GameManager.Insatance.Hraci.Where(h => h.VeHre).ToList());
    }

    private void Play(List<Hrac> h, List<VyhozenaKarta> vyhozene = null)
    {
      #region Comment

      /*var vyhozene = new List<Karta>();
  Hrac vyherce = h[0];
  List<Hrac> remiza = new List<Hrac>();

  if(v != null) vyhozene.AddRange(v);

  flowLayoutPanel1.Controls.Clear();

  Karta k;
  foreach (Hrac hrac in h)
  {
    k = hrac.ThrowCard();
    vyhozene.Add(k);
    flowLayoutPanel1.Controls.Add(new HraciKarta(k));
    if ((int)vyherce.PosledniZahranaKarta.TypKarty < (int)k.TypKarty)
    {
      vyherce = hrac;
      remiza.Clear();
    }

    if ((int)vyherce.PosledniZahranaKarta.TypKarty == (int)k.TypKarty && vyhozene.Count != 1)
    {
      if (remiza.Count == 0) remiza.Add(vyherce);
      vyherce = hrac;
      remiza.Add(hrac);
    }
  }

  if (remiza.Count != 0)
  {
    Play(remiza, vyhozene);
    return;
  }
  vyherce.GetCards(vyhozene);
  CheckDefeat();
  */

      #endregion

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

      foreach (var vk in vyhozene)
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
      Play(GameManager.Insatance.Hraci.Where(h => h.VeHre).ToList());
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      timer1.Stop();
    }
  }
}