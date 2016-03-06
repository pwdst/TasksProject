using Microsoft.AspNet.Mvc;

namespace TasksProject.Controllers
{
    using System;
    using Shared.Interfaces.ReadModels;
    using Shared.Interfaces.Repositories;

    public class TasksController : Controller
    {
        private readonly ITasksReadModel _tasksReadModel;

        private readonly ITasksRepository _tasksRepository;

        public TasksController(ITasksReadModel tasksReadModel, ITasksRepository tasksRepository)
        {
            _tasksReadModel = tasksReadModel;

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
