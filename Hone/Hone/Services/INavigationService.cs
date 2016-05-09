using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Services
{
    public interface INavigationService
    {
        Task NavigateToLogin();
        Task NavigateToMain();
        Task NavigateToCadPN();
        Task NavigateToPedCabecalho();
        Task NavigateToPedItens();
        Task NavigateToPedPagto();
    }
}
