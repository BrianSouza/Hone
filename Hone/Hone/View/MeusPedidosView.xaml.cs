using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.ViewModel;
using Xamarin.Forms;

namespace Hone.View
{
    public partial class MeusPedidosView : ContentPage
    {
        MeusPedidosViewModel mpVM = new MeusPedidosViewModel();
        public MeusPedidosView()
        {
            InitializeComponent();
            this.BindingContext = mpVM;
            PreencherPickerStatus();
        }

        private void PreencherPickerStatus()
        {
            this.pckStatusPedido.Items.Clear();
            if(mpVM.ListaStatusPedido.Count > 0)
            {
                foreach (var item in mpVM.ListaStatusPedido)
                {
                    this.pckStatusPedido.Items.Add(item.StatusName);
                }
            }
        }
    }
}
