namespace TasksProject.Shared.Interfaces.ReadModels
{
    using System.Collections.Generic;
    using Projections;

    public interface ITasksReadModel
    {
        int DeletedTaskCount();

        IEnumerable<DeletedTask> GetDeletedTasks();

        IEnumerable<Task> GetTasks();
    }
}
