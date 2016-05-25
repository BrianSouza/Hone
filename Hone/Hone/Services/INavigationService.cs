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
        //Task NavigateToCadPN();
        //Task NavigateToPedCabecalho();
        void NavigateToPedItens();
        void NavigateToPedPagto();
        void NavigateToConfirm();
    }
}
