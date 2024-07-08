using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión exitosa!");

                    // Llamar al procedimiento almacenado
                    MySqlCommand command = new MySqlCommand("sp_listar_clientes", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Reemplaza "ColumnName" por el nombre de la columna que deseas mostrar
                            Console.WriteLine($"{reader["Form1.cs"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            
        }
    }
}
