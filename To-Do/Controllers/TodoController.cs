using Microsoft.AspNetCore.Mvc;
using To_Do.Interfaces;
using To_Do.Services;
using To_Do.ViewModels;


namespace To_Do.Controllers
{
    public class TodoController:Controller
    {
        private readonly ITodoService _addService;
        private readonly SessionManagerService _sessionManagerService;

        public TodoController(ITodoService addService,SessionManagerService sessionManagerService)
        {
            _addService = addService;
            _sessionManagerService = sessionManagerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TodoAddVM todoAddVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var json = HttpContext.Session.GetString("todos");

            var newjson = _addService.AddToList(todoAddVM,json);
            HttpContext.Session.SetString("todos",newjson);

            return RedirectToAction(nameof(Index));

        }
    }
}
