

using Microsoft.Extensions.DependencyInjection;

namespace NoteApplication.BussinesLogic
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<>();
            return services;
        }
    }
}
