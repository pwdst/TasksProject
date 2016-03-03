using Microsoft.AspNet.Mvc;

namespace TasksProject.Controllers
{
    using System;
    using Shared.Interfaces.Repositories;

    public class TasksController : Controller
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksController(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public IActionResult List()
        {
            return View();
        }

        [HttpPost, Route("task/add"), ValidateAntiForgeryToken]
        public IActionResult Add(string title, string description)
        {
            _tasksRepository.AddTask(title, description);

            return RedirectToAction("List");
        }

        [HttpPost, Route("task/{taskId:guid}/delete"), ValidateAntiForgeryToken]
        public IActionResult Delete(Guid taskId)
        {
            _tasksRepository.DeleteTask(taskId);

            return RedirectToAction("List");
        }

        [HttpPost, Route("task/{taskId:guid}/completed"), ValidateAntiForgeryToken]
        public IActionResult MarkCompleted(Guid taskId)
        {
            _tasksRepository.MarkComplete(taskId);

            return RedirectToAction("List");
        }

        [HttpPost, Route("task/purge-deleted"), ValidateAntiForgeryToken]
        public IActionResult PurgeDeleted()
        {
            _tasksRepository.PurgeDeleted();

            return RedirectToAction("List");
        }

        [HttpPost, Route("task/{taskId:guid}/restore"), ValidateAntiForgeryToken]
        public IActionResult Restore(Guid taskId)
        {
            _tasksRepository.RestoreTask(taskId);

            return RedirectToAction("List");
        }

        [HttpPost, Route("task/{taskId:guid}/update"), ValidateAntiForgeryToken]
        public IActionResult Update(Guid taskId, string title, string description)
        {
            _tasksRepository.UpdateTask(taskId, title, description);

            return RedirectToAction("List");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
