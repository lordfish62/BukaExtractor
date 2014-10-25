using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BukaExtractor
{
    abstract class Extractor
    {
        public static readonly byte[] riff = { 0x52, 0x49, 0x46, 0x46 };

        public static string bukaFilePath;
        protected static string[] filesInDirectory;
        protected static string[] directoriesInDirectory;

        public static void setFilePath(string path)
        {
            bukaFilePath = path;

            filesInDirectory = Directory.GetFiles(bukaFilePath, "*buka");
            directoriesInDirectory = Directory.GetDirectories(bukaFilePath);
        }

        public static bool isBukaFormat()
        {
            if (filesInDirectory.Length != 0)
                return true;
            else
                return false;
        }

        public static bool isHBupViewFormat()
        {
            if (directoriesInDirectory.Length != 0)
                return true;
            else
                return false;
        }
        
        public abstract void extract();
    }
}
