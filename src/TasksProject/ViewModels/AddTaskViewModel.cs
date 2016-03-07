namespace TasksProject.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddTaskViewModel
    {
        public const int TitleMaxLength = 200;

        public const int DescriptionMaxLength = 5000;

        [MaxLength(TitleMaxLength), Required]
        public string Title { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
    }
}
