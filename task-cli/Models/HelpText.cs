namespace task_cli.Models;

public static class HelpText
{
    public static string Text => @"
Usage: task-cli [command] [options]
        
[commands]:
add [description]           Add a new task
delete [id]                 Delete a task by id
mark-done [id]              Mark a task as done
mark-in-progress [id]       Mark a task as in progress
mark-todo [id]              Mark a task as todo
list                        List all tasks
list [status]               List all tasks with the given status
update [id] [description]   Update a task description
--help                      Show this help text
";
}