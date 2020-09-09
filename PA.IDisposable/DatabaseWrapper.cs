using MySql.Data.MySqlClient;
using System;

namespace PA.EjIDisposable
{
    public class DatabaseWrapper
    {
		private MySqlConnection _connection;

		public string GetFecha()
		{
			if (_connection == null)
			{
				_connection = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=personal;Uid=root;password=test;");
				_connection.Open();
			}
			using (var command = _connection.CreateCommand())
			{
				command.CommandText = "SELECT NOW()";
				return command.ExecuteScalar().ToString();
			}
		}
	}
}
