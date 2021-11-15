using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DapperMVCCRUD.Models
{
    public static class DapperORM
    {
        private static string connectionstring = @"Data Source= . ;Initial Catalog=newdb;Integrated Security=True;";

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param=null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        //DapperORM.ExecuteReturnScalar<int>()
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param=null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
             return(T)  Convert.ChangeType(sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure),typeof(T));

            }
        }

        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param=null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                return  sqlcon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);

            }
        }

    }
}