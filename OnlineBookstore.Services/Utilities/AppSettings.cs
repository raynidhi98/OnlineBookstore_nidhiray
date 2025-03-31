using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;



public static class AppSettings
{
    public static IConfiguration Configuration { get; private set; }

    public static void Initialize(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public static string Get(string key) => Configuration?[key] ?? string.Empty;
}
