using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.ActiveRecord
{
    class LineasFacturaActiveRecord
    {
        

        public int Numero {get;set;}
        public int FacturasNumero { get; set; }
        public string ProductosId { get; set; }
        public int Unidades { get; set; }

        public LineasFacturaActiveRecord(int numero, int facturasNumero, string productosId, int unidades)
        {
            Numero = numero;
            FacturasNumero = facturasNumero;
            ProductosId = productosId;
            Unidades = unidades;
        }

        public static List<LineasFacturaActiveRecord> BuscarTodos()
        {
            List<LineasFacturaActiveRecord> lista = new List<LineasFacturaActiveRecord>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from LineasFactura";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    lista.Add(
                        new LineasFacturaActiveRecord(
                            Convert.ToInt32(lector["numero"]), 
                            Convert.ToInt32(lector["facturas_numero"]),
                            lector["productos_id"].ToString(),
                            Convert.ToInt32(lector["unidades"])));
                }
            }
            return lista;
        }


        public void Insertar()
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "insert into LineasFactura values(@Numero ,@Facturas_Numero, @Productos_Id,@Unidades)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
                comando.Parameters.AddWithValue("@Facturas_Numero", FacturasNumero);
                comando.Parameters.AddWithValue("Productos_Id", ProductosId);
                comando.Parameters.AddWithValue("@Unidades", Unidades);
                comando.ExecuteNonQuery();
            }
        }
        public void Borrar()
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "delete from LineasFactura where numero = @Numero and facturas_numero = @Facturas_Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
                comando.Parameters.AddWithValue("@Facturas_Numero", FacturasNumero);
                comando.ExecuteNonQuery();
            }
        }

        public void Actualizar()
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "update LineasFactura set productos_id = @Productos_Id, unidades = @Unidades where numero = @Numero and facturas_numero = @Facturas_Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
                comando.Parameters.AddWithValue("@Facturas_Numero", FacturasNumero);
                comando.Parameters.AddWithValue("Productos_Id", ProductosId);
                comando.Parameters.AddWithValue("@Unidades", Unidades);
                comando.ExecuteNonQuery();
            }
        }

        private static string CadenaConexion()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
            String cadena = settings.ConnectionString;
            return cadena;
        }

    }
}
