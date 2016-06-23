using System;
using System.Collections.ObjectModel;
using Hone.Entidades;

namespace Hone.ViewModel
{
    public class MeusPedidosViewModel : BaseViewModel
    {
        public MeusPedidosViewModel()
        {

        }

        public struct StatusPed
        {
            public int StatusId { get; set; }
            public string StatusName { get; set; }
        }

        private int selectedStatusIndex;
        private ObservableCollection<Pedido> lstPedidos;
        private DateTime dataDe;
        private DateTime dataAte;
        private StatusPed selectedStatus;

        

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

        public StatusPed SelectedStatus
        {
            get
            {
                return selectedStatus;
            }

            set
            {
                selectedStatus = value;
                Notify("SelectedStatus");
            }
        }
        public int SelectedStatusIndex
        {
            get { return selectedStatusIndex; }
            set
            {
                selectedStatusIndex = value;
                SelectedStatus = ListaStatusPedido[value];
                this.Notify("SelectedStatusIndex");
            }
        }
        public ObservableCollection<StatusPed> ListaStatusPedido = new ObservableCollection<StatusPed>
        {
            new StatusPed {StatusId = 0 , StatusName = "Todos" },
            new StatusPed {StatusId = 1 , StatusName = "Sincronizado" },
            new StatusPed {StatusId = 2 , StatusName = "Ñ Sincronizado" }

        };
    }
}
