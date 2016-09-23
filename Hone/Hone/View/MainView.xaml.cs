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
            MasterBehavior = MasterBehavior.Popover;
            if (Device.OS == TargetPlatform.Windows)
            {
                Master.Icon = "icon.png";
            }
            
        }
        
    }
}
