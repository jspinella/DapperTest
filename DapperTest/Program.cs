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
                InsertAsync2(),
            });

            Task.WhenAll(tasks);
            //await ResetAsync();
        }

        public static async Task InsertAsync()
        {
            //var sql = @"INSERT INTO Test VALUES (1,'John'),(2,'James')";
            var sql = "insert into Test (3, 'Andrew')";

            using (var connection = new SqlConnection(CONNSTRING))
                await connection.ExecuteAsync(sql);
        }

        public static async Task InsertAsync2()
        {
            //var sql = @"INSERT INTO Test VALUES (1,'John'),(2,'James')";
            var sql = "insert into Test (4, 'George')";

            using (var connection = new SqlConnection(CONNSTRING))
                await connection.ExecuteAsync(sql);
        }

        public static async Task ResetAsync()
        {
            //var sql = @"DELETE FROM Test";
            var sql = "some invalid sql";

            using (var connection = new SqlConnection(CONNSTRING))
                await connection.ExecuteAsync(sql);
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
