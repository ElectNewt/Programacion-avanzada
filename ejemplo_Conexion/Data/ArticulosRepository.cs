using Data.Interfaces;
using DTOs;
using MySql.Data.MySqlClient;
using System;

namespace Data
{
    public class ArticulosRepository : IArticulosRepository
    {
        private readonly string conexionString;
        public ArticulosRepository()
        {
            conexionString = "Server=127.0.0.1;Port=3306;Database=ejemplo-conexion;Uid=root;password=test";
        }


        public Articulo GetArticulo(int id)
        {
            using(MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                //Codigo para el select
                conexion.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "select * from articulo where id = ?articuloId;";
                comando.Parameters.Add("?articuloId", MySqlDbType.Int32).Value = id;
                comando.Connection = conexion;

                Articulo articulo = new Articulo();
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        articulo.Id = Convert.ToInt32(reader["Id"]);
                        articulo.Titulo = reader["Titulo"].ToString();
                        articulo.Contenido = reader["Contenido"].ToString();
                    }

                    return articulo;
                }
            }
        }

        public int InsertarArticulo(string contenido, string titulo, int autorId)
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                //Codigo para el select
                conexion.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "insert into articulos (`Titulo`, `Contenido`, `AutorId`, `Fecha`) VALUES (?titulo, ?contenido, ?autorid, ?fecha);";
                comando.Connection = conexion;
                comando.Parameters.Add("?titulo", MySqlDbType.String).Value = titulo;
                comando.Parameters.Add("?contenido", MySqlDbType.String).Value = contenido;
                comando.Parameters.Add("?autorid", MySqlDbType.Int32).Value = autorId;
                comando.Parameters.Add("?fecha", MySqlDbType.DateTime).Value = DateTime.Now;

                comando.ExecuteNonQuery();
                return (int)comando.LastInsertedId;
            }
        }

        public void Actualizar(int articuloid, string titulo)
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                //Codigo para el select
                conexion.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "update articulos set `titulo` = ?titulo where id =?id;";
                comando.Connection = conexion;
                comando.Parameters.Add("?titulo", MySqlDbType.String).Value = titulo;
                comando.Parameters.Add("?id", MySqlDbType.Int32).Value = articuloid;

                comando.ExecuteNonQuery();
            }
        }
    }
}

