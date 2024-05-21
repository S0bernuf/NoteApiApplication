using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NoteApplication.Database.Repositories;


namespace NoteApplication.Database
{
    public static class RepositoryExtentions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NoteDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
