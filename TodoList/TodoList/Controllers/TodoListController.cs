﻿using Microsoft.AspNetCore.Mvc;
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


        public IActionResult Edit(int id)
        {
            var item = todoItems.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(TodoItem item) {

            if (ModelState.IsValid) {
                var exItem = todoItems.FirstOrDefault(x => x.Id == item.Id);
                if (exItem == null) {
                    return NotFound();
                }

                exItem.Title = item.Title;
                exItem.IsCompleted = item.IsCompleted;
                return RedirectToAction("Index");
            }

            return View(item);
        }
    }
}
