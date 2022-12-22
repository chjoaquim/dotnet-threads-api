using Microsoft.Extensions.Configuration;
using System;

namespace poc_carriers_threads.Domain
{
    public static class AppSettingsManager
    {
        private static IConfiguration _config;
        public static void ConfigureSettings(IConfiguration config)
        {
            try
            {
                _config = config ?? throw new ArgumentNullException("config");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static string GetAllConfigurations(string param1, string param2) => _config?.GetSection(param1)[param2];
    }
}

