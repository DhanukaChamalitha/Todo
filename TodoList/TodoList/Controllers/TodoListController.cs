using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoListController : Controller
    {
        private static List<TodoItem> todoItems = new List<TodoItem>();
        private static int nextId = 0;
        public IActionResult Index()
        {
            return View(todoItems);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TodoItem item) {

            if (ModelState.IsValid)
            { 
                item.Id = nextId++;
                todoItems.Add(item);
                return RedirectToAction("Index");
            }            
            return View(item);
        }
    }
}
