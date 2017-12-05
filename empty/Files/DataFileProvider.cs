using Microsoft.Extensions.FileProviders;
using Persistence.JsonFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace empty.Files
{
    public class DataFileProvider : IDataFileProvider
    {
        private IFileProvider _fileProvider;
        public DataFileProvider()
        {
            var dataJsonDirectory = Path.Combine(Directory.GetCurrentDirectory(), "dataJson");
            if (!Directory.Exists(dataJsonDirectory))
            {
                Directory.CreateDirectory(dataJsonDirectory);
            }            
            _fileProvider = new PhysicalFileProvider(dataJsonDirectory);
        }

        public string GetFileText(string fileName)
        {            
            var fileInfo = GetJsonFileInfo(fileName);                            
            return fileInfo.Exists
                ? File.ReadAllText(fileInfo.PhysicalPath)
                : String.Empty;
        }

        public bool UpdateFileText(string fileName, string fileText)
        {
            fileName = MakeSureItIsJson(fileName);
            var fileInfo = _fileProvider.GetFileInfo(fileName);
            using (var logWriter = new StreamWriter(fileInfo.PhysicalPath))
            {
                logWriter.WriteAsync(fileText);
            }
            return true;
        }

        private IFileInfo GetJsonFileInfo(string fileName)
        {
            fileName = MakeSureItIsJson(fileName);
            return _fileProvider.GetFileInfo(fileName);
        }

        private string MakeSureItIsJson(string fileName)
        {
            if (!Path.HasExtension(fileName))
            {
                fileName = Path.ChangeExtension(fileName, ".json");
            }
            return fileName;
        }

        
    }
}
