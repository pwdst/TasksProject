namespace TasksProject.Shared.Interfaces.BusinessObjects
{
    using System;

    public interface ITask
    {
        Guid Id { get; }

        string Title { get; set; }

        DateTime CreatedOn { get; }

        string Description { get; set; }
    }
}
