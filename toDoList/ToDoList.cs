
/*
        TODO
        - Validate imputs
        - Add option to cancel the action
        - Menus can be better
        - Validate when you try to delete or set as complete and send an option that is not on the list.
    */
public class ToDoList {

    int menuChoice;
    List<Task> toDoList = new List<Task>();

    public ToDoList(){
        for(int i = 0; i < 3; i++){
            Task task = new Task();
            task.description = "Task" + i;
            toDoList.Add(task);
        }
    }



    public void menu(){

            Console.WriteLine("Select one option:");
            Console.WriteLine("1. List tasks");
            Console.WriteLine("2. New task");
            Console.WriteLine("3. Set task complete");
            Console.WriteLine("4. Delete task");
            Console.WriteLine("5. Exit");

            this.menuChoice = int.Parse(Console.ReadLine());  

            switch (this.menuChoice){
                case 1:
                    this.listTasks();
                    break;

                case 2:
                    this.newTask();
                    break;

                case 3:
                    this.setTaskComplete();
                    break;

                case 4:
                    this.deleteTask();
                    break;

                case 5:
                    break;

                default:
                    Console.WriteLine("Wrong option!");
                    this.menu();
                    break;
            }

    }

    public void listTasks(){
        if(toDoList.Count > 0){
            this.list();
        }else{
            Console.WriteLine("TODO List empty! ");
            Console.WriteLine("\n");
        }
        this.menu();
    }

    public void newTask(){
        //Console.Clear();
        Console.WriteLine("Enter the task description: ");
        Task task = new Task();
        task.description = Console.ReadLine();
        toDoList.Add(task);
        Console.WriteLine("\n");
        this.menu();
    }

    public void setTaskComplete(){
        //Console.Clear();
        this.list();
        Console.WriteLine("Enter the task number or 0 to cancel: ");
        int option;
        if (int.TryParse(Console.ReadLine(), out option)){
            if(option != 0){
                toDoList[option-1].done = true;
                Console.WriteLine($"Task {option} completed!");
                Console.WriteLine("\n");
                this.menu();
            }else{
                this.menu();
            }
        }else{
            Console.WriteLine("Invalid option! Try again.");
            this.setTaskComplete();
        }
    }

    public void deleteTask(){
        Console.WriteLine("Enter the task number you want to remove: ");
        int option = int.Parse(Console.ReadLine());
        toDoList.RemoveAt(option - 1);
        Console.WriteLine($"Task {option} removed!");
        this.menu();
    }

    public void list(){
        Console.WriteLine("\n");
        Console.WriteLine("------------------# TODO List #------------------");
        for(int i = 0; i < toDoList.Count; i++){
            Console.WriteLine($"{i+1} - ["+(toDoList[i].done ? "X" : " ")+"] "+toDoList[i].description);
        }
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("\n");
    }

    

    
}