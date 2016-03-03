namespace TasksProject.Tests.RepositoryTests.TasksRepository
{
    using System;
    using System.Linq;
    using Data.DataStore;
    using Data.Entities;
    using Data.Interfaces.DataStore;
    using Data.Repositories;
    using NUnit.Framework;
    using Shared.Interfaces.Repositories;

    [TestFixture]
    public sealed class CompleteTaskTests
    {
        private Guid _testTaskId;

        private const string TestTaskTitle = "Test Test";

        private const string TestTaskDescription = "Test Description";

        private DateTime _testTaskCreated;

        private ITaskStore _taskStore;

        private ITasksRepository _tasksRepository;

        private CompletedTask _completedTask;

        [SetUp]
        public void Setup()
        {
            _taskStore = new TaskStore();

            var task = new Task(TestTaskTitle, TestTaskDescription);

            _testTaskId = task.Id;

            _testTaskCreated = task.CreatedOn;

            _taskStore.InProgressTasks.Add(task);

            _tasksRepository = new TasksRepository(_taskStore);

            _tasksRepository.MarkComplete(_testTaskId);
        }

        [Test]
        public void Completed_Task_Exists()
        {
            _completedTask = _taskStore.CompletedTasks.FirstOrDefault(ipt => ipt.Id.Equals(_testTaskId));

            Assert.IsNotNull(_completedTask);
        }

        [Test]
        public void Completed_Task_Not_In_Progress()
        {
            var inProgressTask = _taskStore.InProgressTasks.FirstOrDefault(ipt => ipt.Id.Equals(_testTaskId));

            Assert.IsNull(inProgressTask);
        }

        [Test]
        public void Title_Matches_After_Completion()
        {
            Assert.Equals(TestTaskTitle, _completedTask.Title);
        }

        [Test]
        public void Created_On_Matches_After_Completion()
        {
            Assert.Equals(_testTaskCreated, _completedTask.CreatedOn);
        }

        [Test]
        public void Description_Matches_After_Completion()
        {
            Assert.Equals(TestTaskDescription, _completedTask.Description);
        }

        [TearDown]
        public void TearDown()
        {
            _taskStore = null;

            _tasksRepository = null;
        }
    }
}