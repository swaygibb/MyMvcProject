using Microsoft.EntityFrameworkCore;
using MyMvcProject.Models;

namespace MyMvcProject.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<MyMvcProject.Models.Task> Tasks { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

    }
}
