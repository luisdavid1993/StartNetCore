using Microsoft.Extensions.DependencyInjection;
using SerilogLogger;
using SerilogLogger.Interface;

namespace IocLogger
{
   public static class InjectSerilog
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IEvenLog, EvenLogger>();
            return services;
        }
    }
}
