using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Dependency(typeof(FileHelper))]
namespace ClientApp.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public FileHelper()
        {
        }

        public string GetLocalFilePatch(string Filename)
        {
            string patch = Environment.GetFolderPatch(Environment.SpecialFolder.Personal);
            return Patch.Combine(patch, filename);
        }
    }
}