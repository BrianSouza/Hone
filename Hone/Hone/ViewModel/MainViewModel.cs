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
        private readonly INavigationService _navigation;

        public MainViewModel()
        {
            this.GoCadPN = new Command(this.Parceiros);
            this.GoPedidos = new Command(this.Pedidos);
            this._navigation = DependencyService.Get<INavigationService>();
        }

        #region Cadastro de Parceiros
        public ICommand GoCadPN
        {
            get; set;
        }
        private async void Parceiros()
        {
            await this._navigation.NavigateToCadPN();
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
            await this._navigation.NavigateToPedCabecalho();

        }
        #endregion
    }
}
