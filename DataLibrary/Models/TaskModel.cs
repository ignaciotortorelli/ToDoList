using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class TaskModel// modelo de tareas para la base de datos
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public bool TaskCompleted { get; set; }
    }
}
