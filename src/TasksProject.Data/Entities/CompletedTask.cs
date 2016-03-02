namespace TasksProject.Data.Entities
{
    using System;
    using Shared.Interfaces.BusinessObjects;

    internal class CompletedTask : Task
    {
        internal DateTime CompletedOn { get; }
    }
}