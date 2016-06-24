using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hone.Entidades;
using Xamarin.Forms;

namespace Hone.ViewModel
{
    public class PNViewModel : BaseViewModel
    {
        public PNViewModel()
        {
            Filtrar = new Command(FiltrarPN);
        }

        private ObservableCollection<Parceiro> listaParceiros;

        public ICommand Filtrar
        {
            get;
            set;
        }

        public ObservableCollection<Parceiro> ListaParceiros
        {
            get
            {
                return listaParceiros;
            }

            set
            {
                listaParceiros = value;
                this.Notify("ListaParceiros");
            }
        }

        private IEnumerable<Group<char,Parceiro>> FiltrarPN()
        {
            return from pn in ListaParceiros
                   orderby pn.CardName
                   group pn by pn.CardName[0] into grupos
                   select new Group<char, Parceiro> ( grupos.Key, grupos );
        }
    }
}
