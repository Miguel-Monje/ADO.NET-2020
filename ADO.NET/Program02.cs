using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program02
    {
        static void Main(string[] args)
        {

            SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\formacion\facturacion.mdf;Integrated Security=True;Connect Timeout=30");
            conexion.Open();
            String sql = "insert into Facturas values(5,'otra')";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.ExecuteNonQuery();

            sql = "select * from Facturas";
            comando = new SqlCommand(sql, conexion);
            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Console.WriteLine(lector["numero"].ToString());
                Console.WriteLine(lector["concepto"].ToString());
            }
            Console.ReadLine();

        }
    }
}
