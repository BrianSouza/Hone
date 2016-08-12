using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Dados;
using Hone.Dados.Services;
using Hone.Services;
using Xamarin.Forms;

namespace Hone
{
    public partial class App  : Application
    {
        public App()
        {
            try
            {
                DependencyService.Register<IMessageServices, MessageServices>();
                DependencyService.Register<INavigationService, NavigationService>();
                DependencyService.Register<IAcessarDados, Dados.AcessarDados>();

                // The root page of your application
                MainPage = new NavigationPage(new View.LoginView());
                InitializeComponent();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            try
            {
                var registrarTabelas = DependencyService.Get<IAcessarDados>();
                registrarTabelas.CriarTabelas();
            }
            catch (Exception)
            {

                throw;
            }
            
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
