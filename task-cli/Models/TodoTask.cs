namespace task_cli.Models;

public record TodoTask(int Id, string Description, string Status, DateTime CreatedAt, DateTime UpdatedAt)
{
    public override string ToString()
    {
        return $"Id: {Id}, Description: {Description}, Status: {Status}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}";
    }
}