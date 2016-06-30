using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Entidades;
using Hone.ViewModel;
using Xamarin.Forms;

namespace Hone.View
{
    public partial class CadPNView : ContentPage
    {
        CadPNViewModel vmCadPN = new CadPNViewModel();
        public CadPNView()
        {
            InitializeComponent();
            this.BindingContext = this.vmCadPN;
            this.FillListEstados();
            this.FillListTipoPN();
            this.FillListTipoDoc();
        }
        private void FillListTipoDoc()
        {
            this.pckTipoDoc.Items.Clear();
            foreach (var item in vmCadPN.LstTipoDoc)
            {
                this.pckTipoDoc.Items.Add(item);
            }
        }
        private void FillListTipoPN()
        {
            this.pckTipoParc.Items.Clear();
            foreach (var item in vmCadPN.LstTipoParc)
            {
                this.pckTipoParc.Items.Add(item);
            }
        }
        private void FillListEstados()
        {
            this.pckEstados.Items.Clear();
            foreach (var item in vmCadPN.ListaEstados)
            {
                this.pckEstados.Items.Add(item.Sigla);
            }
        }
    }
}
