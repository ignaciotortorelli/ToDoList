using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;//añadir Dapper desde NuGet
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName="MVCDemoDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)//toma una query de sql, carga datos al modelo "T" y devuelve una lista de ese modelo
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();//toma esa query, la carga a tipo "T", la pasa por la base de datos, devuelve un resultado IEnumerable, lo convierte en una lista y lo devuelve en el return
            }
        }

        public static int SaveData<T>(string sql, T data)//toma una query de sql, mas los datos para la tabla y la envia a la base de datos
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }
    }
}
