using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class FacturaActiveRecord
    {
        public int Numero { get; set; }
        public string Concepto { get;  set; }

        public FacturaActiveRecord(int numero, string concepto)
        {
            Numero = numero;
            Concepto = concepto;
        }
        public static List<FacturaActiveRecord> buscarTodos()
        {
            List<FacturaActiveRecord> listaFacturas = new List<FacturaActiveRecord>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from Facturas";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    listaFacturas.Add(new FacturaActiveRecord(Convert.ToInt32(lector["numero"]), Convert.ToString(lector["concepto"])));
                }
            }
            return listaFacturas;
        }


        public void Insertar()
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "insert into Facturas values(" + Numero + ",'" + Concepto + "')";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
            }
        }
        public void Borrar()
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "delete from Facturas where numero ="+ Numero;
                SqlCommand comando = new SqlCommand(sql, conexion);
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
