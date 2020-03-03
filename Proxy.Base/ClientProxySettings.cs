

using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using SecurityModel;

namespace Proxy.Base
{

    public static class ClientProxySettings
    {
        private const string constServicesRoot = "Services";
        private const string constEndPoint = "EndPoint"; 
        private const string constMaxReceivedMessageSize = "MaxReceivedMessageSize";
        private const string constMaxBufferSize = "MaxBufferSize";
        private const string constCloseTimeout = "CloseTimeout";
        private const string constOpenTimeout = "OpenTimeout";
        private const string constUsername = "Username";
        private const string constPassword = "Password";
        public static HttpConfigureServices getValue(string servicesName)
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
                rootSection = root.GetSection(string.Format("{0}:{1}", constServicesRoot, servicesName));
                HttpConfigureServices httpConfigureServices = new HttpConfigureServices();
                httpConfigureServices.endpointUrl = getPropertyString(constEndPoint, rootSection);
                httpConfigureServices.maxReceivedMessageSize= getStructNumber<long>(constMaxReceivedMessageSize, rootSection);
                httpConfigureServices.maxBufferSize = getStructNumber<int>(constMaxBufferSize, rootSection);
                httpConfigureServices.closeTimeout = getTimeSpan(constCloseTimeout, rootSection);
                httpConfigureServices.openTimeout = getTimeSpan(constOpenTimeout, rootSection);
                httpConfigureServices.userName = getPropertyString(constUsername, rootSection);
                httpConfigureServices.password = getPropertyString(constPassword, rootSection);
                return httpConfigureServices;
            }
            catch
            {
                return null;
            }
        }

        private static string getPropertyString(string property, IConfigurationSection rootSection)
        {
            try
            {
                if (rootSection.GetSection(property).Exists())
                {
                    return rootSection.GetSection(property).Value.ToString();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        private static T? getStructNumber<T>(string property, IConfigurationSection rootSection) where T : struct
        {
            try
            {
                Type type = typeof(T);
                if (rootSection.GetSection(property).Exists())
                {
                    return (T)Convert.ChangeType(rootSection.GetSection(property).Value.ToString(), type);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        private static TimeSpan? getTimeSpan(string property, IConfigurationSection rootSection)
        {
            try
            {
                TimeSpan timeSpan= new TimeSpan();
                if (TimeSpan.TryParse(rootSection.GetSection(property).Value.ToString(), out timeSpan))
                {
                    return timeSpan;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}