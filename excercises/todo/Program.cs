// See https://aka.ms/new-console-template for more information

using System.Globalization;

Console.Clear();


string[] todos = File.ReadAllLines("todos.txt");

if (args.Length != 0)
{
    if (args.Length > 2)
    {
        if (args[1] == "add")
        {
            var todo = args[2];

            if (args[3].Contains("--due"))
            {
                string date = args[4];
                string dueDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("dd MMM", new CultureInfo("sv-SE"));
                todo += Convert.ToString($"- skall vara klar: {dueDate}");
            }

            Array.Resize(ref todos, todos.Length + 1);
            File.AppendAllLines("todos.txt", [todo]);
        }
        if (args[1] == "done")
        {
            var index = int.Parse(args[2]);
            string editedTodo = todos[index - 1] += " - KLAR!";
            todos[index - 1] = editedTodo;
            File.WriteAllLines("todos.txt", todos);
        }
        if (args[1] == "remove")
        {
            var index = int.Parse(args[2]);

            for (int i = 0; i < index; i++)
            {
                todos[i] = todos[i];
            }

            for (int i = index + 1; i < todos.Length; i++)
            {
                todos[i - 1] = todos[i];
            }

        // Resize array to remove the last element
        Array.Resize(ref todos, todos.Length - 1);

        File.WriteAllLines("todos.txt", todos);
        }
    }

    if (args.Length < 2)
    {
        for (int i = 0; i < todos.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {todos[i]}");
        }
    }
}
else
{
    Console.WriteLine("You must write something!");
}


        // bool exit = false;
        // int listNumber = 1;
        // string[] todoList = ["1. Köpa mat."];

        // while (exit == false)
        // {
        //     Console.Write("Vad vill du göra ? (todo: add, remove, -h, done; exit): ");
        //     string inputOption = Console.ReadLine();

        //     if (args.Length < 3)
        //     {
        //         string message = args[3];
        //         Console.WriteLine(message);
        //         Console.WriteLine(args.Length);
        //     }
        //     else
        //     {
        //         string message = args[2];

        //         Console.WriteLine(message);
        //         continue;
        //     }

        //     if (inputOption == "exit".ToLower())
        //     {
        //         Console.WriteLine();
        //         Console.WriteLine("OK. Hej då!");
        //         exit = true;
        //         Console.WriteLine();
        //     }

        //     if (inputOption.StartsWith("todo add".ToLower()))
        //     {
        //         listNumber++;
        //         string message = inputOption.Substring(9).Trim('"') + ".";
        //         string[] updatedTodoList = new string[todoList.Length + 1];

        //         for (int j = 0; j < todoList.Length; j++)
        //         {
        //             updatedTodoList[j] = todoList[j];
        //         }

        //         updatedTodoList[updatedTodoList.Length - 1] = $"{listNumber}. {message}";

        //         todoList = updatedTodoList;
        //     }

        //     if (inputOption.StartsWith("todo remove".ToLower()))
        //     {
        //         int index = int.Parse(inputOption.Substring(12));

        //         string[] removeTodoList = new string[todoList.Length - 1];

        //         for (int i = 0; i < index; i++)
        //         {
        //             removeTodoList[i] = todoList[i];
        //         }

        //         for (int i = index + 1; i < todoList.Length; i++)
        //         {
        //             removeTodoList[i - 1] = todoList[i];
        //         }

        //         todoList = removeTodoList;

        //     }

        //     if (inputOption.StartsWith("todo done".ToLower()))
        //     {
        //         int index = int.Parse(inputOption.Substring(10));

        //         todoList[index] += " - KLAR!";

        //     }

        //     if (inputOption == "todo -h".ToLower())
        //     {
        //         Console.WriteLine();
        //         Console.WriteLine("Detta kommer att hjälpa. Mycket.");
        //         Console.WriteLine();
        //     }

        //     if (inputOption.Trim() == "todo".ToLower())
        //     {

        //         Console.WriteLine();
        //         foreach (var item in todoList)
        //         {
        //             Console.WriteLine(item);
        //         }
        //         Console.WriteLine();
        //     }
        // }
