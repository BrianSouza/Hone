using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;

namespace Hone.Services
{
    interface IDadosConfig
    {
        string Diretorio { get; }

        ISQLitePlatform Plataforma {get;}
    }
}
