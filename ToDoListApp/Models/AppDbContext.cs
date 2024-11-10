using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskToDo> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
