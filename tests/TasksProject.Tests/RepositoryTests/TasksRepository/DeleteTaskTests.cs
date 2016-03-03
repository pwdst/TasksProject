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
    public class DeleteTaskTests
    {
        private Guid _testTaskId;

        private const string TestTaskTitle = "Test Test";

        private const string TestTaskDescription = "Test Description";

        private DateTime _testTaskCreated;

        private ITaskStore _taskStore;

        private ITasksRepository _tasksRepository;

        private DeletedTask _deletedTask;

        [SetUp]
        public void Setup()
        {
            _taskStore = new TaskStore();

            var task = new Task(TestTaskTitle, TestTaskDescription);

            _testTaskId = task.Id;

            _testTaskCreated = task.CreatedOn;

            _taskStore.InProgressTasks.Add(task);

            _tasksRepository = new TasksRepository(_taskStore);

            _tasksRepository.DeleteTask(_testTaskId);
        }

        [Test]
        public void Deleted_Task_Exists()
        {
            _deletedTask = _taskStore.DeletedTasks.FirstOrDefault(ipt => ipt.Id.Equals(_testTaskId));

            Assert.IsNotNull(_deletedTask);
        }

        [Test]
        public void Task_Removed_In_Progress_Tasks()
        {
            var inProgressTask = _taskStore.InProgressTasks.FirstOrDefault(ipt => ipt.Id.Equals(_testTaskId));

            Assert.IsNull(inProgressTask);
        }

        [Test]
        public void Id_Matches_After_Deletion()
        {
            Assert.Equals(_testTaskId, _deletedTask.Id);
        }

        [Test]
        public void Title_Matches_After_Deletion()
        {
            Assert.Equals(TestTaskTitle, _deletedTask.Title);
        }

        [Test]
        public void Created_On_Matches_After_Deletion()
        {
            Assert.Equals(_testTaskCreated, _deletedTask.CreatedOn);
        }

        [Test]
        public void Description_Matches_After_Deletion()
        {
            Assert.Equals(TestTaskDescription, _deletedTask.Description);
        }

        [TearDown]
        public void TearDown()
        {
            _taskStore = null;

            _tasksRepository = null;
        }
    }
}