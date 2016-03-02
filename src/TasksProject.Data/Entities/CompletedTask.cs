namespace TasksProject.Data.Entities
{
    using System;
    using Shared.Interfaces.BusinessObjects;

    internal class CompletedTask : Task
    {
        public CompletedTask(ITask task) : base(task)
        {
            CompletedOn = DateTime.UtcNow;
        }

        internal DateTime CompletedOn { get; }
    }
}