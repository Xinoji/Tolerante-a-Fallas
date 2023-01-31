using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Using_Checked
{
    internal class Using
    {
        public DataTable Resultado { get; private set; }

        public abstract class DbConnection
        {
            private readonly string connectionString;

            public DbConnection()
            {
                connectionString = "Server= ;Database= ;Trusted_Connection=True;";// conexion de la DB
            }

            protected SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
        }

        private void ejemplo() 
        {

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {

                    DataTable dt = new DataTable();
                    command.Connection = connection;

                    command.CommandText = "select Modelo_Maquina as [Plan A] from Reparacion";
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                    Resultado = dt;
                }
            }
        }
    }
    }
}
