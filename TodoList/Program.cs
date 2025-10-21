using TodoList.Repositories;
using TodoList.Services;

namespace TodoList;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });

        builder.Services.AddSingleton<ITodoTaskRepository, InMemoryTodoTaskRepository>();
        builder.Services.AddScoped<ITodoTaskService, TodoTaskService>();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoList API V1");
            c.RoutePrefix = string.Empty; // Swagger at root URL: https://localhost:5001/
        });

        app.MapControllers();

        app.Run();
    }
}
