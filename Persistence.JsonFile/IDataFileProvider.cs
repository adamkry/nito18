using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.JsonFile
{
    public interface IDataFileProvider
    {
        string GetFileText(string subPath);

        bool UpdateFileText(string subPath, string fileText);
    }
}
