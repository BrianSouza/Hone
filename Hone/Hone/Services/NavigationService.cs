﻿using System;
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

        public async Task NavigationToBegin()
        {
            var _master = (MasterDetailPage)App.Current.MainPage;
            var _nav = (NavigationPage)_master.Detail;
            await _nav.PopToRootAsync();
            _master.IsPresented = false;
        }

        public async Task NavigateTo(Page page)
        {
            var _master = (MasterDetailPage)App.Current.MainPage;
            var _nav = (NavigationPage)_master.Detail;
            await _nav.PushAsync(page);
            _master.IsPresented = false;
        }
        public async Task GoBack()
        {
            var _master = (MasterDetailPage)App.Current.MainPage;
            var _nav = (NavigationPage)_master.Detail;
            await _nav.PopAsync();

        }

        public void NatigateSetDetail(Page page)
        {
            var _master = (MasterDetailPage)App.Current.MainPage;
            _master.Detail = page;
            _master.IsPresented = false;
        }
    }
}
