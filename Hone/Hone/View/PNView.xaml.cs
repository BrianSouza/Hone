using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.ViewModel;
using Xamarin.Forms;

namespace Hone.View
{
    public partial class PNView : ContentPage
    {
        PNViewModel pnVM = new PNViewModel();
        public PNView()
        {
            InitializeComponent();
            this.BindingContext = pnVM;
        }

        protected override void OnAppearing()
        {
            //TODO: Recarregar lista.
            base.OnAppearing();
            lstParceiro.SelectedItem = null;
            pnVM._SaveAndLoad.ExcludeFile("pn.txt");
            pnVM.AtualizarLista();
        }

       
    }
}
