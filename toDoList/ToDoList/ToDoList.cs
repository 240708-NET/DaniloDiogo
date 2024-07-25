using ToDoList.Models;
using ToDoList.Repository;
﻿using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace ToDoList
{
    public class ToDoListService
    {

        int menuChoice;

        string errorMsg = "";
        List<TaskItem> toDoList = new List<TaskItem>();

        TaskRepository repository;

        HttpClient client;

        string baseurl = "http://localhost:5146/Task";

         

        public ToDoListService()
        {
            //TaskRepository repository = new TaskRepository(File.ReadAllText(@"../connectionstring"));
            client = new HttpClient();
        }

        public void menu()
        {
            Console.WriteLine("--------------------# TODO List Menu #---------------------");
            Console.WriteLine("Select one option:");
            Console.WriteLine("1. List tasks");
            Console.WriteLine("2. New task");
            Console.WriteLine("3. Set task complete");
            Console.WriteLine("4. Delete task");
            Console.WriteLine("5. Exit");
            Console.WriteLine("-------------------------------------------------");
            this.errorMsg = "";
            if (int.TryParse(Console.ReadLine(), out menuChoice))
            {

                switch (menuChoice)
                {
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
                        Console.Clear();
                        Console.WriteLine("Error: Wrong option! Try again.");
                        this.menu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error: Incorrect option! Try again.");
                this.menu();
            }

        }

        public async void listTasks()
        {
            
            try
            {
                toDoList = new List<TaskItem>();
                repository = new TaskRepository(File.ReadAllText(@"../connectionstring"));
                toDoList = repository.list();
                //string response = await client.GetStringAsync(baseurl);
                //toDoList = JsonSerializer.Deserialize<List<TaskItem>>(response);

                if (toDoList.Count > 0)
                {
                    Console.Clear();
                    this.list();
                }
                else
                {
                    Console.WriteLine("TODO List empty! ");
                    Console.WriteLine("\n");
                }
                this.menu();
            }catch(Exception e){
                Console.WriteLine("error");
                Console.WriteLine(e.Message);
            }
        }

        public void newTask()
        {
            Console.Clear();
            Console.WriteLine(this.errorMsg);
            Console.WriteLine("Enter the task description (2 characters at least) or 0 to cancel: ");
            TaskItem task = new TaskItem();
            task.Description = Console.ReadLine();
            if (!task.Description.Equals("0"))
            {
                if (task.Description.Length >= 2)
                {
                    //toDoList.Add(task);
                    //repository = new TaskRepository();
                    //this.repository.save(task);
                    client.PostAsync(baseurl, JsonContent.Create<TaskItem>(task));
                    Console.Clear();
                    Console.WriteLine($"Task '{task.Description}' successfully added!");
                    Console.WriteLine("\n");
                    this.menu();
                }
                else
                {
                    this.errorMsg = "Error: Minimum 2 characters need to be entered. Try again.";
                    this.newTask();
                }

            }
            else
            {
                Console.Clear();
                this.menu();
            }
        }

        public void setTaskComplete()
        {
            Console.Clear();
            Console.WriteLine(this.errorMsg);
            this.list();
            Console.WriteLine("Enter the task number or 0 to cancel: ");
            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                if (option != 0)
                {
                    if (toDoList.ElementAtOrDefault(option - 1) != null)
                    {
                        toDoList[option - 1].Done = true;
                        //repository = new TaskRepository();
                        //repository.update(toDoList[option - 1]);
                        client.PutAsync(baseurl, JsonContent.Create<TaskItem>(toDoList[option - 1]));
                        Console.Clear();
                        Console.WriteLine($"Task {option} set as completed!");
                        Console.WriteLine("\n");
                        this.menu();
                    }
                    else
                    {
                        this.errorMsg = $"Error: Task {option} not found! Try again.";
                        this.setTaskComplete();
                    }

                }
                else
                {
                    Console.Clear();
                    this.menu();
                }

            }
            else
            {
                Console.WriteLine("Error: Invalid option! Try again.");
                this.setTaskComplete();
            }
        }

        public void deleteTask()
        {
            try
            {
                Console.Clear();
                Console.WriteLine(this.errorMsg);
                this.list();
                Console.WriteLine("Enter the task number you want to remove or 0 to cancel: ");
                int option;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    if (option != 0)
                    {
                        if (toDoList.ElementAtOrDefault(option - 1) != null)
                        {
                            //toDoList.RemoveAt(option - 1);
                            //repository = new TaskRepository();
                            //repository.deleteById(toDoList[option - 1].Id);
                            client.DeleteAsync(baseurl + "/" + toDoList[option - 1].Id);
                            Console.Clear();
                            Console.WriteLine($"Task {option} removed!");
                            this.menu();
                        }
                        else
                        {
                            this.errorMsg = $"Error: Task {option} not found! Try again.";
                            this.deleteTask();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        this.menu();
                    }
                }
                else
                {
                    Console.WriteLine("Error: Invalid option! Try again.");
                    this.deleteTask();
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }

        }

        public void list()
        {
            //Console.WriteLine("\n");

            Console.WriteLine("------------------# TODO List #------------------");
            for (int i = 0; i < toDoList.Count; i++)
            {
                Console.WriteLine($"{i + 1} - [" + (toDoList[i].Done ? "X" : " ") + "] " + toDoList[i].Description);
            }
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("\n");
        }




    }
}