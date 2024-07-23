
using toDoList.ITaskRepo;
using toDoList.Models;

namespace toDoList.TaskRepo{

    public class TaskRepository : ITaskRepository
    {
        public void delete(TaskItem taskItem){

            using ( var context = new DataContext()){

                context.Tasks.Remove(taskItem);
                context.SaveChanges();
            }
        }

        public List<TaskItem> list(){

            using ( var context = new DataContext()){

                return context.Tasks.ToList();
            }
        }

        public void save(TaskItem taskItem){

            using (var context = new DataContext()){
                context.Add(taskItem);
                context.SaveChanges();
            }
        }

        public void update(TaskItem taskItem){

            using (var context = new DataContext()){

                TaskItem task = context.Tasks.Find(taskItem.Id);

                if(task != null){
                    task.Description = taskItem.Description;
                    task.Done = taskItem.Done;

                    context.SaveChanges();
                }
                
            }
        }

        public TaskItem getById(int id){

            using (var context = new DataContext()){

                return context.Tasks.Find(id);
            }

        }
    }
}