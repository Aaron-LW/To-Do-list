using System;
using System.Collections.Generic;

class Program
{
    List<Task> tasks = new List<Task>();

    static void Main()
    {
        Program main = new Program();

        while (true)
        {
            string? Token = Console.ReadLine();

            if (Token.ToLower() == "exit") { break; }

            main.Tokenizer(Token);
        }
    }

    void AddTask(string Title, bool Done = false)
    {
        tasks.Add(new Task(Title, Done));
    }

    void ListTasks()
    {
        Console.Clear();

        if (tasks.Count == 0) { Console.WriteLine("no tasks in list"); }

        foreach (Task task in tasks)
        {
            Console.WriteLine(task.Title + "     " + task.Done);
        }
    }

    void Tokenizer(string token)
    {
        string action = "";
        string execute = "";

        int counter = 0;

        for (int i = 0; i < token.Length; i++)
        {
            if (token[i].ToString() == " ") { counter = i; break; }

            action += token[i];
        }

        for (int i = counter + 1; i < token.Length; i++)
        {
            execute += token[i];
        }

        if (action.ToLower() == "add")
        {
            AddTask(execute.ToString());
            ListTasks();
            return;
        }

        if (action.ToLower() == "done")
        {
            tasks[GetIndexByName(execute)].Done = true;
            ListTasks();
            return;
        }

        if (action.ToLower() == "remove")
        {
            tasks.RemoveAt(GetIndexByName(execute));
            ListTasks();
            return;
        }

        ListTasks();
        Console.WriteLine("not an action");
    }

    int GetIndexByName(string name)
    {
        if (tasks.Count != 0)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Title == name)
                {
                    return i;
                }
            }

            return -1;
        }

        Console.WriteLine("no tasks available"); return -1;
    }
}

class Task
{
    public string Title;
    public bool Done;

    public Task(string title, bool done = false)
    {
        Title = title;
        Done = done;
    }
}