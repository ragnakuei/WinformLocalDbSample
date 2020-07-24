using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace WinformLocalDbSample
{
    public class TestRepository
    {

        public TestRepository()
        {
            _connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\DB.mdf;Integrated Security=True";
        }

        public TestDTO[] Get()
        {

            using (SqlConnection conn = new SqlConnection(_connection))
            {
                var sql    = @"select * from Test";
                var result = conn.Query<TestDTO>(sql).ToArray();
                return result;
            }
        }

        public void Add(TestDTO testDto)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                var sql    = @"insert into Test VALUES (@id, @name)";
                var pararmeters = new DynamicParameters();

                pararmeters.Add("id", testDto.Id);
                pararmeters.Add("name", testDto.Name);

                conn.Execute(sql, pararmeters);
            }
        }

        private readonly string _connection;
    }
}
