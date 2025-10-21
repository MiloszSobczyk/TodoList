using TodoList.Models;

namespace TodoList.Services;

public interface ITodoTaskService
{
    List<TodoTask> GetAll();
    TodoTask? GetById(int id);
    void Add(TodoTask task);
    bool Update(TodoTask task);
    bool Delete(int id);
}