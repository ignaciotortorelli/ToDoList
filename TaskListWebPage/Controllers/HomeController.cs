using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskListWebPage.Models;
using DataLibrary;
using DataLibrary.BusinessLogic;

namespace TaskListWebPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTasks(TaskModel model)//Borra una tarea de la base de datos
        {
            ViewBag.Message = "Tasks List";

            if (ModelState.IsValid)
            {
                TaskProcessor.DeleteTask(model.TaskName);
                return RedirectToAction("ViewTasks");
            }

            return RedirectToAction("ViewTasks");
        }

        public ActionResult ClearCompletedTasks()//limpia las tareas completadas
        {
            TaskProcessor.ClearCompleted();
            return RedirectToAction("ViewTasks");
        }

        public ActionResult ViewTasks()//toma las tareas de la base de datos, las guarda en una lista de objetos tipo TaskModel y muestra la lista en la vista 
        {
            ViewBag.Message = "Tasks List";

            var data = TaskProcessor.LoadTask();
            List<TaskModel> tasks = new List<TaskModel>();

            foreach (var row in data)
            {
                tasks.Add(new TaskModel
                {
                    TaskName = row.TaskName,
                    TaskCompleted = row.TaskCompleted
                });
            }

            return View(tasks);
        }

        public ActionResult ViewCompletedTasks()//toma las tareas completadas de la base de datos, las guarda en una lista de objetos tipo TaskModel y muestra la lista en la vista
        {
            ViewBag.Message = "Completed Tasks List";

            var data = TaskProcessor.LoadCompletedTask();
            List<TaskModel> tasks = new List<TaskModel>();

            foreach (var row in data)
            {
                tasks.Add(new TaskModel
                {
                    TaskName = row.TaskName,
                    TaskCompleted = row.TaskCompleted
                });
            }

            return View(tasks);
        }

        public ActionResult ViewUnfinishedTasks()//toma las tareas incompletas de la base de datos, las guarda en una lista de objetos tipo TaskModel y muestra la lista en la vista
        {
            ViewBag.Message = "Completed Tasks List";

            var data = TaskProcessor.LoadUnfinishedTask();
            List<TaskModel> tasks = new List<TaskModel>();

            foreach (var row in data)
            {
                tasks.Add(new TaskModel
                {
                    TaskName = row.TaskName,
                    TaskCompleted = row.TaskCompleted
                });
            }

            return View(tasks);
        }

        public ActionResult AddTask()
        {
            ViewBag.Message = "Task Add";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTask(TaskModel model)//añade una tarea a la base de datos
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = TaskProcessor.CreateTask(model.TaskName, model.TaskCompleted);
                return RedirectToAction("ViewTasks");
            }

            return View();
        }
    }
}