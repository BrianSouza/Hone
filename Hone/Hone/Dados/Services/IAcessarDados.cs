using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Dados.Services
{
    interface IAcessarDados
    {
        int Insert<T>(T tabela);
        int Update<T>(T tabela);
        int Delete<T>(T tabela);
        //List<T> Listar<T>() where T : class;
        //List<Parceiro> ListarParceiros();
        void CriarTabelas();
    }
}
