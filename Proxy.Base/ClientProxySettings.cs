

using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Proxy.Base
{

    public static class ClientProxySettings
    {
        public static string getValue(string seccion,string key)
        {
            try
            {
                IConfigurationBuilder _config;
                IConfigurationRoot root;
                IConfigurationSection rootSection;
                _config = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                _config.AddJsonFile(path, false);
                root = _config.Build();
                rootSection = root.GetSection(seccion);
                string valueReturn = string.Empty;
                string value = rootSection.GetSection(key).Value.ToString();

                return value;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}