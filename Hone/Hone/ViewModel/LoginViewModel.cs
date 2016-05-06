using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hone.Services;
using Xamarin.Forms;

namespace Hone.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        string userName;
        string password;

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                this.Notify("Password");
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
                this.Notify("UserName");
            }
        }

        private readonly IMessageServices _message;
        private readonly INavigationService _navigation;
        public ICommand LoginCommand
        {
            get;
            set;
        }

        public LoginViewModel()
        {
            this._message = DependencyService.Get<IMessageServices>();
            this._navigation = DependencyService.Get<INavigationService>();
            this.LoginCommand = new Command(this.Login);
        }

        private void Login()
        {
            this._navigation.NavigateToMain();
        }
    }
}
