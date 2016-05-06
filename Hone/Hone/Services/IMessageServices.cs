using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Services
{
    public interface IMessageServices
    {
        Task ShowAsync(string cabecalho, string message);

        Task<bool> ShowAsync(string cabecalho, string mensagem, string botaoOK, string botaoCANCEL);
    }
}
