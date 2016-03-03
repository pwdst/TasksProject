namespace TasksProject.Controllers
{
    using System;
    using Microsoft.AspNet.Mvc;
    using Shared.Interfaces.ReadModels;
    using Shared.Interfaces.Repositories;

    public class DeletedTasksController : Controller
    {
        private readonly ITasksReadModel _tasksReadModel;

        private readonly ITasksRepository _tasksRepository;

        public DeletedTasksController(ITasksReadModel tasksReadModel, ITasksRepository tasksRepository)
        {
            _tasksReadModel = tasksReadModel;

            _tasksRepository = tasksRepository;
        }

        [HttpGet, Route("deleted-tasks")]
        public IActionResult List()
        {
            throw new NotImplementedException();
        }

        [HttpPost, Route("task/{taskId:guid}/restore"), ValidateAntiForgeryToken]
        public IActionResult Restore(Guid taskId)
        {
            _tasksRepository.RestoreTask(taskId);

            return RedirectToAction("List");
        }
    }
}
