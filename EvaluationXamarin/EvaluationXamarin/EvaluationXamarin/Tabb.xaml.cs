using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace EvaluationXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tabb : Xamarin.Forms.TabbedPage
    {
        public Tabb()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            this.BarBackgroundColor = Color.Aqua;
        }
    }
}