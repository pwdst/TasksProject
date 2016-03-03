namespace TasksProject.Tests.RepositoryTests.TasksRepository
{
    using Data.DataStore;
    using Data.Entities;
    using Data.Interfaces.DataStore;
    using Data.Repositories;
    using NUnit.Framework;
    using Shared.Interfaces.Repositories;
    using System.Linq;

    [TestFixture]
    public class AddTaskTests
    {
        private const string TestTaskTitle = "Test Test";

        private const string TestTaskDescription = "Test Description";

        private ITaskStore _taskStore;

        private ITasksRepository _tasksRepository;

        private Task _addedTask;

        [SetUp]
        public void Setup()
        {
            _taskStore = new TaskStore();

            _tasksRepository = new TasksRepository(_taskStore);

            _tasksRepository.AddTask(TestTaskTitle, TestTaskDescription);
        }

        [Test]
        public void Has_Tasks()
        {
            Assert.IsNotEmpty(_taskStore.InProgressTasks);
        }

        [Test]
        public void Completed_Task_Exists()
        {
            _addedTask = _taskStore.InProgressTasks.FirstOrDefault(ipt => ipt.Title.Equals(TestTaskTitle));

            Assert.IsNotNull(_addedTask);
        }

        [Test]
        public void Only_One_Task()
        {
            Assert.Equals(_taskStore.InProgressTasks.Count, 1);
        }

        [Test]
        public void Description_Matches_After_Adding()
        {
            Assert.Equals(TestTaskDescription, _addedTask.Description);
        }

        [TearDown]
        public void TearDown()
        {
            _taskStore = null;

            _tasksRepository = null;
        }
    }
}