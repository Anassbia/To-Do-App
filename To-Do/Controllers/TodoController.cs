using Microsoft.AspNetCore.Mvc;
using To_Do.ViewModels;

namespace To_Do.Controllers
{
    public class TodoController:Controller
    {

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

            return View(nameof(Index));

        }
    }
}
