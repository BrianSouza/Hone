using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hone.Dados;
using Hone.Dados.Entidades;
using Hone.Entidades;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Hone.ViewModel
{
    public class PNViewModel : BaseViewModel
    {
        public PNViewModel()
        {
            //ListaParceiros = new List<Parceiro>
            //{
            //    new Parceiro {CardCode = "C0001" , CardName = "Adam Diogo" },
            //    new Parceiro { CardCode = "C0002" , CardName = "Brian Diego"},
            //    new Parceiro {CardCode = "C0003", CardName = "Charles Felipe" }
            //};
            CarregarParceiros();
            NovoParceiro = new Command(async () => await IrParaViewCadPN());
            ExcluirParceiro = new Command<object>(async (param) => 
            {
              await Task.Run(() => ExcluirPN((Parceiro)param));
            });
            //EditarParceiro = new Command<object>(async (param) =>
            //{
            //    await Task.Run(() => EditarPN((Parceiro)param));
            //});

            FiltrarPN();

            _SaveAndLoad.ExcludeFile("pn.txt");
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
                EditarPN(value);
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

        //public ICommand EditarParceiro
        //{
        //    get;set;
        //}
        #endregion

        #region Métodos
        private async Task IrParaViewCadPN()
        {
            await _Navigation.NavigateTo(new View.CadPNView());
        }

        private void FiltrarPN()
        {
            IEnumerable<Parceiro> ListaFltrada = FiltrarPNPorNome();
            AgruparResultados(ListaFltrada);
        }

        private void AgruparResultados(IEnumerable<Parceiro> ListaFltrada)
        {
            ListaFiltro = (from pn in ListaFltrada
                           orderby pn.CardName
                           group pn by pn.CardName[0] into grupos
                           select new Group<char, Parceiro>(grupos.Key, grupos));
        }

        private IEnumerable<Parceiro> FiltrarPNPorNome()
        {
            IEnumerable<Parceiro> ListaFltrada = ListaParceiros;
            if (!string.IsNullOrEmpty(textoFiltro))
                ListaFltrada = ListaParceiros.Where(P => P.CardName.ToLower().Contains(textoFiltro.ToLower()));
            return ListaFltrada;
        }

        private void ExcluirPN(Parceiro pn)
        {
            if (pn != null)
            {
                ListaParceiros.Remove(pn);
                FiltrarPN();
            }
        }
        
        private void EditarPN(Parceiro pn)
        {
            string parc = JsonConvert.SerializeObject(pn);
            _SaveAndLoad.SaveText("pn.txt", parc);
            _Navigation.NavigateTo(new View.CadPNView());
        }

        private void CarregarParceiros()
        {
            ListaParceiros = new List<Parceiro>();
            using (AcessarDados dados = new AcessarDados())
            {
                var parceiros = dados.Listar<Parceiros>();
                foreach (var item in parceiros)
                {
                    Parceiro pn = new Parceiro();
                    pn.Bairro = item.Bairro;
                    pn.CardCode = item.CardCode;
                    pn.CardName = item.CardName;
                    pn.Cep = item.Cep;
                    pn.Cidade = item.Cidade;
                    pn.Estado = item.Estado;
                    pn.Logradouro = item.Logradouro;
                    pn.NumDocumento = item.NumDocumento;
                    pn.NumeroLog = item.NumeroLog;
                    pn.Telefone = item.Telefone;
                    pn.TipoDocumento = item.TipoDocumento;
                    pn.TipoParceiro = item.TipoParceiro;
                    ListaParceiros.Add(pn);
                }
            }
        }
        #endregion

    }
}
