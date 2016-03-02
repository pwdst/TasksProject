namespace TasksProject.Data.Entities
{
    using System;

    internal class DeletedTask : Task
    {
        public DateTime DeletedOn { get; }
    }
}