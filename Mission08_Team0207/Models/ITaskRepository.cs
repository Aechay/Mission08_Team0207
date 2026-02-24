namespace Mission08_Team0207.Models
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAllTasks();
        IEnumerable<TaskItem> GetIncompleteTasks();
        TaskItem? GetTaskById(int id);
        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(int id);
        void MarkCompleted(int id);
        IEnumerable<Category> GetCategories();
    }
}
