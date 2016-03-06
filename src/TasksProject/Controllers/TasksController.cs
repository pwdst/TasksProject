using Microsoft.AspNet.Mvc;

namespace TasksProject.Controllers
{
    using System;
    using Shared.Interfaces.ReadModels;
    using Shared.Interfaces.Repositories;
    using ViewModels;

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
            var tasks = _tasksReadModel.GetTasks();

            var deletedTaskCount = _tasksReadModel.DeletedTaskCount();

            var model = new TasksListViewModel(tasks, deletedTaskCount);

            return View(model);
        }

        [HttpPost, Route("task/add", Name = "AddTask"), ValidateAntiForgeryToken]
        public IActionResult Add(AddTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                _tasksRepository.AddTask(model.Title, model.Description);
            }

            return RedirectToAction("List");
        }

        [HttpPost, Route("task/{taskId:guid}/delete", Name = "DeleteTask"), ValidateAntiForgeryToken]
        public IActionResult Delete(Guid taskId)
        {
            _tasksRepository.DeleteTask(taskId);

            return RedirectToAction("List");
        }

        [HttpPost, Route("task/{taskId:guid}/completed", Name = "MarkTaskCompleted"), ValidateAntiForgeryToken]
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
