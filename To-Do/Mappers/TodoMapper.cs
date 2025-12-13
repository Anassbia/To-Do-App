using To_Do.Dtos;
using To_Do.ViewModels;

namespace To_Do.Mappers
{
    public class TodoMapper
    {
        public static Todo AddvmToTodo(TodoAddVM todoAddVM )
        {
            return new Todo
            {
                Libelle = todoAddVM.Libelle,
                Description = todoAddVM.Description,
                Statut = todoAddVM.Statut,  
                DateLimite = todoAddVM.DateLimite,
                CreatedAt=DateTime.UtcNow,

            };
        }
    }
}
