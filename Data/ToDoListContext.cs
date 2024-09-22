using Microsoft.EntityFrameworkCore;
using OLA2_SofQuality.Models;

namespace OLA2_SofQuality.Data;

public class ToDoListContext(DbContextOptions<ToDoListContext> options) : DbContext(options)
{
    public DbSet<ToDoTask> ToDoTasks { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoTask>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<ToDoTask>()
            .Property(t => t.Id)
            .ValueGeneratedOnAdd();
    }
}