namespace TasksProject.Shared.Projections
{
    using System;
    using Attributes;

    public class Task
    {
        public Task(Guid id, [NotNull] string title, DateTime createdOn, string description)
        {
            Id = id;

            Title = title;

            CreatedOn = createdOn;

            Description = description;
        }

        public Task(Guid id, [NotNull] string title, DateTime createdOn, string description, DateTime completedOn)
        {
            Id = id;

            Title = title;

            CreatedOn = createdOn;

            Description = description;

            CompletedOn = completedOn;
        }

        public Guid Id { get; }

        public string Title { get; }

        public DateTime CreatedOn { get; }

        public string Description { get; }

        public DateTime? CompletedOn { get; }

        public bool IsCompleted => CompletedOn.HasValue;
    }
}