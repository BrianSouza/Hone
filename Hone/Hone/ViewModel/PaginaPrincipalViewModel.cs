using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Entidades;

namespace Hone.ViewModel
{
    public class PaginaPrincipalViewModel : BaseViewModel
    {
        private ObservableCollection<PropriedadesMenuPrincipal> menus;

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

        public PaginaPrincipalViewModel()
        {
            CarregarMenus();
        }

        private void CarregarMenus()
        {
            Menus = new ObservableCollection<PropriedadesMenuPrincipal>
            {
                new PropriedadesMenuPrincipal { Title = "Home" , IconSource = "PN.png" , TargetType = typeof(View.HomeView)},
                new PropriedadesMenuPrincipal { Title = "Cadastro de Parceiros" , IconSource = "PN.png" , TargetType = typeof(View.CadPNView)},
                new PropriedadesMenuPrincipal { Title = "Cadastro de Pedidos" , IconSource = "PN.png" , TargetType = typeof(View.PedCabecalhoView)}
            };
        }
    }
}
