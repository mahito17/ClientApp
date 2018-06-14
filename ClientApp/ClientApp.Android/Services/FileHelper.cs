using System;
using System.IO;
using ClientApp.Droid.Services;
using ClientApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace ClientApp.Droid.Services
{
    public class FileHelper : IFileHelper
    {

        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
            //Verificar esta clase por que genera error

        }
    }
}
