using isit_7.storage;

using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace isit_7.storage
{
    public class TUniversitySQLStorageHelperMixin
    {
        // di не работает с in, поэтому передача по значению
        public TUniversitySQLStorageHelperMixin(IConfiguration configuration)
        {
            m_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected DataTable GetTableData(in string table_name)
        {
            var connectionString = GetConnectionString();
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand($"SELECT * FROM {table_name}", connection))
            {
                connection.Open();
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        protected string GetConnectionString()
        {
            return m_configuration.GetConnectionString("university")
                ?? throw new InvalidOperationException("Connection string 'university' not found in configuration");
        }

        protected readonly IConfiguration m_configuration;
    }

    public class TExamSQLStorage : TUniversitySQLStorageHelperMixin, IExamStorage
    {
        // через двоеточие инициализируется только базовый класс,
        // а не все элементы класса, как в C++
        public TExamSQLStorage(IConfiguration configuration) : base(configuration)
        {
        }

        public void AddHours(in string exam, int hours)
        {
            var connectionString = GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("add_hours", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@exam",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = exam
                });
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@hours",
                    SqlDbType = SqlDbType.Int,
                    Value = hours
                });

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetExamsData()
        {
            return GetTableData(GetExamTableName());
        }

        protected string GetExamTableName()
        {
            return m_configuration.GetSection("Tables")["exam"]
               ?? throw new InvalidOperationException("Table name 'exam' not found in configuration");
        }
    }
}
