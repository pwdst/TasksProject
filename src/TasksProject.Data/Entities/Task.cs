namespace TasksProject.Data.Entities
{
    using System;
    using Shared.Interfaces.BusinessObjects;

    internal class Task : ITask
    {
        internal Task()
        {
            Id = Guid.NewGuid();

            CreatedOn = DateTime.UtcNow;
        }

        public Guid Id { get; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; }

        public string Description { get; set; }
    }
}
