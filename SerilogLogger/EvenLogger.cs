using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CommonModel;
using Microsoft.Extensions.Configuration;
using Serilog;
using SerilogLogger.Interface;

namespace SerilogLogger
{
    public class EvenLogger : IEvenLog
    {
        public EvenLogger()
        {
            // fuentes https://github.com/jernejk/AspNetCoreSerilogExample/pull/3/files
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var configuration = new ConfigurationBuilder()
            .AddJsonFile(path, optional: false, reloadOnChange: true)
            .Build();

            var loggerConfiguration = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext();

            Log.Logger = loggerConfiguration.CreateLogger();
        }

        public ErrorCommon Error(string exMessage, string userMesage, string site)
        {
            Log.Error(exMessage);
            ErrorCommon errorCommon = new ErrorCommon
            {
                UserMessage = userMesage,
                Site = site
            };
            return errorCommon;
        }

        public void Error(string exMessage)
        {
            Log.Error(exMessage);
        }

        public ErrorCommon Error(string exMessage, string userMesage)
        {
            Log.Error(exMessage);
            ErrorCommon errorCommon = new ErrorCommon
            {
                UserMessage = userMesage,
                Site = "Ha ocurrido un error en la aplicación"
            };
            return errorCommon;
        }
    }
}

