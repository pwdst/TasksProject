namespace TasksProject.Data.Repositories
{
    using Shared.Interfaces.Repositories;
    using System;

    internal sealed class TasksRepository : ITasksRepository
    {
        public void AddTask(string title, string description)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTask(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public bool MarkComplete(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public void PurgeDeleted()
        {
            throw new NotImplementedException();
        }

        public bool RestoreTask(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTask(Guid taskId, string title, string description)
        {
            throw new NotImplementedException();
        }
    }
}
