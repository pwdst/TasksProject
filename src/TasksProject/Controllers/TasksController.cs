using Microsoft.AspNet.Mvc;

namespace TasksProject.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
