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
using Hone.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Hone.ViewModel
{
    public class PedConfirmViewModel : BaseViewModel,IPedido
    {
        #region Variaveis
        private string _PN;
        private string _DtEntrega;
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

        public string DtEntrega
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
            DtEntrega = Ped.DtEntrega.ToString("dd/MM/yyyy");
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
            //TODO: verificar como fazer transaction
            using (AcessarDados _Dados = new AcessarDados())
            {
                Pedidos pedidos = new Pedidos();
                pedidos.CardCode = Ped.Parceiro.CardCode;
                pedidos.CardName = Ped.Parceiro.CardName;
                pedidos.CondPagto = Convert.ToString(Ped.CondPagto.GroupNum);
                pedidos.DtCadastro = Ped.DtCadastro;
                pedidos.DtEntrega = Ped.DtEntrega;
                pedidos.FormaPgto = Ped.FormaPgto.PayMethCod;
                pedidos.Id = Ped.Id;

                if (Ped.Id == 0)
                    _Dados.Insert<Pedidos>(pedidos);
                else if (Ped.Id > 0)
                    _Dados.Update<Pedidos>(pedidos);

                foreach (var item in Ped.Itens)
                {
                    Itens itens = new Itens();
                    itens.ItemCode = item.ItemCode;
                    itens.ItemName = item.ItemName;
                    itens.Quantidade = item.Quantidade;
                    itens.ValorUnit = item.ValorUnit;

                    _Dados.Insert<Itens>(itens);
                }
            }


            _Navigation.NavigationToBegin();
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
