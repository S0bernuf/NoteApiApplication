using Microsoft.Extensions.DependencyInjection;

;

namespace NoteApplication.Database
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connnectionString)
        {
            services.AddScoped<>();
            services.AddDbContext<>(options => options.UseSqlServer(connnectionString));

            return services;
        }
    }
}
