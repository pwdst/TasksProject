namespace TasksProject.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Shared.Projections;

    public class TasksListViewModel
    {
        public TasksListViewModel(IEnumerable<Task> tasks, int deletedTaskCount)
        {
            Tasks = tasks;

            DeletedTaskCount = deletedTaskCount;
        }

        public IEnumerable<Task> Tasks { get; }

        public int DeletedTaskCount { get; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
