
using System.Collections.ObjectModel;

using Hone.Entidades;

namespace Hone.ViewModel
{
    public class PaginaPrincipalViewModel : BaseViewModel
    {
        private ObservableCollection<PropriedadesMenuPrincipal> menus;
        private PropriedadesMenuPrincipal selectedMenu;
     
        public ObservableCollection<PropriedadesMenuPrincipal> Menus
        {
            get
            {
                return menus;
            }

            set
            {
                menus = value;
                this.Notify("Menus");
            }
        }

        public PropriedadesMenuPrincipal SelectedMenu
        {
            get
            {
                return selectedMenu;
            }

            set
            {
                selectedMenu = value;
                NavigateDetail(value);
                this.Notify("SelectedMenu");
            }
        }

        private async void NavigateDetail(PropriedadesMenuPrincipal pmp)
        {

            if (pmp != null)
            {
                await _Navigation.NavigateTo(pmp.TargetType);
            }
        }

        private void NavigateToDetail(PropriedadesMenuPrincipal pmp)
        {

            if (pmp != null)
            {
                _Navigation.NatigateSetDetail(pmp.TargetType);
            }
        }

        public PaginaPrincipalViewModel()
        {
            CarregarMenus();
        }

        private void CarregarMenus()
        {
            Menus = new ObservableCollection<PropriedadesMenuPrincipal>
            {
                new PropriedadesMenuPrincipal { Title = "Home" , IconSource = "house.png" , TargetType = new View.HomeView()},
                new PropriedadesMenuPrincipal { Title = "Cadastro de Parceiros" , IconSource = "group.png" , TargetType = new View.PNView()},
                new PropriedadesMenuPrincipal { Title = "Cadastro de Pedidos" , IconSource = "shoppingcart.png" , TargetType =new View.PedCabecalhoView()},
                new PropriedadesMenuPrincipal { Title = "Meus Pedidos" , IconSource = "shoppingbag.png" , TargetType = new View.MeusPedidosView()}
                //new PropriedadesMenuPrincipal { Title = "Sincronizar" , IconSource = "download-1.png" , TargetType = typeof(View.PedCabecalhoView)}
            };
        }
    }
}
