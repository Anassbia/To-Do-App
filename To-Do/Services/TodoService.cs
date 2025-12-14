using System.Text.Json;
using To_Do.Dtos;
using To_Do.Interfaces;
using To_Do.Mappers;
using To_Do.ViewModels;

namespace To_Do.Services
{
    public class TodoService:ITodoService
    {
        private readonly ITodoService _service;

        public TodoService()
        {
          
        }

        public String AddToList(TodoAddVM vm,string session)//?->soit null soit list
        {
            var MyTodo = TodoMapper.AddvmToTodo(vm);

            List<Todo> list;

            if (string.IsNullOrEmpty(session))
            {
                list = new List<Todo>();
            }
            else
            {
                list= JsonSerializer.Deserialize<List<Todo>>(session)!;//->silence l compiler ela null possibility
            }

            list.Add(MyTodo);
            string chaine =JsonSerializer.Serialize(list);
            
            return chaine;
        }

        
    }
}
