using Microsoft.Extensions.DependencyInjection;
using SecurityBussines.Authenticator;
using SecurityBussines.Authenticator.IAuthenticator;
using SecurityBussines.User;
using SecurityBussines.User.Iuser;

namespace IocSecurity
{
   public static class InjectSecurity
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddSingleton<Isecurity, BussinesSecurity>();
            services.AddSingleton<IAuthenticatorBussines, AuthenticatorBussines>();
            return services;
        }
    }
}
