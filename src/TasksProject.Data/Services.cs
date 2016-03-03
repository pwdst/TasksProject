using Microsoft.Extensions.DependencyInjection;

namespace TasksProject.Data
{
    using DataStore;
    using Interfaces.DataStore;
    using Repositories;
    using Shared.Interfaces.Repositories;

    public static class Services
    {
        public static void ConfigureDataServices(this IServiceCollection services)
        {
            services.AddSingleton<ITaskStore, TaskStore>();

            services.AddScoped<ITasksRepository, TasksRepository>();
        }
    }
}