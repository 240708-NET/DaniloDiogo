using ToDoList.Models;

namespace ToDoList.Repository{

    public interface ITaskRepository{

        void save(TaskItem taskItem);

        void update(TaskItem taskItem);
        List<TaskItem> list();
        void delete(TaskItem taskItem);

        
    }
}