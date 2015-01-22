using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace WebSite.Classes.Tools
{
    public static class FileUploadTools
    {
        public static String RelariveFileName(String fileName,String pathName)
        {
            var path = ConfigurationSettings.AppSettings[pathName];

            //if (!IsDirecroryExists(path))
            //    throw new Exception("the directory is not exits");

            var newFileName = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(fileName);

            if(extension==null)
                throw new NullReferenceException("The file extension is null ...");

            return string.Format("{0}/{1}{2}", path, newFileName, extension);
                
        }

        public static String GetThumbFilename(String fileName)
        {
            var physicalPath = Path.GetDirectoryName(fileName);
            string thumbfilename =
                    Path.GetFileNameWithoutExtension(fileName)
                    + "_Thumb"
                    + Path.GetExtension(fileName);

            return physicalPath + "\\" + thumbfilename;
            
        }

        public static Boolean IsDirecroryExists(string path)
        {
            var di = new DirectoryInfo(path);
            return di.Exists;
        }

        public static void RemoveFile(String fileName, String pathName)
        {
            var path = ConfigurationSettings.AppSettings[pathName];
            
           //if(!IsDirecroryExists(path)) 
           //    throw new Exception("the directory is not exits");

            File.Delete(fileName);
            File.Delete(GetThumbFilename(fileName));
        }
    }
}