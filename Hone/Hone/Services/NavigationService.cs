using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hone.Services
{
    public class NavigationService : INavigationService
    {

        public NavigationService()
        {
        }
        public async Task NavigateToLogin()
        {
            await App.Current.MainPage.Navigation.PushAsync(new View.LoginView());
        }

        public async Task NavigateToMain()
        {
            await App.Current.MainPage.Navigation.PushAsync(new View.MainView());
        }
        public async Task NavigateToPedCabecalho()
        {
            await App.Current.MainPage.Navigation.PushAsync(new View.PedCabecalhoView());
        }
        public async Task NavigateToCadPN()
        {
            await App.Current.MainPage.Navigation.PushAsync(new View.CadPNView());
        }

        public async Task NavigateToPedItens()
        {
            await App.Current.MainPage.Navigation.PushAsync(new View.PedItensView());
        }

        public async Task NavigateToPedPagto()
        {
            await App.Current.MainPage.Navigation.PushAsync(new View.PedPagtoView());
        }

        public async Task NavigateToConfirm()
        {
            await App.Current.MainPage.Navigation.PushAsync(new View.PedConfirmView());
        }
    }
}
