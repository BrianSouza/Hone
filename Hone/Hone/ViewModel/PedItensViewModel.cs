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

namespace Hone.ViewModel
{
    public class PedItensViewModel : BaseViewModel
    {
        private int itemIndex;
        private Item item;
        private ObservableCollection<Item> itens;
        private double quantidade;
        private double valorUnit;
        private ObservableCollection<Item> itensSelecionados;
        private readonly IMessageServices _Message;
        private readonly INavigationService _Navigation;
        private readonly ISaveAndLoad _SaveAndLoad;

        public PedItensViewModel()
        {
            this._Message = DependencyService.Get<IMessageServices>();
            this._Navigation = DependencyService.Get<INavigationService>();
            this._SaveAndLoad = DependencyService.Get<ISaveAndLoad>();
            this.IrParaPgto = new Command(Pagto);
            this.SelecionarItens = new Command(SelecionaItem);
            ItensSelecionados = new ObservableCollection<Item>();
            CarregarItens();
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
                _Item.Quantidade = quantidade;
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
                _Item.ValorUnit = valorUnit;
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
        

        public ICommand IrParaPgto
        {
            get;set;
        }
        
        private void Pagto()
        {
            this._Navigation.NavigateToPedPagto();
        }

        private void CarregarItens()
        {
            Itens = new ObservableCollection<Item>
            {
                new Entidades.Item { ItemCode = "Item 1", ItemName = "Nome Item 1" },
                new Entidades.Item {ItemCode = "Item 2", ItemName = " Nome Item 2" }
            };
        }
        
        public ICommand SelecionarItens
        {
            get;
            set;
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
            bool valido = true;
            if (_Item == null || string.IsNullOrEmpty(_Item.ItemCode))
            {
                _Message.ShowAsync("Atenção", "Selecione um item.");
                valido = false;
            }
            else if (_Item.ValorUnit <= 0)
            {
                _Message.ShowAsync("Atenção", "O valor unitário deve ser maior do que zero.");
                valido = false;
            }
            else if (_Item.Quantidade <= 0)
            {
                _Message.ShowAsync("Atenção", "Quantidade selecionada deve ser maior do que zaro.");
                valido = false;
            }
            return valido;


        }
        private bool ItemDuplicado(Item item)
        {
            var duplicado = itensSelecionados.Where(t0 => t0.ItemCode.Equals(item.ItemCode)).SingleOrDefault();
            if (duplicado == null) return false;
            else return true;
        }


    }
}
