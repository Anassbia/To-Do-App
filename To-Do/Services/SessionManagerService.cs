using System.Text.Json;
using To_Do.Dtos;

namespace To_Do.Services
{
    public class SessionManagerService
    {
        public List<Todo>? GetTodos(HttpContext context,string key) 
        {
            var json = context.Session.GetString(key);

            if (string.IsNullOrEmpty(json))
            {
                return new List<Todo>();
            }
            return JsonSerializer.Deserialize<List<Todo>>(json);
        }
    }
}
