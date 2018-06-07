using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp.Services
{
   public interface IFileHelper
    {
        string GetLocalFilePatch(string filename);
    }
}
