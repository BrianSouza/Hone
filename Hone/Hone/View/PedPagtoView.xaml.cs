using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.ViewModel;
using Xamarin.Forms;

namespace Hone.View
{
    public partial class PedPagtoView : ContentPage
    {
        PedPagtoViewModel pedPagto = new PedPagtoViewModel();
        public PedPagtoView()
        {
            InitializeComponent();
            this.BindingContext = pedPagto;
            CarregarCondicoesPagamento();
            CarregarFormasPagamento();
            
        }
        private void CarregarFormasPagamento()
        {
            pckFormPagto.Items.Clear();
            foreach (var item in pedPagto.ListaFormaPagto)
            {
                pckFormPagto.Items.Add(item.Descript);
            }
        }

        private void CarregarCondicoesPagamento()
        {
            pckCondPagto.Items.Clear();
            foreach (var item in pedPagto.ListaCondPagto)
            {
                pckCondPagto.Items.Add(item.PymntGroup);
            }
        }
    }
}
