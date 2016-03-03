namespace TasksProject.Shared.Projections
{
    using System;
    using Attributes;

    public class DeletedTask
    {
        public DeletedTask(Guid id, [NotNull] string title, DateTime createdOn, string description, DateTime deletedOn)
        {
            Id = id;

            Title = title;

            CreatedOn = createdOn;

            Description = description;

            DeletedOn = deletedOn;
        }

        public Guid Id { get; }

        public string Title { get; }

        public DateTime CreatedOn { get; }

        public string Description { get; }

        public DateTime DeletedOn { get; }
    }
}
