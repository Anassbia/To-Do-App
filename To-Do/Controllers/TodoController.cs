using Microsoft.AspNetCore.Mvc;
using To_Do.Dtos;
using To_Do.Interfaces;
using To_Do.Services;
using To_Do.ViewModels;


namespace To_Do.Controllers
{
    public class TodoController:Controller
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoService _addService;
        private readonly SessionManagerService _sessionManagerService;

        public TodoController(ITodoService addService,SessionManagerService sessionManagerService, ILogger<TodoController> logger)
        {
            _addService = addService;
            _sessionManagerService = sessionManagerService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("page index accede");

            List<Todo> list = _sessionManagerService.GetTodos(HttpContext,"todos");

            _logger.LogInformation("liste des todos charge ");
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
                _logger.LogWarning("insertioon Invalide des donnees");
                return View();
            }
            var json = HttpContext.Session.GetString("todos");

            var newjson = _addService.AddToList(todoAddVM,json);
            HttpContext.Session.SetString("todos",newjson);
            _logger.LogInformation(
                  "Todo ajoute: {Title} / status {Status}",
                  todoAddVM.Libelle,
                  todoAddVM.Statut
                             );

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Theme(string theme, string returnUrl)
        {

            _logger.LogInformation("Requete de changment de theme : {Theme}", theme);
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
