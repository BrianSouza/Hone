using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Entidades;
using System.Windows.Input;
using Xamarin.Forms;
using Hone.Services;
using Newtonsoft.Json;

namespace Hone.ViewModel
{
    public class PedItensViewModel : BaseViewModel , IPedido
    {
        #region Variaveis
        private int itemIndex;
        private Item item;
        private ObservableCollection<Item> itens;
        private double quantidade;
        private double valorUnit;
        private ObservableCollection<Item> itensSelecionados;
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

        public int ItemIndex
        {
            get
            {
                return itemIndex;
            }

            set
            {
                itemIndex = value;
                _Item = Itens[itemIndex];
                Quantidade = 0;
                ValorUnit = 0;
                this.Notify("ItemIndex");
            }
        }

        public Item _Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
                this.Notify("_Item");
            }
        }

        public ObservableCollection<Item> Itens
        {
            get
            {
                return itens;
            }

            set
            {
                itens = value;
                this.Notify("Itens");
            }
        }

        public double Quantidade
        {
            get
            {
                return quantidade;
            }

            set
            {
                quantidade = value;
                this.Notify("Quantidade");
            }
        }

        public double ValorUnit
        {
            get
            {
                return valorUnit;
            }

            set
            {
                valorUnit = value;
                this.Notify("ValorUnit");
            }
        }

        public ObservableCollection<Item> ItensSelecionados
        {
            get
            {
                return itensSelecionados;
            }

            set
            {
                itensSelecionados = value;
                this.Notify("ItensSelecionados");
            }
        }
        #endregion

        #region Commands
        public ICommand IrParaPgto
        {
            get;set;
        }

        public ICommand SelecionarItens
        {
            get;
            set;
        }
        #endregion

        #region Métodos

        private void IrParaViewPagto()
        {
            if (ValidaListaItensSelecionados())
            {
                PreencherPedido();
                SalvarTxtPedido();
                _Navigation.NavigateToPedPagto();
            }
        }

        private void CarregarItens()
        {
            Itens = new ObservableCollection<Item>
            {
                new Entidades.Item { ItemCode = "Item 1", ItemName = "Nome Item 1" },
                new Entidades.Item {ItemCode = "Item 2", ItemName = " Nome Item 2" }
            };
        }
        
        private void SelecionaItem()
        {
            if (!ValidaItemSelecionado())
                return;

            var itemAdd = new Item { ItemCode = _Item.ItemCode, ItemName = _Item.ItemName, Quantidade = this.Quantidade, ValorUnit = this.ValorUnit };

            if (!ItemDuplicado(itemAdd))
            {
                ItensSelecionados.Add(itemAdd);
            }
        }

        private bool ValidaItemSelecionado()
        {
            if (_Item == null || string.IsNullOrEmpty(_Item.ItemCode))
            {
                _Message.ShowAsync("Atenção", "Selecione um item.");
                return  false;
            }
            else if (ValorUnit <= 0)
            {
                _Message.ShowAsync("Atenção", "O valor unitário deve ser maior do que zero.");
                return  false;
            }
            else if (Quantidade <= 0)
            {
                _Message.ShowAsync("Atenção", "Quantidade selecionada deve ser maior do que zaro.");
                return  false;
            }

            _Item.Quantidade = Quantidade;
            _Item.ValorUnit = ValorUnit;

            return true;
            
        }

        private bool ItemDuplicado(Item item)
        {
            var duplicado = itensSelecionados.Where(t0 => t0.ItemCode.Equals(item.ItemCode)).SingleOrDefault();
            if (duplicado == null) return false;
            else return true;
        }

        private bool ValidaListaItensSelecionados()
        {
            if (ItensSelecionados.Count > 0)
                return true;
            else
            {
                _Message.ShowAsync("Atenção", "Adicione ao menos 1 item ao pedido.");
                return false;
            }
        }

        public void PreencherPedido()
        {
            Ped.Itens = ItensSelecionados;
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

        public PedItensViewModel()
        {
            Ped = null;
            Ped = new Pedido();
            CarregarTxtPedido();
            this.IrParaPgto = new Command(IrParaViewPagto);
            this.SelecionarItens = new Command(SelecionaItem);
            ItensSelecionados = new ObservableCollection<Item>();
            CarregarItens();
        }
    }
}
