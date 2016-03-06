namespace TasksProject.Data.Mapping
{
    using DeletedTask = Shared.Projections.DeletedTask;

    internal static class DeletedTaskMapping
    {
        internal static DeletedTask Map(Entities.DeletedTask deletedTask)
        {
            return new DeletedTask(deletedTask.Id, deletedTask.Title, deletedTask.CreatedOn, deletedTask.Description, deletedTask.DeletedOn);
        }
    }
}