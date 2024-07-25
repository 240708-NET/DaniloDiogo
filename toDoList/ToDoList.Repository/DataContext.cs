using Microsoft.EntityFrameworkCore;
using ToDoList.Models;


namespace ToDoList.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

    }
}