using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using VetsiBere.Model;
using VetsiBere.Model.Overwrites;
using VetsiBere.Properties;

namespace VetsiBere
{
    public partial class Hra : Form
    {
        private readonly float _tableBorder;

        private readonly Brush _tableBrush;
        private readonly Pen _tablePen;
        private bool appRunning;
        private Thread graficThread, updateThread;

        public Hra()
        {
            InitializeComponent();
            _tableBrush = new SolidBrush(Color.Coral);
            _tablePen = new Pen(Color.DarkSalmon, 2f);
            _tableBorder = 50f;
        }

        private float PBWidth => myPictureBox1.Width;
        private float PBHeight => myPictureBox1.Height;

        private void UpdateGraphicsGameLoop()
        {
            while (appRunning)
            {
                UpdatePB(myPictureBox1);
                Thread.Sleep(50);
            }
        }

        private void Hra_Load(object sender, EventArgs e)
        {
            (updateThread = new Thread(UpdateGameLoop)).Start();
            (graficThread = new Thread(UpdateGraphicsGameLoop)).Start();
        }

        private void UpdateGameLoop()
        {
            while (appRunning) Thread.Sleep(25);
        }

        private void UpdatePB(PictureBox p)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => p.Refresh()));
            else
                p.Refresh();
        }

        private void Hra_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                appRunning = false;
            }
        }

        private void Hra_Shown(object sender, EventArgs e)
        {
            appRunning = true;
            GameManager.Insatance.Rozdej();
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

            g.FillRectangle(_tableBrush,
                _tableBorder,
                _tableBorder,
                PBWidth - 2 * _tableBorder,
                PBHeight - 2 * _tableBorder);
            g.DrawRectangle(_tablePen,
                _tableBorder,
                _tableBorder,
                PBWidth - 2 * _tableBorder,
                PBHeight - 2 * _tableBorder);

            #endregion

            g.DrawImage(Resources.back.Resize(450,750), new Point(300, 200));
            g.DrawImage(Resources.z_sedma.Resize(150,250), new Point(300, 200));
        }
    }
}