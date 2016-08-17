using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Dados.Services
{
    interface IAcessarDados
    {
        void Insert<T>(T tabela);
        void Update<T>(T tabela);
        void Delete<T>(T tabela);
        //List<T> Listar<T>() where T : class;
        //List<Parceiro> ListarParceiros();
        void CriarTabelas();
    }
}
