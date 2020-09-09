using MySql.Data.MySqlClient;
using System;

namespace PA.EjIDisposable
{
    public class DatabaseWrapperDispose : IDisposable
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

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected void Dispose(bool disposing)
		{
			if (disposing)
			{
				_connection.Close();
				_connection.Dispose();
			}
		}

		~DatabaseWrapperDispose()
		{
			Dispose(false);
		}
	}
}
