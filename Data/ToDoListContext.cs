using Microsoft.EntityFrameworkCore;
using OLA2_SofQuality.Models;

namespace OLA2_SofQuality.Data
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options) { }

        public DbSet<ToDoTask> ToDoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<ToDoTask>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();
        }
    }
}