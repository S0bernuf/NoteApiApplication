using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NoteApplication.Database
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NoteDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
