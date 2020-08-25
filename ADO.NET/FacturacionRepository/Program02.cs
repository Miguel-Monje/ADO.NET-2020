using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.FacturacionRepository
{
    class Program02
    {
        static void Main(string[] args)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
        String cadena = settings.ConnectionString;

        SqlTransaction transaccion = null;

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                transaccion = conexion.BeginTransaction();
                SqlCommand comando1 = new SqlCommand("insert into Facturas values(5 ,'nuevo1')");
                SqlCommand comando2 = new SqlCommand("insert into Facturas values(6 ,'nuevo2')");
                try
                {
                    comando1.ExecuteNonQuery();
                    comando2.ExecuteNonQuery();

                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                }
                finally
                {
                    conexion.Close();
                }
            }

        }   

    }
}
