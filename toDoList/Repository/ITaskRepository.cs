using toDoList.Models;

namespace toDoList.ITaskRepo{

    public interface ITaskRepository{

        void save(TaskItem taskItem);

        void update(TaskItem taskItem);
        List<TaskItem> list();
        void delete(TaskItem taskItem);

        
    }
}