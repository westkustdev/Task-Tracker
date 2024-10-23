using task_cli.Data;
using task_cli.Models;

namespace task_cli.Helpers;

/// <summary>
/// Class responsible for executing the command
/// </summary>
public static class CommandExecutor
{
    /// <summary>
    /// Execute the command with the given arguments
    /// </summary>
    /// <param name="args">The arguments passed to the application</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static object ExecuteCommand(string[] args)
    {
        var command = CommandParser.ParseCommand(args);
        var repo = new FileTaskRepository();
        var argsForCommand = ArgumentsParser.ParseArguments(command, args);

        switch (command)
        {
            case Commands.Add:
                return repo.AddTask(argsForCommand[0]);
            case Commands.List:
                return repo.GetAll(argsForCommand.Length > 0 ? argsForCommand[0] : null);
            case Commands.Delete:
                return repo.DeleteTask(int.Parse(argsForCommand[0]));
            case Commands.Mark:
                return repo.MarkTask(int.Parse(argsForCommand[0]), argsForCommand[1]);
            case Commands.Update:
                return repo.UpdateTask(int.Parse(argsForCommand[0]), argsForCommand[1]);
            case Commands.Help:
                return HelpText.Text;
            case Commands.Unknown:
            default:
                throw new ArgumentOutOfRangeException(nameof(command), command, null);
        }
    }
}