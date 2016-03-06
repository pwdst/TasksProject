namespace TasksProject.Data.Mapping
{
    using Task = Shared.Projections.Task;

    internal static class TaskMapping
    {
        internal static Task Map(Entities.Task task)
        {
            return new Task(task.Id, task.Title, task.CreatedOn, task.Description);
        }

        public static Task Map(Entities.CompletedTask completedTask)
        {
            return new Task(completedTask.Id, completedTask.Title, completedTask.CreatedOn,
                completedTask.Description, completedTask.CompletedOn);
        }
    }
}