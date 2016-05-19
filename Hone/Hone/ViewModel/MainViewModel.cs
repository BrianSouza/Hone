using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hone.Services;
using Xamarin.Forms;

namespace Hone.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            this.GoCadPN = new Command(this.Parceiros);
            this.GoPedidos = new Command(this.Pedidos);
        }

        #region Cadastro de Parceiros
        public ICommand GoCadPN
        {
            get; set;
        }
        private async void Parceiros()
        {
            await this._Navigation.NavigateToCadPN();
        }
        #endregion

        #region Pedidos
        public ICommand GoPedidos
        {
            get;
            set;
        }
        private async void Pedidos()
        {
            await this._Navigation.NavigateToPedCabecalho();

        }
        #endregion
    }
}
