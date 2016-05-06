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
    public class PedCabecalhoViewModel : BaseViewModel
    {
        public PedCabecalhoViewModel()
        {
            _message = DependencyService.Get<IMessageServices>();
            _navigation = DependencyService.Get<INavigationService>();
            _saveAndLoad = DependencyService.Get<ISaveAndLoad>();
            PreencherParceiros();
            DtEntrega = DateTime.Now;
            this.IrParaLinhas = new Command(Linhas);
        }
        private readonly IMessageServices _message;
        private readonly INavigationService _navigation;
        private readonly ISaveAndLoad _saveAndLoad;

        private Pedido pedido;
        private int parceiroIndex;
        private Parceiro selectedParceiro;
        private ObservableCollection<Parceiro> parceiros;
        private DateTime dtEntrega;
        private DateTime dataMin;

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

        private void PreencherParceiros()
        {
            Parceiros = new ObservableCollection<Parceiro>();
            Parceiros.Add(new Parceiro { CardCode = "00001", CardName = "Parceiro 1" });
            Parceiros.Add(new Parceiro { CardCode = "00002", CardName = "Parceiro 2" });
        }

        public ICommand IrParaLinhas
        {
            get; set;
        }

        private void Linhas()
        {
            if (Validacao())
                _navigation.NavigateToPedItens();
        }

        private bool Validacao()
        {
            if (SelectedParceiro == null)
            {
                _message.ShowAsync("Atenção", "Selecione um Parceiro.");
                return false;
            }
            else if (DtEntrega < DateTime.Now)
            {
                _message.ShowAsync("Atenção", "Selecione uma data maior ou igual a data atual.");
                return false;
            }
            else return true;

        }

        public Pedido Pedido
        {
            get
            {
                return pedido;
            }

            set
            {
                pedido = value;
                this.Notify("Pedido");
            }
        }

        private void SalvarTxtPedido()
        {
            Pedido.Parceiro = this.SelectedParceiro;
            Pedido.DtEntrega = this.DtEntrega;

            string ped = JsonConvert.SerializeObject(Pedido);
            _saveAndLoad.SaveText("pedido.txt", ped);
        }
    }
}