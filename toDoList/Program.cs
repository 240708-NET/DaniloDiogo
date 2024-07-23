using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ToDoList toDoList = new ToDoList();

            toDoList.menu();

        }

    }
}

