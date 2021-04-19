using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class TaskProcessor
    {
        public static int CreateTask(string taskName, Boolean taskDone)//toma un string y un valor bool y los carga en la base de datos como tarea
        {
            TaskModel data = new TaskModel
            {
                TaskName = taskName,
                TaskCompleted = taskDone
            };

            string sql = @"INSERT INTO dbo.TaskTable (TaskName, TaskCompleted) VALUES (@TaskName, @TaskCompleted); ";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteTask(string taskName)//toma el nombre de una tarea y elimina de la base de datos todas las que se llamen igual
        {
            TaskModel data = new TaskModel
            {
                TaskName = taskName
            };

            string sql = @"DELETE FROM dbo.TaskTable WHERE TaskName=@TaskName; ";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int ClearCompleted()//limpia de la base de datos todas las tareas completadas
        {
            string sql = @"DELETE FROM dbo.TaskTable WHERE TaskCompleted=1; ";
            TaskModel data = new TaskModel { };
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<TaskModel> LoadTask()//hace un query al sql y devuelve todas las tareas cargadas al modelo DataAccess.TaskModel
        {
            string sql = @"SELECT Id, TaskName, TaskCompleted FROM dbo.TaskTable;";

            return SqlDataAccess.LoadData<TaskModel>(sql);
        }

        public static List<TaskModel> LoadCompletedTask()//hace un query al sql y devuelve todas las tareas completadas cargadas al modelo DataAccess.TaskModel
        {
            string sql = @"SELECT Id, TaskName, TaskCompleted FROM dbo.TaskTable WHERE TaskCompleted=1;";

            return SqlDataAccess.LoadData<TaskModel>(sql);
        }

        public static List<TaskModel> LoadUnfinishedTask()//hace un query al sql y devuelve todas las tareas no completadas cargadas al modelo DataAccess.TaskModel
        {
            string sql = @"SELECT Id, TaskName, TaskCompleted FROM dbo.TaskTable WHERE TaskCompleted=0;";

            return SqlDataAccess.LoadData<TaskModel>(sql);
        }
    }
}
