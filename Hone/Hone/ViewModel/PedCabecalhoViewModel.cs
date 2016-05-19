using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Hone.Entidades;
using Hone.Services;
using Hone.ViewModel;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Hone.ViewModel
{
    public class PedCabecalhoViewModel : BaseViewModel , IPedido
    {

        #region Variaveis
        private int parceiroIndex;
        private Parceiro selectedParceiro;
        private ObservableCollection<Parceiro> parceiros;
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

        public int ParceiroIndex
        {
            get
            {
                return parceiroIndex;
            }
            set
            {
                parceiroIndex = value;
                SelectedParceiro = parceiros[parceiroIndex];
                this.Notify("ParceiroIndex");
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
        public ObservableCollection<Parceiro> Parceiros
        {
            get
            {
                return parceiros;
            }
            set
            {
                parceiros = value;
                this.Notify("Parceiros");
            }
        }
        #endregion

        #region Métodos
        private void PreencherParceiros()
        {
            Parceiros = new ObservableCollection<Parceiro>();
            Parceiros.Add(new Parceiro { CardCode = "00001", CardName = "Parceiro 1" });
            Parceiros.Add(new Parceiro { CardCode = "00002", CardName = "Parceiro 2" });
        }

        private bool Validacao()
        {
            if (SelectedParceiro == null)
            {
                _Message.ShowAsync("Atenção", "Selecione um Parceiro.");
                return false;
            }
            else return true;

        }

        private void IrParaViewLinhas()
        {
            if (!Validacao())
                return;

            PreencherPedido();
            SalvarTxtPedido();
            _Navigation.NavigateToPedItens();
        }

        public void PreencherPedido()
        {
            Ped = new Pedido();
            Ped.Parceiro = this.SelectedParceiro;
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
        public ICommand IrParaLinhas
        {
            get; set;
        }

        #endregion

        public PedCabecalhoViewModel()
        {
            PreencherParceiros();

            this.IrParaLinhas = new Command(IrParaViewLinhas);
        }
    }
}