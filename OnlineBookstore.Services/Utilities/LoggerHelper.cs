using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Services.Utilities
{
    public static class LoggerHelper
    {
        private static readonly string LogFilePath = "logs/app.log";

        public static void Log(string message)
        {
            string logMessage = $"[{DateTime.UtcNow}] {message}\n";
            File.AppendAllText(LogFilePath, logMessage);
        }
    }
}
