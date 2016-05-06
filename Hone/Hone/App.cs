﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hone.Services;
using Xamarin.Forms;

namespace Hone
{
    public class App : Application
    {
        public App()
        {
            DependencyService.Register<IMessageServices, MessageServices>();
            DependencyService.Register<INavigationService, NavigationService>();
            DependencyService.Register<ISaveAndLoad, SaveAndLoad>();
            // The root page of your application
            MainPage = new NavigationPage(new View.LoginView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
