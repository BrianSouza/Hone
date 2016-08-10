using System;
using System.Collections.Generic;
using System.Text;
using Hone.Dados;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(Hone.iOS.Dados.ConfigDados))]
namespace Hone.iOS.Dados
{
    public class ConfigDados : IConfigDados
    {
        private string diretorioDB;
        private ISQLitePlatform plataforma;
        public string DiretorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(diretorioDB))
                {
                    var diretorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    diretorioDB = System.IO.Path.Combine(diretorio, "..", "Library");
                }
                return diretorioDB;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (plataforma == null)
                {
                    plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return plataforma;
            }
        }

        public ConfigDados()
        {

        }
    }
}
