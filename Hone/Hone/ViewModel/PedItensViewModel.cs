using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Entidades;

namespace Hone.ViewModel
{
    public class PedItensViewModel : BaseViewModel
    {
        private int itemIndex;
        private Item item;
        private ObservableCollection<Item> itens;
        private double quantidade;
        private double valorUnit;

        public PedItensViewModel()
        {

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
    }
}
