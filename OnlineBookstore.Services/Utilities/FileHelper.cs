using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Services.Utilities
{
    public static class FileHelper
    {
        public static void SaveToFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public static string ReadFromFile(string path)
        {
            return File.Exists(path) ? File.ReadAllText(path) : string.Empty;
        }
    }
}
