using task_cli.Models;

namespace task_cli.Helpers;

public static class CommandParser
{
    /// <summary>
    /// Parse the command from the arguments
    /// </summary>
    /// <param name="args">The args passed to the application</param>
    /// <returns></returns>
    public static Commands ParseCommand(string[] args)
    {
        if (args.Length == 0) return Commands.Unknown;
        
        return args[0] switch
        {
            "add" => Commands.Add,
            "list" => Commands.List,
            "delete" => Commands.Delete,
            "mark-done" => Commands.Mark,
            "mark-in-progress" => Commands.Mark,
            "mark-todo" => Commands.Mark,
            "update" => Commands.Update,
            "--help" => Commands.Help,
            _ => Commands.Unknown
        };
    }
}