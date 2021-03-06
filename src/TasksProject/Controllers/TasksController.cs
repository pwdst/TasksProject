﻿namespace TasksProject.Controllers
{
    using Microsoft.AspNet.Mvc;
    using Microsoft.AspNet.Mvc.ModelBinding;
    using Newtonsoft.Json;
    using Shared.Interfaces.ReadModels;
    using Shared.Interfaces.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Extensions.Logging;
    using ViewModels;

    public class TasksController : Controller
    {
        private static class TempDataKeys
        {
            public const string AddTaskViewModel = "AddTaskViewModel";

            public const string ModelStateErrors = "ModelStateErrors";
        }

        private readonly ITasksReadModel _tasksReadModel;

        private readonly ITasksRepository _tasksRepository;

        private readonly ILogger _logger;

        public TasksController(ITasksReadModel tasksReadModel, ITasksRepository tasksRepository, ILoggerFactory loggerFactory)
        {
            _tasksReadModel = tasksReadModel;

            _tasksRepository = tasksRepository;

            _logger = loggerFactory.CreateLogger("TaskControllerErrors");
        }

        public IActionResult List()
        {
            var tasks = _tasksReadModel.GetTasks();

            var deletedTaskCount = _tasksReadModel.DeletedTaskCount();

            var model = new TasksListViewModel(tasks, deletedTaskCount);

            if (TempData.ContainsKey(TempDataKeys.AddTaskViewModel))
            {
                var addTaskViewModel = JsonConvert.DeserializeObject<AddTaskViewModel>(TempData[TempDataKeys.AddTaskViewModel] as string,
                    new JsonSerializerSettings
                    {
                        Error = (sender, args) =>
                        {
                            _logger.LogInformation("Error deserializing Add Task View Model", args);
                        }
                    });

                if (addTaskViewModel != null)
                {
                    model.Title = addTaskViewModel.Title;

                    model.Description = addTaskViewModel.Description;
                }
            }

            if (TempData.ContainsKey(TempDataKeys.ModelStateErrors))
            {
                var modelStateErrors = TempData[TempDataKeys.ModelStateErrors] as IDictionary<string, string>;

                if (modelStateErrors != null && modelStateErrors.Any())
                {
                    foreach (var modelStateError in modelStateErrors)
                    {
                        ModelState.AddModelError(modelStateError.Key, modelStateError.Value);
                    }
                }
            }

            return View(model);
        }

        [HttpPost, Route("task/add", Name = "AddTask"), ValidateAntiForgeryToken]
        public IActionResult Add(AddTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                _tasksRepository.AddTask(model.Title, model.Description);
            }
            else
            {
                TempData.Add(TempDataKeys.AddTaskViewModel, JsonConvert.SerializeObject(model, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include
                }));

                var modelStateInvalid = ModelState.Where(ms => ms.Value.ValidationState == ModelValidationState.Invalid)
                    .ToDictionary(mse => mse.Key, mse => mse.Value.Errors);

                var modelStateErrors = new Dictionary<string, string>();

                foreach (var invalidModelProperty in modelStateInvalid)
                {
                    foreach (var error in invalidModelProperty.Value)
                    {
                        modelStateErrors.Add(invalidModelProperty.Key, error.ErrorMessage);
                    }
                }

                TempData.Add(TempDataKeys.ModelStateErrors, modelStateErrors);
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
