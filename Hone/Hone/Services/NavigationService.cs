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

        public async Task NavigateTo(Page page)
        {
            var _master = (MasterDetailPage)App.Current.MainPage;
            var _nav = (NavigationPage)_master.Detail;
            await _nav.PushAsync(page);

        }

        public async Task GoBack()
        {
            var _master = (MasterDetailPage)App.Current.MainPage;
            var _nav = (NavigationPage)_master.Detail;
            await _nav.PopAsync();

        }
        
    }
}
