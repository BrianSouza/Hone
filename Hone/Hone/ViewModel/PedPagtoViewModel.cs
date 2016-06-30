using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hone.Entidades;
using Hone.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Hone.ViewModel
{
    public class PedPagtoViewModel : BaseViewModel, IPedido
    {
        
        #region Variaveis
        private int formPagtoIndex;
        private FormaPgto formaPagto;
        private ObservableCollection<FormaPgto> listaFormaPagto;

        private int condPagtoIndex;
        private CondPagto condPgto;
        private ObservableCollection<CondPagto> listaCondPagto;

        private DateTime dtEntrega;
        private DateTime dataMin;

        private Pedido _Ped;
        #endregion

        #region Propriedades

        public Pedido Ped
        {
            get
            {
                return _Ped;
            }

            set
            {
                _Ped = value;
                this.Notify("Ped");
            }
        }

        public int FormPagtoIndex
        {
            get
            {
                return formPagtoIndex;
            }

            set
            {
                formPagtoIndex = value;
                FormaPagto = ListaFormaPagto[formPagtoIndex];
                this.Notify("FormPagtoIndex");
            }
        }

        public FormaPgto FormaPagto
        {
            get
            {
                return formaPagto;
            }

            set
            {
                formaPagto = value;
                this.Notify("FormaPagto");
            }
        }

        public ObservableCollection<FormaPgto> ListaFormaPagto
        {
            get
            {
                return listaFormaPagto;
            }

            set
            {
                listaFormaPagto = value;
                this.Notify("FormaPagto");
            }
        }

        public int CondPagtoIndex
        {
            get
            {
                return condPagtoIndex;
            }

            set
            {
                condPagtoIndex = value;
                CondPgto = ListaCondPagto[value];
                this.Notify("CondPagtoIndex");
            }
        }

        public CondPagto CondPgto
        {
            get
            {
                return condPgto;
            }

            set
            {
                condPgto = value;
                this.Notify("CondPgto");
            }
        }

        public ObservableCollection<CondPagto> ListaCondPagto
        {
            get
            {
                return listaCondPagto;
            }

            set
            {
                listaCondPagto = value;
                this.Notify("ListaCondPagto");
            }
        }

        public DateTime DtEntrega
        {
            get
            {
                return dtEntrega;
            }
            set
            {
                dtEntrega = value;
                this.Notify("DtEntrega");
            }
        }

        public DateTime DataMin
        {
            get
            {
                return dataMin;
            }

            set
            {
                dataMin = value;
                this.Notify("DataMin");
            }
        }
        #endregion

        #region Métodos
        private void CarregarListaFormaPgto()
        {
            ListaFormaPagto = new ObservableCollection<FormaPgto>
            {
                new FormaPgto {PayMethCod = "1" , Descript = "Forma 1" },
                new FormaPgto {PayMethCod = "2" , Descript = "Forma 2" }
            };
        }

        private void CarregarListaCondPagto()
        {
            ListaCondPagto = new ObservableCollection<CondPagto>
            {
                new CondPagto {GroupNum = 1 , PymntGroup = "A Vista" },
                new CondPagto {GroupNum = 2 , PymntGroup = "30 dias" }
            };
        }

        private async void IrParaViewConfirmacao()
        {
            if(Validacoes())
            {
                PreencherPedido();
                SalvarTxtPedido();
                await _Navigation.NavigateTo(new View.PedConfirmView());
            }
            
        }

        private bool Validacoes()
        {
            if (FormaPagto == null)
            {
                _Message.ShowAsync("Atenção", "Selecione uma forma de pagamento.");
                return false;
            }
            else if (CondPgto == null)
            {
                _Message.ShowAsync("Atenção", "Selecione uma condição de pagamento.");
                return false;
            }
            else if (DtEntrega.Date < DateTime.Now.Date)
            {
                _Message.ShowAsync("Atenção", "Data de entrega deve ser maior ou igual a data atual.");
                return false;
            }
            else
                return true;
        }

        public void PreencherPedido()
        {
            Ped.CondPagto = this.CondPgto;
            Ped.FormaPgto = this.FormaPagto;
            Ped.DtEntrega = this.DtEntrega.Date;
        }

        public void CarregarTxtPedido()
        {
            string jsonPedido = _SaveAndLoad.LoadText("Pedido.txt");
            Ped = JsonConvert.DeserializeObject<Pedido>(jsonPedido);
        }

        public void SalvarTxtPedido()
        {
            string ped = JsonConvert.SerializeObject(Ped);
            _SaveAndLoad.SaveText("Pedido.txt", ped);
        }
        #endregion

        #region Command
        public ICommand NavegarParaConfirmacao
        {
            get;set;
        }
        #endregion

        public PedPagtoViewModel()
        {
            Ped = null;
            Ped = new Pedido();
            CarregarTxtPedido();
            CarregarListaCondPagto();
            CarregarListaFormaPgto();
            DtEntrega = DateTime.Now;
            NavegarParaConfirmacao = new Command(IrParaViewConfirmacao);
        }
    }
}
