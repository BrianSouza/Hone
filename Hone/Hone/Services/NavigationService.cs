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
        public void NavigateToLogin()
        {
            App.Current.MainPage = new View.LoginView();
        }

        public void NavigateToMain()
        {
            App.Current.MainPage = new View.MainView();
        }
        //public async Task NavigateToPedCabecalho()
        //{
        //    await App.Current.MainPage.Navigation.PushAsync(new View.PedCabecalhoView());
        //}
        //public async Task NavigateToCadPN()
        //{
        //    await App.Current.MainPage.Navigation.PushAsync(new View.CadPNView());
        //}

        public void NavigateToPedItens()
        {
            MasterDetailPage master = (MasterDetailPage)App.Current.MainPage;
            master.Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(View.PedItensView)));
        }

        public void NavigateToPedPagto()
        {
            MasterDetailPage master = (MasterDetailPage)App.Current.MainPage;
            master.Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(View.PedPagtoView)));
        }

        public void NavigateToConfirm()
        {
            MasterDetailPage master = (MasterDetailPage)App.Current.MainPage;
            master.Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(View.PedConfirmView)));
        }
    }
}
