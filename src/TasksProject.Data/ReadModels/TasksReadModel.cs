namespace TasksProject.Data.ReadModels
{
    using System.Collections.Generic;
    using Interfaces.DataStore;
    using Shared.Interfaces.ReadModels;
    using Shared.Projections;

    internal class TasksReadModel : ITasksReadModel
    {
        private readonly ITaskStore _taskStore;

        public TasksReadModel(ITaskStore taskStore)
        {
            _taskStore = taskStore;
        }

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
