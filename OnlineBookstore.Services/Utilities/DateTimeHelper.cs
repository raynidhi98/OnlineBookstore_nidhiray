using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Services.Utilities
{
    public static class DateTimeHelper
    {
        public static string GetCurrentDateTime() => DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

        public static DateTime ConvertToUtc(DateTime localTime) => localTime.ToUniversalTime();
    }

}
