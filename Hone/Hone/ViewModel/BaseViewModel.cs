using System.ComponentModel;
using Hone.Services;
using Xamarin.Forms;

namespace Hone.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal readonly IMessageServices _Message;
        internal readonly INavigationService _Navigation;
        internal readonly ISaveAndLoad _SaveAndLoad;

        public BaseViewModel()
        {
            _Message = DependencyService.Get<IMessageServices>();
            _Navigation = DependencyService.Get<INavigationService>();
            _SaveAndLoad = DependencyService.Get<ISaveAndLoad>();
        }

        protected void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
