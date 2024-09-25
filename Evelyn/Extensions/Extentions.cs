using Evelyn.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Evelyn.Web.Extensions
{
    public static class ApplicationConfigurationExtensions
    {
        public static void AddEvelynDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionStrings = configuration.GetConnectionString("Evelyn")!;

            services.AddDbContext<Context>(Options =>
                Options.UseSqlServer(connectionStrings));
        }
    }
}