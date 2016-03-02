namespace TasksProject.Data.Entities
{
    using System;
    using Shared.Interfaces.BusinessObjects;

    internal class DeletedTask : Task
    {
        public DeletedTask(ITask task) : base(task)
        {
            DeletedOn = DateTime.UtcNow;
        }

        public DateTime DeletedOn { get; }
    }
}