using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{

    public class TaskItem{

        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; } = false;

        public List<TaskItem> subTasks { get; set; } = new List<TaskItem>();

        public TaskItem(){

        }

    }
}