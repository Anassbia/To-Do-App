using System.ComponentModel.DataAnnotations;
using To_Do.Dtos;
using To_Do.Enums;
using To_Do.ViewModels;

namespace To_Do.Interfaces
{
    public interface ITodoService
    {
        public string AddToList(TodoAddVM vm,string key);

    }
}
