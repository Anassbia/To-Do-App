using System.Text.Json;
using To_Do.Dtos;

namespace To_Do.Services
{
    public class SessionManagerService
    {
        public List<Todo>? GetTodos(HttpContext context,string key) 
        {
            return JsonSerializer.Deserialize<List<Todo>>(context.Session.GetString(key)!);
        }
    }
}
