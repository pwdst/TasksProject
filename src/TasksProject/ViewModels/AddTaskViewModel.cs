namespace TasksProject.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddTaskViewModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
