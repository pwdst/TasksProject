namespace TasksProject.Data.Interfaces.DataStore
{
    using System.Collections.Generic;
    using Entities;

    internal interface ITaskStore
    {
        List<Task> InProgressTasks { get; set; }

        List<DeletedTask> DeletedTasks { get; set; }

        List<CompletedTask> CompletedTasks { get; set; }
    }
}
