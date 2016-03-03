namespace TasksProject.Tests.RepositoryTests.TasksRepository
{
    using Data.DataStore;
    using Data.Entities;
    using Data.Interfaces.DataStore;
    using Data.Repositories;
    using NUnit.Framework;
    using Shared.Interfaces.Repositories;
    using System;
    using System.Linq;

    [TestFixture]
    public class UpdateTaskTests
    {
        private Guid _testTaskId;

        private const string TestTaskTitle = "Test Test";

        private const string TestTaskDescription = "Test Description";

        private const string UpdatedTaskTitle = "Updated Test Test";

        private const string UpdatedTaskDescription = "Updated Test Description";

        private DateTime _testTaskCreated;

        private ITaskStore _taskStore;

        private ITasksRepository _tasksRepository;

        private Task _updatedTask;

        [SetUp]
        public void Setup()
        {
            _taskStore = new TaskStore();

            var task = new Task(TestTaskTitle, TestTaskDescription);

            _testTaskId = task.Id;

            _testTaskCreated = task.CreatedOn;

            _taskStore.InProgressTasks.Add(task);

            _tasksRepository = new TasksRepository(_taskStore);

            _tasksRepository.UpdateTask(_testTaskId, UpdatedTaskTitle, UpdatedTaskDescription);
        }

        [Test]
        public void Updated_Task_Exists()
        {
            _updatedTask = _taskStore.CompletedTasks.FirstOrDefault(ipt => ipt.Id.Equals(_testTaskId));

            Assert.IsNotNull(_updatedTask);
        }

        [Test]
        public void Still_Only_One_Task()
        {
            Assert.Equals(_taskStore.InProgressTasks.Count, 1);
        }

        [Test]
        public void Title_Updated()
        {
            Assert.Equals(UpdatedTaskTitle, _updatedTask.Title);
        }

        [Test]
        public void Created_On_Matches_After_Completion()
        {
            Assert.Equals(_testTaskCreated, _updatedTask.CreatedOn);
        }

        [Test]
        public void Description_Matches_After_Completion()
        {
            Assert.Equals(UpdatedTaskDescription, _updatedTask.Description);
        }

        [TearDown]
        public void TearDown()
        {
            _taskStore = null;

            _tasksRepository = null;
        }
    }
}
