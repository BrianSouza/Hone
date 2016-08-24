using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Entidades;
using Hone.ViewModel;
using Xamarin.Forms;

namespace Hone.View
{
    public partial class CadPNView : ContentPage
    {
        CadPNViewModel vmCadPN = new CadPNViewModel();
        public CadPNView()
        {
            InitializeComponent();
            this.BindingContext = this.vmCadPN;
        }
    }
}
