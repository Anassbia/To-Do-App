using Microsoft.AspNetCore.Mvc;
using To_Do.Dtos;
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
            List<Todo> list = _sessionManagerService.GetTodos(HttpContext,"todos");
            return View(list);
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

        public IActionResult Theme(string theme, string returnUrl)
        {
            if (theme != "dark" && theme != "light")//enum est pas nessecaire
            {
                theme = "light";
            }
            HttpContext.Session.SetString("theme", theme);

            if (!string.IsNullOrEmpty(returnUrl)) return Redirect(returnUrl);//Good UX ,User yb9a f same Psge

            return RedirectToAction(nameof(Index));
        }
    }
}
