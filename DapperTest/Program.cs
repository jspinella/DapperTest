using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DapperTest
{
    class Program
    {
        public static readonly string CONNSTRING = "Server=localhost; Database=Test; Trusted_Connection=True;";

        static void Main(string[] args)
        {
            DatabaseOperations();
        }

        private static void DatabaseOperations()
        {
            var tasks = new List<Task>();

            tasks.AddRange(new List<Task> {
                InsertAsync(),
                ResetAsync(),
            });

            Task.WhenAll(tasks);
            //await ResetAsync();
        }

        public static Task InsertAsync()
        {
            //var sql = @"INSERT INTO Test VALUES (1,'John'),(2,'James')";
            var sql = "some invalid sql";

            using (var connection = new SqlConnection(CONNSTRING))
                return connection.ExecuteAsync(sql);
        }

        public static Task ResetAsync()
        {
            //var sql = @"DELETE FROM Test";
            var sql = "some invalid sql";

            using (var connection = new SqlConnection(CONNSTRING))
                return connection.ExecuteAsync(sql);
        }

        public static void Reset()
        {
            //var sql = @"DELETE FROM Test";
            var sql = "some invalid sql";

            using (var connection = new SqlConnection(CONNSTRING))
                connection.Execute(sql);
        }
    }
}
