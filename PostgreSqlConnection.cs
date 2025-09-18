using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Test
{
    public class PostgreSqlConnection : IDisposable
    {
        private readonly string _connectionString;
        private NpgsqlConnection _connection;
        private bool _disposed = false;

        /// <summary>
        /// Создает экземпляр класса для подключения к PostgreSQL
        /// </summary>
        public PostgreSqlConnection(string host, string database, string username, string password, int port = 5432)
        {
            _connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};";
            _connection = new NpgsqlConnection(_connectionString);
        }

        /// <summary>
        /// Создает экземпляр класса с готовой строкой подключения
        /// </summary>
        public PostgreSqlConnection(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new NpgsqlConnection(_connectionString);
        }

        /// <summary>
        /// Открывает подключение к базе данных
        /// </summary>
        public void OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
                Console.WriteLine("Подключение к PostgreSQL открыто");
            }
        }

        /// <summary>
        /// Закрывает подключение к базе данных
        /// </summary>
        public void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
                Console.WriteLine("Подключение к PostgreSQL закрыто");
            }
        }

        /// <summary>
        /// Возвращает состояние подключения
        /// </summary>
        public ConnectionState ConnectionState
        {
            get { return _connection.State; }
        }

        /// <summary>
        /// Выполняет SQL запрос без возврата данных
        /// </summary>
        public int ExecuteNonQuery(string sql, params NpgsqlParameter[] parameters)
        {
            using (var command = new NpgsqlCommand(sql, _connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Выполняет SQL запрос и возвращает скалярное значение
        /// </summary>
        public object ExecuteScalar(string sql, params NpgsqlParameter[] parameters)
        {
            using (var command = new NpgsqlCommand(sql, _connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                return command.ExecuteScalar();
            }
        }

        /// <summary>
        /// Выполняет SQL запрос и возвращает DataReader
        /// </summary>
        public NpgsqlDataReader ExecuteReader(string sql, params NpgsqlParameter[] parameters)
        {
            var command = new NpgsqlCommand(sql, _connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            return command.ExecuteReader();
        }

        /// <summary>
        /// Выполняет SQL запрос и возвращает DataTable
        /// </summary>
        public DataTable ExecuteDataTable(string sql, params NpgsqlParameter[] parameters)
        {
            using (var command = new NpgsqlCommand(sql, _connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                using (var adapter = new NpgsqlDataAdapter(command))
                {
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        /// <summary>
        /// Начинает транзакцию
        /// </summary>
        public NpgsqlTransaction BeginTransaction()
        {
            return _connection.BeginTransaction();
        }

        /// <summary>
        /// Начинает транзакцию с указанным уровнем изоляции
        /// </summary>
        public NpgsqlTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return _connection.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Проверяет доступность подключения
        /// </summary>
        public bool TestConnection()
        {
            try
            {
                OpenConnection();
                using (var command = new NpgsqlCommand("SELECT 1", _connection))
                {
                    command.ExecuteScalar();
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Проверяет существование таблицы
        /// </summary>
        public bool TableExists(string tableName)
        {
            try
            {
                OpenConnection();
                var sql = @"SELECT EXISTS (
                SELECT 1 FROM information_schema.tables 
                WHERE table_schema = 'public' 
                AND table_name = @tableName
            )";

                using (var command = new NpgsqlCommand(sql, _connection))
                {
                    command.Parameters.AddWithValue("@tableName", tableName);
                    return (bool)command.ExecuteScalar();
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Получает количество записей в таблице
        /// </summary>
        public long GetRecordCount(string tableName)
        {
            try
            {
                OpenConnection();
                var sql = $"SELECT COUNT(*) FROM {tableName}";

                using (var command = new NpgsqlCommand(sql, _connection))
                {
                    return Convert.ToInt64(command.ExecuteScalar());
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Освобождает ресурсы
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_connection != null)
                    {
                        if (_connection.State != ConnectionState.Closed)
                        {
                            _connection.Close();
                        }
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~PostgreSqlConnection()
        {
            Dispose(false);
        }
    }
}

