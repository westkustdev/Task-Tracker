using System.Text.Json;
using task_cli.Models;

namespace task_cli.Data;

public class FileTaskRepository
{
    public bool AddTask(string taskDescription)
    {
        var tasks = GetAll();

        var id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;

        tasks.Add(new TodoTask(id, taskDescription, "todo", DateTime.Now, DateTime.Now));

        SaveAll(tasks);

        return true;
    }

    public bool DeleteTask(int id)
    {
        var tasks = GetAll();

        var task = tasks.Find(t => t.Id == id);

        if (task is null) throw new Exception("Task not found");

        tasks.Remove(task);
        SaveAll(tasks);

        return true;
    }

    public List<TodoTask> GetAll(string? status = null)
    {
        var jsonFile = new FileInfo("tasks.json");

        if (!jsonFile.Exists)
        {
            using var sw = jsonFile.CreateText();
            {
                sw.WriteLine("[]");
            }

            return [];
        }

        var jsonString = "";
        using var sr = jsonFile.OpenText();
        {
            while (sr.ReadLine() is { } s)
            {
                jsonString += s;
            }
        }

        try
        {
            var tasks = JsonSerializer.Deserialize<List<TodoTask>>(jsonString)!;

            return status is not null ? tasks.FindAll(t => t.Status == status) : tasks;
        }
        catch
        {
            // If there is an error parsing the JSON file, create a new one
            using var sw = jsonFile.CreateText();
            {
                sw.WriteLine("[]");
            }

            return [];
        }
    }

    public bool MarkTask(int id, string status)
    {
        var tasks = GetAll();

        var task = tasks.Find(t => t.Id == id);

        if (task is null) throw new Exception("Task not found");

        tasks.Remove(task);

        tasks.Add(task with { Status = status, UpdatedAt = DateTime.Now });

        SaveAll(tasks);

        return true;
    }

    public bool UpdateTask(int id, string description)
    {
        var tasks = GetAll();

        var task = tasks.Find(t => t.Id == id);

        if (task is null) throw new Exception("Task not found");

        tasks.Remove(task);

        tasks.Add(task with { Description = description, UpdatedAt = DateTime.Now });

        SaveAll(tasks);

        return true;
    }

    private void SaveAll(List<TodoTask> tasks)
    {
        var jsonFile = new FileInfo("tasks.json");

        using var sw = jsonFile.CreateText();
        {
            sw.WriteLine(JsonSerializer.Serialize(tasks));
        }
    }
}