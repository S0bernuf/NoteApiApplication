using Microsoft.Extensions.DependencyInjection;
using NoteApplication.BusinessLogic.Services;

namespace NoteApplication.BussinesLogic
{
    public static class ServiceExtentions
    {
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();

        }
    }
}
