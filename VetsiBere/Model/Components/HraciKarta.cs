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
  public partial class HraciKarta : UserControl
  {
    private readonly Karta _karta;
    public HraciKarta(Karta karta)
    {
      InitializeComponent();
      _karta = karta;
      if(_karta.TypKarty != TypyKaret.GodCard)
        BackgroundImage = _karta.GetImage.Resize(Width, Height);
    }
  }
}
