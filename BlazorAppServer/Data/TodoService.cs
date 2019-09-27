using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BlazorAppServer.Data
{
    public class TodoService
    {
        public List<TodoItem> Todos = new List<TodoItem>()
        {
            new TodoItem { Id = Guid.NewGuid(), Title = "Cast", IsDone = false },
            new TodoItem { Id = Guid.NewGuid(), Title = "Troll", IsDone = true },
            new TodoItem { Id = Guid.NewGuid(), Title = "Villa", IsDone = false },
            new TodoItem { Id = Guid.NewGuid(), Title = "MomyFetch", IsDone = true },
            new TodoItem { Id = Guid.NewGuid(), Title = "Natureasd", IsDone = false },
        };

        public Task<List<TodoItem>> GetTodos()
        {
            return Task.Run(() => Todos);
        }

        public Task<TodoItem> GetTodoById(Guid Id)
        {
            return Task.Run(() => Todos.SingleOrDefault(x => x.Id == Id));
        }
        public Task<int> AddTodo(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                Todos.Add(new TodoItem
                {
                    Id = Guid.NewGuid(),
                    Title = title
                });
            }
            return Task.Run(() => 1);
        }
        public async Task UpdateTodoItem(TodoItem todo)
        {
            if(todo == null)
            {
                return;
            }
            var existTodo = await GetTodoById(todo.Id);
            if(existTodo != null)
            {
                existTodo.IsDone = todo.IsDone;
                existTodo.Title = todo.Title;
            }
        }

        public async Task<bool> DeleteTodo(Guid id)
        {
            var existTodo = await GetTodoById(id);

            if (existTodo == null) return false;
            await Task.Run(() => Todos.Remove(existTodo));

            return true;
        }
    }
}
