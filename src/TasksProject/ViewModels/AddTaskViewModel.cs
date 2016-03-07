namespace TasksProject.ViewModels
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    [JsonObject]
    public class AddTaskViewModel
    {
        public const int TitleMaxLength = 200;

        public const int DescriptionMaxLength = 5000;

        [JsonProperty, MaxLength(TitleMaxLength), Required]
        public string Title { get; set; }

        [JsonProperty, MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
    }
}