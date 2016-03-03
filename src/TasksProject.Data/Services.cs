using Microsoft.Extensions.DependencyInjection;

namespace TasksProject.Data
{
    using DataStore;
    using Interfaces.DataStore;
    using ReadModels;
    using Repositories;
    using Shared.Interfaces.ReadModels;
    using Shared.Interfaces.Repositories;

    public static class Services
    {
        public static void ConfigureDataServices(this IServiceCollection services)
        {
            services.AddSingleton<ITaskStore, TaskStore>();

            services.AddScoped<ITasksReadModel, TasksReadModel>();

            services.AddScoped<ITasksRepository, TasksRepository>();
        }
    }
}