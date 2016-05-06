using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.ViewModel;
using Xamarin.Forms;

namespace Hone.View
{
    public partial class PedCabecalhoView : ContentPage
    {
        PedCabecalhoViewModel pedCab = new PedCabecalhoViewModel();
        public PedCabecalhoView()
        {
            InitializeComponent();
            this.BindingContext = pedCab;
            FillListParceiros();
        }
        private void FillListParceiros()
        {
            pckParceiros.Items.Clear();

            foreach (var item in pedCab.Parceiros)
            {
                pckParceiros.Items.Add(item.CardName);
            }
        }
    }
}
