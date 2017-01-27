using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Dados;
using Hone.Dados.CondPgto;
using Hone.Dados.FormaPgto;
using Hone.Dados.Pedidos;
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
                // The root page of your application
                RegistrarDepencencias();

                MainPage = new NavigationPage(new View.LoginView());
                InitializeComponent();
            }
            catch (Exception)
            {
                //TODO: Criar Log
            }

        }

        private static void RegistrarDepencencias()
        {
            DependencyService.Register<IMessageServices, MessageServices>();
            DependencyService.Register<INavigationService, NavigationService>();
            DependencyService.Register<ICrudItens, CrudItens>();
            DependencyService.Register<ICrudPedidos, CrudPedidos>();
            DependencyService.Register<ISalvarPedido, SalvarPedido>();
            DependencyService.Register<ICarregarPedidos, CarregarPedidos>();
            DependencyService.Register<ICondPgtos, CrudCondPgtos>();
            DependencyService.Register<ICrudFormaPgto, CrudFormaPgto>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            try
            {
                CriarBancoDeDados();
            }
            catch (Exception ex)
            {
                //TODO: Criar Log
            }
            
        }

        private static void CriarBancoDeDados()
        {
            using (AcessarDados dados = new AcessarDados())
            {
                dados.CriarTabelas();
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
