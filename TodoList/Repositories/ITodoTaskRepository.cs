﻿using TodoList.Models;

namespace TodoList.Repositories;

public interface ITodoTaskRepository
{
    List<TodoTask> GetAll();
    TodoTask? GetById(int id);
    void Add(TodoTask task);
    bool Update(TodoTask task);
    bool Delete(int id);
}
