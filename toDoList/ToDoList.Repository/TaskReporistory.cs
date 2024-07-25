using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Repository{

    public class TaskRepository : ITaskRepository
    {
        DataContext context;
        public TaskRepository(string connectionstring){
            DbContextOptions<DataContext> options;
            options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(connectionstring)
                .Options;
            context = new DataContext(options);
        }
        public void deleteById(int id){
            TaskItem taskFound = context.Tasks.Find(id);
            context.Tasks.Remove(taskFound);
            context.SaveChanges();
        }

        public List<TaskItem> list(){
                return context.Tasks.ToList();
        }

        public void save(TaskItem taskItem){
                context.Add(taskItem);
                context.SaveChanges();
        }

        public void update(TaskItem taskItem){

                TaskItem task = context.Tasks.Find(taskItem.Id);

                if(task != null){
                    task.Description = taskItem.Description;
                    task.Done = taskItem.Done;

                    context.SaveChanges();
                }
        }

        public TaskItem getById(int id){
                return context.Tasks.Find(id);
        }
    }
}