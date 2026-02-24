using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0207.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public EFTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskItem> GetAllTasks() =>
            _context.Tasks.Include(t => t.Category).ToList();

        public IEnumerable<TaskItem> GetIncompleteTasks() =>
            _context.Tasks.Include(t => t.Category).Where(t => !t.Completed).ToList();

        public TaskItem? GetTaskById(int id) =>
            _context.Tasks.Include(t => t.Category).FirstOrDefault(t => t.TaskId == id);

        public void AddTask(TaskItem task) { _context.Tasks.Add(task); _context.SaveChanges(); }

        public void UpdateTask(TaskItem task) { _context.Tasks.Update(task); _context.SaveChanges(); }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null) { _context.Tasks.Remove(task); _context.SaveChanges(); }
        }

        public void MarkCompleted(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null) { task.Completed = true; _context.SaveChanges(); }
        }

        public IEnumerable<Category> GetCategories() => _context.Categories.ToList();
    }
}
