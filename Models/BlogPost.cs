namespace MyMvcProject.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public required string Title { get; set; } = "";
        public required string Content { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // A Func that orders and returns the posts, Func: filtering, soting, any other transformations on the queryable collection
        public static Func<IQueryable<BlogPost>, IQueryable<BlogPost>> RecentPosts =
            query => query.OrderByDescending(p => p.CreatedAt);

        // Property for formatted date
        public string CreatedAtFormatted => CreatedAt.ToString("MMMM dd, yyyy");
    }
}
