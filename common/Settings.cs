using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace common
{
  public  class Settings
    {
        public string getValue(string seccion, string key)
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
