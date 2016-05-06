using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Services
{
    public class MessageServices : IMessageServices
    {
        public async Task ShowAsync(string cabecalho, string message)
        {
            await App.Current.MainPage.DisplayAlert(cabecalho, message, "OK");
        }

        public async Task<bool> ShowAsync(string cabecalho, string mensagem, string botaoOK, string botaoCANCEL)
        {
            return await App.Current.MainPage.DisplayAlert(cabecalho, mensagem, botaoOK, botaoCANCEL);
        }

        public MessageServices()
        {

        }
    }
}
