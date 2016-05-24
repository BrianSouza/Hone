using System;
using Hone.Entidades;
using Xamarin.Forms;

namespace Hone.View
{
    public partial class MainView : MasterDetailPage
    {
        public MainView()
        {
            ViewModel.MainViewModel mVM = new ViewModel.MainViewModel();
            InitializeComponent();
            this.BindingContext = mVM;
            //masterPage.ListView.ItemSelected += OnItemSelected;
            masterPage.ListView.SetBinding(ListView.SelectedItemProperty, "GoPedidos");
            masterPage.ListView.SelectedItem = mVM.GoPedidos;
            if (Device.OS == TargetPlatform.Windows)
            {
                Master.Icon = "icon.png";
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PropriedadesMenuPrincipal;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    
    }
}
