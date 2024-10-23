// See https://aka.ms/new-console-template for more information

using task_cli.Helpers;
using task_cli.Models;

try
{
    var result = CommandExecutor.ExecuteCommand(args);

    switch (result)
    {
        case List<TodoTask> tasks:
        {
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }

            break;
        }
        case TodoTask task:
            Console.WriteLine(task);
            break;
        case string helpText:
            Console.WriteLine(helpText);
            break;
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}