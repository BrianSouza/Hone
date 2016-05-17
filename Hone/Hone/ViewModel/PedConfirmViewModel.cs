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
        private string _PN;
        private DateTime _DtEntrega;
        private string _CP;
        private string _FP;
        private ObservableCollection<Item> lstItem;
        private readonly IMessageServices _Message;
        private readonly INavigationService _Navigation;
        private readonly ISaveAndLoad _SaveAndLoad;
        private Pedido _Ped;

        public string PN
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

        public string CP
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

        public string FP
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
            PN = string.Format("{0} - {1}",Ped.Parceiro.CardCode,Ped.Parceiro.CardName);
            DtEntrega = Ped.DtEntrega;
            CP = Ped.CondPagto.PymntGroup;
            FP = Ped.FormaPgto.Descript;
            LstItem = Ped.Itens;
        }



    }
}
