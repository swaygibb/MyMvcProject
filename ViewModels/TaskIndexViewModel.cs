namespace MyMvcProject.ViewModels
{
    public class TaskIndexViewModel
    {
        public required List<Models.Task> Tasks { get; set; }
        public TaskSummary Summary { get; set; }
    }
}
