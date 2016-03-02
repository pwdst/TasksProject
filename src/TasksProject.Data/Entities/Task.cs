namespace TasksProject.Data.Entities
{
    using System;
    using Shared.Attributes;
    using Shared.Interfaces.BusinessObjects;

    internal class Task : ITask
    {
        internal Task([NotNull] string title, string description)
        {
            Id = Guid.NewGuid();

            Title = title;

            CreatedOn = DateTime.UtcNow;

            Description = description;
        }

        protected Task(ITask task)
        {
            Id = task.Id;

            Title = task.Title;

            CreatedOn = task.CreatedOn;

            Description = task.Description;
        }

        public Guid Id { get; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; }

        public string Description { get; set; }
    }
}
