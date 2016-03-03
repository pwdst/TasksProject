namespace TasksProject.Tests.RepositoryTests.TasksRepository
{
    using Data.DataStore;
    using Data.Entities;
    using Data.Interfaces.DataStore;
    using Data.Repositories;
    using NUnit.Framework;
    using Shared.Interfaces.Repositories;

    [TestFixture]
    public class PurgeDeletedTests
    {
        private const string TestTaskTitle = "Test Test";

        private const string TestTaskDescription = "Test Description";

        private ITaskStore _taskStore;

        private ITasksRepository _tasksRepository;

        [SetUp]
        public void Setup()
        {
            _taskStore = new TaskStore();

            var task = new Task(TestTaskTitle, TestTaskDescription);

            var deletedTask = new DeletedTask(task);

            _taskStore.DeletedTasks.Add(deletedTask);

            _tasksRepository = new TasksRepository(_taskStore);
        }

        [Test]
        public void Deleted_Task_Exists()
        {
           Assert.IsNotEmpty(_taskStore.DeletedTasks);
        }

        [Test]
        public void Empty_After_Purged()
        {
            _tasksRepository.PurgeDeleted();

            Assert.IsEmpty(_taskStore.DeletedTasks);
        }

        [TearDown]
        public void TearDown()
        {
            _taskStore = null;

            _tasksRepository = null;
        }
    }
}
