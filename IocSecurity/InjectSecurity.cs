using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using SecurityBussines.Iuser;
using SecurityBussines.User;

namespace IocSecurity
{
   public static class InjectSecurity
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddSingleton<Isecurity, BussinesSecurity>();
            return services;
        }
    }
}
