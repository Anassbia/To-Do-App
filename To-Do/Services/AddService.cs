using To_Do.Dtos;
using To_Do.Interfaces;
using To_Do.ViewModels;

namespace To_Do.Services
{
    public class AddService
    {
        private readonly IAddService _service;

        public AddService(IAddService addService)
        {
            _service = addService;
        }

        public Todo AddToList(TodoAddVM vm)
        {
            //1.vm->todo

            //2.

        }
    }
}
