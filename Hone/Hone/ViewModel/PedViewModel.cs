using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Hone.Entidades;

namespace Hone.ViewModel
{
    public class PedViewModel : BaseViewModel
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
            PN = string.Format("{0} - {1}", Ped.Parceiro.CardCode, Ped.Parceiro.CardName);
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

        
     
        #endregion
        


        public PedViewModel()
        {
            CarregarTxtPedido();
            SetValues();
        }

    }
}
