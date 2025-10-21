using TodoList.Models;

namespace TodoList.Repositories;

public class InMemoryTodoTaskRepository : ITodoTaskRepository
{
    private readonly List<TodoTask> _tasks;
    private int _nextId;

    public InMemoryTodoTaskRepository()
    {
        _tasks = new List<TodoTask>();
        _nextId = 1;
    }

    public List<TodoTask> GetAll()
    {
        return _tasks.ToList();
    }

    public TodoTask? GetById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public void Add(TodoTask task)
    {
        task.Id = _nextId++;
        _tasks.Add(task);
    }

    public bool Update(TodoTask task)
    {
        var existing = GetById(task.Id);

        if (existing != null)
        {
            existing.Title = task.Title;
            existing.Description = task.Description;
            return true;
        }

        return false;
    }

    public bool Delete(int id)
    {
        var task = GetById(id);

        if (task != null)
        {
            _tasks.Remove(task);
            return true;
        }

        return false;
    }
}
