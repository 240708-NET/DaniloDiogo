using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace toDoList.Models;

public class TaskItem{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Description { get; set; }

    public bool Done { get; set; } = false;

    public List<TaskItem> subTasks { get; set; } = new List<TaskItem>();

    public TaskItem(){

    }

}