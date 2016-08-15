using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Dados.Entidades;
using Hone.Dados.Services;
using Xamarin.Forms;

namespace Hone.Dados
{
    public class AcessarDados : IDisposable , IAcessarDados
    {
        SQLite.Net.SQLiteConnection _conexao;
        public AcessarDados()
        {
            var config = DependencyService.Get<IConfigDados>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB,"HoneDB.db3"));
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

        public void CriarTabelas()
        {
           int retorno = _conexao.CreateTable<Parceiros>();
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
