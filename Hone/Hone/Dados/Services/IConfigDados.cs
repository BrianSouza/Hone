using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;

namespace Hone.Dados
{
    public interface IConfigDados
    {
        string DiretorioDB { get; }

        ISQLitePlatform Plataforma { get; }

    }
}
