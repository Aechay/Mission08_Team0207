using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0207.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );

            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { TaskId = 1, TaskName = "Fix urgent home issue", DueDate = new DateTime(2026, 2, 25), Quadrant = 1, CategoryId = 1, Completed = false },
                new TaskItem { TaskId = 2, TaskName = "Plan semester schedule", DueDate = new DateTime(2026, 3, 10), Quadrant = 2, CategoryId = 2, Completed = false },
                new TaskItem { TaskId = 3, TaskName = "Respond to non-urgent emails", DueDate = new DateTime(2026, 2, 27), Quadrant = 3, CategoryId = 3, Completed = false },
                new TaskItem { TaskId = 4, TaskName = "Browse social media", DueDate = null, Quadrant = 4, CategoryId = 4, Completed = false }
            );
        }
    }
}
