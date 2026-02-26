using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0207.Models;

namespace Mission08_Team0207.Controllers;



public class HomeController : Controller
{
    private ITaskRepository _repo;
    
    public HomeController(ITaskRepository temp)
    {
        _repo = temp;
    }
    
    public IActionResult Index()
    {

        IEnumerable<TaskItem> tasks = _repo.GetIncompleteTasks();
        
        return View(tasks);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        TaskItem task = _repo.GetTaskById(id);
        
        return View(task);
    }
    
    [HttpPost]
    public IActionResult Delete(int id, TaskItem task)
    {
        _repo.DeleteTask(id);
        
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult AddTask()
    {
        ViewBag.Categories = _repo.GetCategories();
        
        return View(new TaskItem());
    }
    
}