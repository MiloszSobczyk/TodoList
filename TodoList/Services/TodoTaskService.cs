using TodoList.Models;
using TodoList.Repositories;

namespace TodoList.Services;

public class TodoTaskService : ITodoTaskService
{
    private readonly ITodoTaskRepository _repository;

    public TodoTaskService(ITodoTaskRepository repository)
    {
        _repository = repository;
    }

    public List<TodoTask> GetAll()
    {
        return _repository.GetAll();
    }

    public TodoTask? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public void Add(TodoTask task)
    {
        _repository.Add(task);
    }

    public bool Update(TodoTask task)
    {
        return _repository.Update(task);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}