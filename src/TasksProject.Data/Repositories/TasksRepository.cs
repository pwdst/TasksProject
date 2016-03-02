namespace TasksProject.Data.Repositories
{
    using Shared.Interfaces.Repositories;
    using System;
    using System.Linq;
    using Entities;
    using Interfaces.DataStore;

    internal sealed class TasksRepository : ITasksRepository
    {
        private readonly ITaskStore _taskStore;

        public TasksRepository(ITaskStore taskStore)
        {
            _taskStore = taskStore;
        }

        public void AddTask(string title, string description)
        {
            _taskStore.InProgressTasks.Add(new Task(title, description));
        }

        public bool DeleteTask(Guid taskId)
        {
            var inProgressTask = _taskStore.InProgressTasks.FirstOrDefault(ipt => ipt.Id.Equals(taskId));

            if (inProgressTask == null)
            {
                return false;
            }

            _taskStore.DeletedTasks.Add(new DeletedTask(inProgressTask));

            _taskStore.InProgressTasks.Remove(inProgressTask);

            return true;
        }

        public bool MarkComplete(Guid taskId)
        {
            var inProgressTask = _taskStore.InProgressTasks.FirstOrDefault(ipt => ipt.Id.Equals(taskId));

            if (inProgressTask == null)
            {
                return false;
            }

            _taskStore.CompletedTasks.Add(new CompletedTask(inProgressTask));

            _taskStore.InProgressTasks.Remove(inProgressTask);

            return true;
        }

        public void PurgeDeleted()
        {
            _taskStore.DeletedTasks.Clear();
        }

        public bool RestoreTask(Guid taskId)
        {
            var deletedTask = _taskStore.DeletedTasks.FirstOrDefault(dt => dt.Id.Equals(taskId));

            if (deletedTask == null)
            {
                return false;
            }

            var inProgressTask = (Task) deletedTask;

            _taskStore.InProgressTasks.Add(inProgressTask);

            _taskStore.DeletedTasks.Remove(deletedTask);

            return true;
        }

        public bool UpdateTask(Guid taskId, string title, string description)
        {
            var inProgressTask = _taskStore.InProgressTasks.FirstOrDefault(ipt => ipt.Id.Equals(taskId));

            if (inProgressTask == null)
            {
                return false;
            }

            inProgressTask.Title = title;

            inProgressTask.Description = description;

            return true;
        }
    }
}