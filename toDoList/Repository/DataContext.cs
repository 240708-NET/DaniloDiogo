using Microsoft.EntityFrameworkCore;
using toDoList.Models;

public class DataContext : DbContext{

    //public DataContext(DbContextOptions<DataContext> options) : base(options){}

    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    string connectionString = File.ReadAllText("connectionstring");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlServer(connectionString);
    }
}