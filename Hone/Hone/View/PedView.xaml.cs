using Hone.ViewModel;
using Xamarin.Forms;

namespace Hone.View
{
    public partial class PedView : ContentPage
    {
        PedViewModel pedVM = null;
        public PedView()
        {
            InitializeComponent();
            pedVM = new PedViewModel();
            this.BindingContext = pedVM;
        }
    }
}
