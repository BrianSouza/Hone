using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hone.Dados
{
    public class AcessarDados<T> : IDisposable
    {
        SQLite.Net.SQLiteConnection _conexao;
        public AcessarDados()
        {
            var config = DependencyService.Get<IConfigDados>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB,"HoneDB.db3"));

            _conexao.CreateTable<T>();
        }

        public void Insert<T>(T tabela)
        {
            _conexao.Insert(tabela);
        }
        public void Delete<T>(T tabela)
        {
            _conexao.Delete(tabela);
        }
       

        public List<T> Listar<T>() where T : class
        {
            return _conexao.Table<T>().ToList();
        }
        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
