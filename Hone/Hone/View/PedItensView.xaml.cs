using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.ViewModel;
using Xamarin.Forms;

namespace Hone.View
{
    public partial class PedItensView : ContentPage
    {
        PedItensViewModel pedItensVM = new PedItensViewModel();
        public PedItensView()
        {
            InitializeComponent();
            this.BindingContext = pedItensVM;
            CarregarItens();
        }
        private void CarregarItens()
        {
            pckItens.Items.Clear();
            foreach (var item in pedItensVM.Itens)
            {
                pckItens.Items.Add(item.ItemName);
            }
        }
    }
}
