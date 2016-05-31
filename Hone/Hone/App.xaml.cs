using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Services;
using Xamarin.Forms;

namespace Hone
{
    public partial class App  : Application
    {
        public App()
        {
            DependencyService.Register<IMessageServices, MessageServices>();
            DependencyService.Register<INavigationService, NavigationService>();
            // The root page of your application
            MainPage = new NavigationPage(new View.LoginView());
            InitializeComponent();
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
