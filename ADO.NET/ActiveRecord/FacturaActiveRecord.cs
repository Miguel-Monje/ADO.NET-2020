using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.ActiveRecord
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
        public static List<FacturaActiveRecord> BuscarTodos()
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
                String sql = "insert into Facturas values(@Numero ,@Concepto)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
                comando.Parameters.AddWithValue("@Concepto", Concepto);
                comando.ExecuteNonQuery();
            }
        }
        public void Borrar()
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "delete from Facturas where numero = @Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
                comando.ExecuteNonQuery();
            }
        }

        public void Actualizar()
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "update Facturas set concepto = @Concepto where numero = @Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
                comando.Parameters.AddWithValue("@Concepto", Concepto);
                comando.ExecuteNonQuery();
            }
        }

        private static string CadenaConexion()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
            String cadena = settings.ConnectionString;
            return cadena;
        }

        public static FacturaActiveRecord BuscarUno(int numeroFactura)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from Facturas where numero= @numeroFactura"; 
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@numeroFactura", numeroFactura);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    FacturaActiveRecord f = new FacturaActiveRecord(Convert.ToInt32(lector["numero"]), Convert.ToString(lector["concepto"]));
                    return f;
                }
                else
                {
                    throw new Exception("No se ha encontrado la factura");
                }
 
            }
        }

        public static List<FacturaActiveRecord> BuscarPorConcepto(string concepto)
        {
            List<FacturaActiveRecord> listaFacturas = new List<FacturaActiveRecord>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from Facturas where concepto= @concepto";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@concepto", concepto);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                   listaFacturas.Add( new FacturaActiveRecord(Convert.ToInt32(lector["numero"]), Convert.ToString(lector["concepto"])));
                }
            }
            return listaFacturas;
        }

        public static List<FacturaActiveRecord> BuscarFiltro(FiltroFactura filtro)
        {
            List<FacturaActiveRecord> listaFacturas = new List<FacturaActiveRecord>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from Facturas";
                if(filtro.Numero != 0 && filtro.Concepto != null)
                {
                    sql += " where Numero = @Numero and Concepto = @Concepto";
                }
                else if(filtro.Numero!= 0)
                {
                    sql += " where Numero = @Numero";
                }
                else if(filtro.Concepto != null)
                {
                    sql += " where Concepto = @Concepto";
                }
                SqlCommand comando = new SqlCommand(sql, conexion);
                if (filtro.Numero != 0)
                {
                    comando.Parameters.AddWithValue("@Numero", filtro.Numero);
                }
                if (filtro.Concepto != null)
                {
                    comando.Parameters.AddWithValue("@Concepto", filtro.Concepto);
                }
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    listaFacturas.Add(new FacturaActiveRecord(Convert.ToInt32(lector["numero"]), Convert.ToString(lector["concepto"])));
                }
            }
            return listaFacturas;
        }

        public List<LineasFacturaActiveRecord> LineasFactura()
        {
            List<LineasFacturaActiveRecord> lista = new List<LineasFacturaActiveRecord>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select LineasFactura.* from LineasFactura where LineasFactura.facturas_numero = @Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
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

        public List<FacturaLineaDTO> BuscarFacturaLineas()
        {
            List<FacturaLineaDTO> lista = new List<FacturaLineaDTO>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                {
                    conexion.Open();
                    String sql = "select Facturas.*,LineasFactura.productos_id,LineasFactura.unidades from Facturas inner join LineasFactura on facturas_numero = Facturas.numero and Facturas.Numero = @Numero";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@Numero", Numero);
                    SqlDataReader lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        lista.Add(
                           new FacturaLineaDTO(
                               Convert.ToInt32(lector["numero"]),
                               lector["concepto"].ToString(),
                               lector["productos_id"].ToString(),
                               Convert.ToInt32(lector["unidades"])));
                    }

                }
                
            }
            return lista;
        }

        public static List<FacturaLineaDTO> BuscarFacturasLineas()
        {
            List<FacturaLineaDTO> lista = new List<FacturaLineaDTO>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                {
                    conexion.Open();
                    String sql = "select * from Facturas inner join LineasFactura on facturas_numero = Facturas.numero";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    SqlDataReader lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        lista.Add(
                           new FacturaLineaDTO(
                               Convert.ToInt32(lector["Facturas.numero"]),
                               lector["concepto"].ToString(),
                               lector["productos_id"].ToString(),
                               Convert.ToInt32(lector["unidades"])));
                    }

                }

            }
            return lista;
        }

        public static int UnidadesTotales()
        {
            int unidades = 0;

            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select sum(unidades) from LineasFactura";
                SqlCommand comando = new SqlCommand(sql, conexion);
                unidades = Convert.ToInt32(comando.ExecuteScalar());
            }

             return unidades;
        }

    }
}
