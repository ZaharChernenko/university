﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace isit_7.storage
{
    public class SqlConnectionProvider
    {
        public SqlConnectionProvider(string connectionString)
        {
            mConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public SqlConnection GetConnection()
        {
            var connection = new SqlConnection(mConnectionString);
            return connection;
        }
        protected readonly string mConnectionString;
    }

    public class SqlTableReaderMixin
    {
        public SqlTableReaderMixin(SqlConnectionProvider connectionProvider)
        {
            mConnectionProvider = connectionProvider ?? throw new ArgumentNullException(nameof(connectionProvider));
        }

        public DataTable GetTableData(in string tableName)
        {
            var dataTable = new DataTable();
            using (var connection = mConnectionProvider.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM \"{tableName}\"";

                using (var adapter = new SqlDataAdapter((SqlCommand)command))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        protected readonly SqlConnectionProvider mConnectionProvider;
    }

    public class TSQLUniversityRepository : SqlTableReaderMixin, IUniversityRepository
    {
        // через двоеточие инициализируется только базовый класс,
        // а не все элементы класса, как в C++
        public TSQLUniversityRepository(SqlConnectionProvider connectionProvider) : base(connectionProvider) {}

        public void AddHours(in string exam, int hours)
        {
            using (var connection = mConnectionProvider.GetConnection())
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

        public void AddCash()
        {
            using (var connection = mConnectionProvider.GetConnection())
            using (var cmd = new SqlCommand("add_cash", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddCashWhereEqualTo(int equalTo, int addAmount)
        {
            using (var connection = mConnectionProvider.GetConnection())
            using (var cmd = new SqlCommand("add_cash_where_equal", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@equal_to",
                    SqlDbType = SqlDbType.Int,
                    Value = equalTo
                });
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@add_amount",
                    SqlDbType = SqlDbType.Int,
                    Value = addAmount
                });

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddCashWhere5(int addAmount)
        {
            using (var connection = mConnectionProvider.GetConnection())
            using (var cmd = new SqlCommand("add_cash_where_5", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@amount",
                    SqlDbType = SqlDbType.Int,
                    Value = addAmount
                });

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddCashWhereGreater(int bound)
        {
            using (var connection = mConnectionProvider.GetConnection())
            using (var cmd = new SqlCommand("add_cash_where_greater", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@bound",
                    SqlDbType = SqlDbType.Int,
                    Value = bound
                });

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public DataTable GetExamData()
        {
            return GetTableData(mExamTableName);
        }

        public DataTable GetStudentData()
        {
            return GetTableData(mStudentTableName);
        }

        public DataTable GetExamWithDisciplineNamesData()
        {
            var dataTable = new DataTable();
            using (var connection = mConnectionProvider.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT \"{mExamTableName}\".*, \"{mDisciplineTableName}\".Наименование_дисциплины AS \"Дисциплина\" FROM \"{mExamTableName}\", \"{mDisciplineTableName}\" WHERE \"{mDisciplineTableName}\".Код_дисциплины = \"{mExamTableName}\".Код_дисциплины";

                using (var adapter = new SqlDataAdapter((SqlCommand)command))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        public string[] GetDisciplineNames()
        {
            var disciplineNames = new List<string>();

            using (var connection = mConnectionProvider.GetConnection())
            using (var cmd = new SqlCommand($"SELECT Наименование_дисциплины FROM {mDisciplineTableName}", connection))
            {
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        disciplineNames.Add(reader.GetString(0));
                }
            }

            return disciplineNames.ToArray();
        }

        public int GetAverageHours()
        {
            using (var connection = mConnectionProvider.GetConnection())
            using (var cmd = new SqlCommand($"SELECT AVG(Количество_часов) FROM \"{mExamTableName}\"", connection))
            {
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        throw new InvalidOperationException("Нет результата");
                    }

                    return reader.GetInt32(0);
                }
            }
        }

        public int Factorial(int n)
        {
            using (var connection = mConnectionProvider.GetConnection())
            using (var cmd = new SqlCommand("factorial_1", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@n",
                    SqlDbType = SqlDbType.Int,
                    Value = n 
                });

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        throw new InvalidOperationException("Нет результата");
                    }

                    if (reader.IsDBNull(0))
                    {
                        throw new ArgumentException("Факториал определен только для положительных чисел");
                    }

                    return reader.GetInt32(0);
                }
            }
        }

        public int Series(int n)
        {
            using (var connection = mConnectionProvider.GetConnection())
            using (var cmd = new SqlCommand("row_sum_1", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@n",
                    SqlDbType = SqlDbType.Int,
                    Value = n
                });

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        throw new InvalidOperationException("Нет результата");
                    }

                    if (reader.IsDBNull(0))
                    {
                        throw new ArgumentException("Сумма ряда определена только для положительных чисел");
                    }

                    return reader.GetInt32(0);
                }
            }
        }

        protected readonly IConfiguration mConfiguration;
        protected readonly string mDisciplineTableName = "Дисциплина", mExamTableName = "Экзамен", mStudentTableName = "Студент";
    }
}
