namespace TasksProject.Data.ReadModels
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.DataStore;
    using Mapping;
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
            return _taskStore.DeletedTasks.Count;
        }

        public IEnumerable<DeletedTask> GetDeletedTasks()
        {
            return _taskStore.DeletedTasks.OrderBy(dt => dt.CreatedOn).Select(DeletedTaskMapping.Map).ToArray();
        }

        public IEnumerable<Task> GetTasks()
        {
            var inProgressTasks = _taskStore.InProgressTasks.Select(TaskMapping.Map);

            var completedTasks = _taskStore.CompletedTasks.Select(TaskMapping.Map);

            var combinedTasks = inProgressTasks.Union(completedTasks);

            return combinedTasks.OrderBy(t => t.CreatedOn).ToArray();
        }
    }
}