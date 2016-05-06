using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hone.Services
{
    public class SaveAndLoad : ISaveAndLoad
    {
        public string LoadText(string filename)
        {
            return DependencyService.Get<ISaveAndLoad>().LoadText(filename);
        }

        public void SaveText(string filename, string text)
        {
            DependencyService.Get<ISaveAndLoad>().SaveText(filename, text);
        }
    }
}
