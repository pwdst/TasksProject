namespace TasksProject.Data.ReadModels
{
    using System.Collections.Generic;
    using Shared.Interfaces.ReadModels;
    using Shared.Projections;

    internal class TasksReadModel : ITasksReadModel
    {
        public int DeletedTaskCount()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DeletedTask> GetDeletedTasks()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Task> GetTasks()
        {
            throw new System.NotImplementedException();
        }
    }
}
