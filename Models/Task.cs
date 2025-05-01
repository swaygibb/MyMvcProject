namespace MyMvcProject.Models
{
    public class Task
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; }


        // A Func that orders and returns the tasks, Func: filtering, soting, any other transformations on the queryable collection
        public static Func<IQueryable<Task>, IQueryable<Task>> RecentTasks =
            query => query.OrderByDescending(p => p.CreatedAt);
    }
}