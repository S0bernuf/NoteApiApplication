using Microsoft.Extensions.DependencyInjection;

namespace NoteApplication.BussinesLogic
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            // Register business logic services, such as repositories or managers
            return services;
        }
    }
}
