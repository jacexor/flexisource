using Microsoft.Extensions.DependencyInjection;
using WebApplication5.Infrastructure.Services.Users;

namespace WebApplication5.Infrastructure.Services
{
    public static class IoCServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
