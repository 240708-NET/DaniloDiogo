using ToDoList.Models;

namespace ToDoList.Repository{

    public class TaskRepository : ITaskRepository
    {
        DataContext context;
        public TaskRepository(){
            context = new DataContext();
        }
        public void delete(TaskItem taskItem){
                context.Tasks.Remove(taskItem);
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