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
            ListaParceiros = new List<Parceiro>
            {
                new Parceiro {CardCode = "C0001" , CardName = "Adam Diogo" },
                new Parceiro { CardCode = "C0002" , CardName = "Brian Diego"},
                new Parceiro {CardCode = "C0003", CardName = "Charles Felipe" }
            };

            NovoParceiro = new Command(IrParaViewCadPN);
            ExcluirParceiro = new Command<object>((param) =>
            {
                ExcluirPN((Parceiro)param);
            });

            FiltrarPN();
        }

        #region Variaveis
        private List<Parceiro> listaParceiros;
        private IEnumerable<Group<char, Parceiro>> listaFiltro;
        private string textoFiltro;
        private Parceiro selectedParceiro;
        #endregion

        #region Propriedades
        public List<Parceiro> ListaParceiros
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

        public IEnumerable<Group<char, Parceiro>> ListaFiltro
        {
            get
            {
                return listaFiltro;
            }

            set
            {
                listaFiltro = value;
                this.Notify("ListaFiltro");
            }
        }

        public string TextoFiltro
        {
            get
            {
                return textoFiltro;
            }

            set
            {
                textoFiltro = value;
                FiltrarPN();
                this.Notify("TextoFiltro");
            }
        }

        public Parceiro SelectedParceiro
        {
            get
            {
                return selectedParceiro;
            }

            set
            {
                selectedParceiro = value;
                this.Notify("SelectedParceiro");
            }
        }
        #endregion

        #region Commands
        public ICommand NovoParceiro
        {
            get; set;
        }
        public ICommand ExcluirParceiro
        {
            get; set;
        }
        #endregion

        #region Métodos
        private void IrParaViewCadPN()
        {
            _Navigation.NavigateTo(new View.CadPNView());
        }

        private void FiltrarPN()
        {

            IEnumerable<Parceiro> ListaFltrada = ListaParceiros;
            if (!string.IsNullOrEmpty(textoFiltro))
                ListaFltrada = ListaParceiros.Where(P => P.CardName.ToLower().Contains(textoFiltro.ToLower()));


            ListaFiltro = from pn in ListaFltrada
                          orderby pn.CardName
                          group pn by pn.CardName[0] into grupos
                          select new Group<char, Parceiro>(grupos.Key, grupos);
        }

        private void ExcluirPN(Parceiro pn)
        {
            if (pn != null)
            {
                ListaParceiros.Remove(pn);
                FiltrarPN();
            }
        }
        #endregion

    }
}
