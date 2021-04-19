using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskListWebPage.Models
{
    public class TaskModel//modelo de tareas para el controlador
    {
        [Required(ErrorMessage = "fill the Task Name field")]
        public string TaskName { get; set; }

        public bool TaskCompleted { get; set; }
    }
}