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
    public class RestoredTaskTests
    {
        private Guid _testTaskId;

        private const string TestTaskTitle = "Test Test";

        private const string TestTaskDescription = "Test Description";

        private DateTime _testTaskCreated;

        private ITaskStore _taskStore;

        private ITasksRepository _tasksRepository;

        private Task _restoredTask;

        [SetUp]
        public void Setup()
        {
            _taskStore = new TaskStore();

            var task = new Task(TestTaskTitle, TestTaskDescription);

            _testTaskId = task.Id;

            _testTaskCreated = task.CreatedOn;

            var deletedTask = new DeletedTask(task);

            _taskStore.DeletedTasks.Add(deletedTask);

            _tasksRepository = new TasksRepository(_taskStore);

            _tasksRepository.RestoreTask(_testTaskId);
        }

        [Test]
        public void Restored_Task_Exists()
        {
            _restoredTask = _taskStore.InProgressTasks.FirstOrDefault(ipt => ipt.Id.Equals(_testTaskId));

            Assert.IsNotNull(_restoredTask);
        }

        [Test]
        public void Restored_Task_Removed_Deleted_Tasks()
        {
            var deletedTask = _taskStore.DeletedTasks.FirstOrDefault(ipt => ipt.Id.Equals(_testTaskId));

            Assert.IsNull(deletedTask);
        }

        [Test]
        public void Title_Matches_After_Restoring()
        {
            Assert.Equals(TestTaskTitle, _restoredTask.Title);
        }

        [Test]
        public void Created_On_Matches_After_Restoring()
        {
            Assert.Equals(_testTaskCreated, _restoredTask.CreatedOn);
        }

        [Test]
        public void Description_Matches_After_Restoring()
        {
            Assert.Equals(TestTaskDescription, _restoredTask.Description);
        }

        [TearDown]
        public void TearDown()
        {
            _taskStore = null;

            _tasksRepository = null;
        }
    }
}
