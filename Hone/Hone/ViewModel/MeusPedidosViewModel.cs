using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Entidades;

namespace Hone.ViewModel
{
    public class MeusPedidosViewModel : BaseViewModel
    {
        public MeusPedidosViewModel()
        {

        }

        private ObservableCollection<Pedido> lstPedidos;
        private DateTime dataDe;
        private DateTime dataAte;

        public DateTime DataAte
        {
            get
            {
                return dataAte;
            }

            set
            {
                dataAte = value;
                this.Notify("DataAte");
            }
        }

        public DateTime DataDe
        {
            get
            {
                return dataDe;
            }

            set
            {
                dataDe = value;
                this.Notify("dataDe");
            }
        }

        public ObservableCollection<Pedido> LstPedidos
        {
            get
            {
                return lstPedidos;
            }

            set
            {
                lstPedidos = value;
                this.Notify("LstPedidos");
            }
        }
    }
}
