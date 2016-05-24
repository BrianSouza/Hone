using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.ViewModel;
using Xamarin.Forms;

namespace Hone.View
{
    public partial class PaginaPrincipal : ContentPage
    {
        public ListView ListView { get { return listaMenus; } }
        PaginaPrincipalViewModel ppVM = new PaginaPrincipalViewModel();
        public PaginaPrincipal()
        {
            InitializeComponent();
            this.BindingContext = ppVM;
        }
    }
}
