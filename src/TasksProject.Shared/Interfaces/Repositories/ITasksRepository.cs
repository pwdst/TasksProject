namespace TasksProject.Shared.Interfaces.Repositories
{
    using System;
    using Attributes;

    public interface ITasksRepository
    {
        void AddTask(string title, string description);

        bool DeleteTask(Guid taskId);

        bool MarkComplete(Guid taskId);

        void PurgeDeleted();

        bool RestoreTask(Guid taskId);

        bool UpdateTask(Guid taskId, [NotNull] string title, string description = null);
    }
}
