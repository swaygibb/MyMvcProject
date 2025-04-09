using MyMvcProject.Models;

namespace MyMvcProject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            // Seed tasks
            if (!context.Tasks.Any())
            {
                var tasks = new Models.Task[]
                {
                    new Models.Task { Title = "Fix login bug", Description = "Users can't reset passwords from mobile view.", IsCompleted = false },
                    new Models.Task { Title = "Write blog post", Description = "Topic: Top 5 Productivity Tips for Developers.", IsCompleted = false },
                    new Models.Task { Title = "Weekly team sync", Description = "Prepare agenda and notes for Monday meeting.", IsCompleted = false },
                    new Models.Task { Title = "Code review for PR #42", Description = "Review John's latest pull request on GitHub.", IsCompleted = true },
                    new Models.Task { Title = "Deploy new version", Description = "Push v1.2.3 to staging environment.", IsCompleted = false },
                    new Models.Task { Title = "Update documentation", Description = "Add TaskManager API endpoints to README.", IsCompleted = false },
                };

                context.Tasks.AddRange(tasks);
            }

            // Seed blog posts
            if (!context.BlogPosts.Any())
            {
                var blogPosts = new BlogPost[]
                {
                    new BlogPost
                    {
                        Title = "Welcome to the Blog",
                        Content = "This is the very first post in the blog. Stay tuned for more updates!",
                        CreatedAt = DateTime.Now.AddDays(-5)
                    },
                    new BlogPost
                    {
                        Title = "Dark Mode Added!",
                        Content = "We just rolled out a slick dark mode to keep your eyes comfy at night.",
                        CreatedAt = DateTime.Now.AddDays(-4)
                    },
                    new BlogPost
                    {
                        Title = "Behind the Scenes",
                        Content = "A quick look at how we built the blog system using ASP.NET Core MVC.",
                        CreatedAt = DateTime.Now.AddDays(-3)
                    },
                    new BlogPost
                    {
                        Title = "Top 5 Dev Tips",
                        Content = "Here are 5 quick productivity hacks that every developer should know.",
                        CreatedAt = DateTime.Now.AddDays(-2)
                    },
                    new BlogPost
                    {
                        Title = "Upcoming Features",
                        Content = "We’re working on comments, tags, and maybe even markdown support. Let us know what you want!",
                        CreatedAt = DateTime.Now.AddDays(-1)
                    }
                };

                context.BlogPosts.AddRange(blogPosts);
            }

            context.SaveChanges();
        }
    }
}
