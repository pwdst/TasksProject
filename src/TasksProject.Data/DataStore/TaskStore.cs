namespace TasksProject.Data.DataStore
{
    using System.Collections.Generic;
    using Entities;
    using Interfaces.DataStore;

    internal sealed class TaskStore : ITaskStore
    {
        public List<Task> InProgressTasks
        {
            get
            {
                return _inProgressTasks ?? (_inProgressTasks = new List<Task>());
            }
            set
            {
                _inProgressTasks = value;
            }
        }

        private List<Task> _inProgressTasks;

        public List<DeletedTask> DeletedTasks {
            get
            {
                return _deletedProgressTasks ?? (_deletedProgressTasks = new List<DeletedTask>());
            }
            set
            {
                _deletedProgressTasks = value;
            }
        }

        private List<DeletedTask> _deletedProgressTasks;

        public List<CompletedTask> CompletedTasks
        {
            get
            {
                return _completedTasks ?? (_completedTasks = new List<CompletedTask>());
            }
            set
            {
                _completedTasks = value;
            }
        }

        private List<CompletedTask> _completedTasks;
    }
}