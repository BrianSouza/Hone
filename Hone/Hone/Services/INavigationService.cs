using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Services
{
    public interface INavigationService
    {
        void NavigateToLogin();
        void NavigateToMain();
        Task NavigateTo(Xamarin.Forms.Page page);
        Task GoBack();

        Task NavigationToBegin();
    }
}
