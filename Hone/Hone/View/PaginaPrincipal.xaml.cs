
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
