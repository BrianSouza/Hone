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
    public class PedConfirmViewModel : BaseViewModel,IPedido
    {
        #region Variaveis
        private string _PN;
        private DateTime _DtEntrega;
        private string _CP;
        private string _FP;
        private ObservableCollection<Item> lstItem;
        private Pedido ped;
        #endregion

        #region Propriedades
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
                return ped;
            }

            set
            {
                ped = value;
                this.Notify("Ped");
            }
        }
        #endregion

        #region Métodos
        private void SetValues()
        {
            PN = string.Format("{0} - {1}",Ped.Parceiro.CardCode,Ped.Parceiro.CardName);
            DtEntrega = Ped.DtEntrega;
            CP = Ped.CondPagto.PymntGroup;
            FP = Ped.FormaPgto.Descript;
            LstItem = Ped.Itens;
        }
        
        public void CarregarTxtPedido()
        {
            string jsonPedido = _SaveAndLoad.LoadText("Pedido.txt");
            Ped = JsonConvert.DeserializeObject<Pedido>(jsonPedido);
        }

        public void PreencherPedido()
        {
            throw new NotImplementedException();
        }

        public void SalvarTxtPedido()
        {
            throw new NotImplementedException();
        }

        private void SalvarPedido()
        {
            _Navigation.NavigateToMain();
        }
        #endregion

        #region Commands
        public ICommand Salvar
        {
            get;set;
        }
        #endregion


        public PedConfirmViewModel()
        {
            CarregarTxtPedido();
            SetValues();
            Salvar = new Command(SalvarPedido);
        }

    }
}
