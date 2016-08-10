
using System;
using Hone.iOS.Services;
using Hone.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoad))]
namespace Hone.iOS.Services
{
    public class SaveAndLoad : ISaveAndLoad
    {
        public void SaveText(string filename, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, filename);
            System.IO.File.WriteAllText(filePath, text);
        }
        public string LoadText(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, filename);
            if (System.IO.File.Exists(filePath))
                return System.IO.File.ReadAllText(filePath);
            else return string.Empty;
        }

        public void ExcludeFile(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, filename);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }

        public bool ValidateExist(string fileName)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, fileName);
            if (System.IO.File.Exists(filePath))
                return true;
            else
                return false;

        }
    }
}