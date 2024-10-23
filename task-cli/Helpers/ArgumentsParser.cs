using task_cli.Models;

namespace task_cli.Helpers;

/// <summary>
/// Class responsible for parsing the arguments
/// </summary>
public static class ArgumentsParser
{
    public static string[] ParseArguments(Commands command, string[] args)
    {
        if (args.Length == 0)
        {
            throw new Exception("No arguments provided");
        }

        return command switch
        {
            Commands.Add => ParseAddArguments(args),
            Commands.List => ParseListArguments(args),
            Commands.Delete => ParseDeleteArguments(args),
            Commands.Mark => ParseMarkArguments(args),
            Commands.Update => ParseUpdateArguments(args),
            Commands.Help => [],
            _ => throw new Exception("Command not implemented")
        };
    }
    private static string[] ParseAddArguments(string[] args)
    {
        ArgumentsLengthValid(args, 2);

        return args[1..];
    }

    private static string[] ParseDeleteArguments(string[] args)
    {
        ArgumentsLengthValid(args, 2);
        IdValid(args[1]);

        return [args[1]];
    }

    private static string[] ParseListArguments(string[] args)
    {
        var progress = args.Length > 1 ? ParseProgressArgument(args[1]) : null;
        return progress is not null ? [progress] : [];
    }
    
    private static string[] ParseMarkArguments(string[] args)
    {
        ArgumentsLengthValid(args, 2);
        IdValid(args[1]);
        
        return args[0] switch
        {
            "mark-in-progress" => [args[1], "in-progress"],
            "mark-done" => [args[1], "done"],
            "mark-todo" => [args[1], "todo"],
            _ => throw new Exception("Invalid status provided")
        };
    }
    
    private static string[] ParseUpdateArguments(string[] args)
    {
        ArgumentsLengthValid(args, 3);
        IdValid(args[1]);
        
        return args[1..];
    }
    
    private static void ArgumentsLengthValid(string[] args, int length)
    {
        if (args.Length < length)
        {
            throw new Exception("Not enough arguments provided");
        }
    }
    
    private static void IdValid(string id)
    {
        var correctId =  int.TryParse(id, out _);
        
        if(!correctId)
        {
            throw new Exception("Invalid id provided.");
        }
    }
    
    private static string? ParseProgressArgument(string arg)
    {
        return arg switch
        {
            "done" => "done",
            "in-progress" => "in-progress",
            "todo" => "todo",
            _ => null
        };
    }
}