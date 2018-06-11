using System;
using System.IO;
using ClientApp.iOS.Services;
using ClientApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace ClientApp.iOS.Services
{
    public class FileHelper : IFileHelper
    {
        public FileHelper()
        {

        }
        public string GetLocalFilePatch(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, fileName);
        }
    }
}