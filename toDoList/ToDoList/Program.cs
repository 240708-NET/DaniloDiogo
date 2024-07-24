using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ToDoList;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ToDoListService toDoListService = new ToDoListService();

            toDoListService.menu();

        }

    }
}

