using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hone.Entidades;
using Hone.Services;
using Xamarin.Forms;

namespace Hone.ViewModel
{
    public class PedPagtoViewModel : BaseViewModel
    {
        private IMessageServices _message;
        private INavigationService _navigation;
        private ISaveAndLoad _saveAndLoad;
        public PedPagtoViewModel()
        {
            _message = DependencyService.Get<IMessageServices>();
            _navigation = DependencyService.Get<INavigationService>();
            _saveAndLoad = DependencyService.Get<ISaveAndLoad>();
            CarregarListaCondPagto();
            CarregarListaFormaPgto();
            DtEntrega = DateTime.Now;
            NavegarParaConfirmacao = new Command(IrParaConfirmacao);
        }

        private int formPagtoIndex;
        private FormaPgto formaPagto;
        private ObservableCollection<FormaPgto> listaFormaPagto;

        private int condPagtoIndex;
        private CondPagto condPgto;
        private ObservableCollection<CondPagto> listaCondPagto;

        private DateTime dtEntrega;
        private DateTime dataMin;

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

        public ICommand NavegarParaConfirmacao
        {
            get;set;
        }

        private void IrParaConfirmacao()
        {
            _navigation.NavigateToConfirm();
        }
    }
}
