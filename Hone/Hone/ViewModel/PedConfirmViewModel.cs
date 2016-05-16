using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Entidades;
using Hone.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Hone.ViewModel
{
    public class PedConfirmViewModel : BaseViewModel
    {
        private Parceiro _PN;
        private DateTime _DtEntrega;
        private CondPagto _CP;
        private FormaPgto _FP;
        private ObservableCollection<Item> lstItem;
        private readonly IMessageServices _Message;
        private readonly INavigationService _Navigation;
        private readonly ISaveAndLoad _SaveAndLoad;
        private Pedido _Ped;

        public Parceiro PN
        {
            get
            {
                return _PN;
            }

            set
            {
                _PN = value;
                this.Notify("PN");
            }
        }

        public DateTime DtEntrega
        {
            get
            {
                return _DtEntrega;
            }

            set
            {
                _DtEntrega = value;
                this.Notify("DtEntrega");
            }
        }

        public CondPagto CP
        {
            get
            {
                return _CP;
            }

            set
            {
                _CP = value;
                this.Notify("CP");
            }
        }

        public FormaPgto FP
        {
            get
            {
                return _FP;
            }

            set
            {
                _FP = value;
                this.Notify("FP");
            }
        }

        public ObservableCollection<Item> LstItem
        {
            get
            {
                return lstItem;
            }

            set
            {
                lstItem = value;
                this.Notify("LstItem");
            }
        }

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

        public PedConfirmViewModel()
        {
            _Message = DependencyService.Get<IMessageServices>();
            _Navigation = DependencyService.Get<INavigationService>();
            _SaveAndLoad = DependencyService.Get<ISaveAndLoad>();
            LoadPedido();
            SetValues();
        }

        private void LoadPedido()
        {
            string jsonPedido = _SaveAndLoad.LoadText("Pedido.txt");
            Ped = JsonConvert.DeserializeObject<Pedido>(jsonPedido);
        }
        private void SetValues()
        {
            PN = Ped.Parceiro;
            DtEntrega = Ped.DtEntrega;
            CP = Ped.CondPagto;
            FP = Ped.FormaPgto;
            LstItem = Ped.Itens;
        }



    }
}
