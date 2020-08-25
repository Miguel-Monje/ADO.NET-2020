using Semicrol.Curso.Dominio;
using Semicrol.Curso.Filtros;
using Semicrol.Curso.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Curso.PersistenciaADO
{
    public class LineaFacturaRepository :ILineaFacturaRepository
    {

        public void Insertar(LineaFactura lf)
        {
            using (SqlConnection conexion = GestionConexion.GetConexion())
            {
                conexion.Open();
                String sql = "insert into LineasFactura values(@Numero ,@Facturas_Numero, @Productos_Id,@Unidades)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", lf.Numero);
                comando.Parameters.AddWithValue("@Facturas_Numero", lf.Factura.Numero);
                comando.Parameters.AddWithValue("Productos_Id", lf.ProductoId);
                comando.Parameters.AddWithValue("@Unidades", lf.Unidades);
                comando.ExecuteNonQuery();
            }
        }
        public void Borrar(LineaFactura lf)
        {
            using (SqlConnection conexion = GestionConexion.GetConexion())
            {
                conexion.Open();
                String sql = "delete from LineasFactura where numero = @Numero and facturas_numero = @Facturas_Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", lf.Numero);
                comando.Parameters.AddWithValue("@Facturas_Numero", lf.Factura.Numero);
                comando.ExecuteNonQuery();
            }
        }

        public List<LineaFactura> BuscarTodos()
        {
            List<LineaFactura> listaFacturas = new List<LineaFactura>();
            using (SqlConnection conexion = GestionConexion.GetConexion())
            {
                conexion.Open();
                String sql = "select * from LineasFactura";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    listaFacturas.Add(
                        new LineaFactura(
                            Convert.ToInt32(lector["numero"]),
                            new Factura(Convert.ToInt32(lector["facturas_numero"])),
                            lector["productos_id"].ToString(),
                            Convert.ToInt32(lector["unidades"])));
                }
            }
            return listaFacturas;
        }

        public LineaFactura BuscarUno(int numero,int numFactura)
        {
            LineaFactura lf = null;
            using (SqlConnection conexion = GestionConexion.GetConexion())
            {
                conexion.Open();
                String sql = "select * from Facturas where numero= @Numero and facturas_numero= @FacturaNumero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", numero);
                comando.Parameters.AddWithValue("@FacturaNumero", numFactura);
                SqlDataReader lector = comando.ExecuteReader();
                if (!lector.Read())
                {
                    throw new Exception("No se ha encontrado la factura");
                }
                lf = new LineaFactura(
                            Convert.ToInt32(lector["numero"]),
                            new Factura(Convert.ToInt32(lector["facturas_numero"])),
                            lector["productos_id"].ToString(),
                            Convert.ToInt32(lector["unidades"]));
            }
            return lf;
        }

        public List<LineaFactura> BuscarTodos(FiltroLineaFactura filtro)
        {
            List<LineaFactura> listaFacturas = new List<LineaFactura>();
            using (SqlConnection conexion = GestionConexion.GetConexion())
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                String sql = "select * from Facturas";

                bool compruebo = false;

                if (filtro.Numero != 0)
                {
                    sql += " where Numero = @Numero";
                    comando.Parameters.AddWithValue("@Numero", filtro.Numero);
                    compruebo = true;
                }
                if (filtro.FacturaNumero != 0)
                {
                    if (!compruebo)
                    {
                        sql += " where facturas_numero = @FacturaNumero";
                        compruebo = true;
                    }
                    else
                    {
                        sql += " and facturas_numero = @FacturaNumero";
                    }
                    comando.Parameters.AddWithValue("@FacturaNumero", filtro.FacturaNumero);
                }
                if (filtro.ProductoId != null)
                {
                    if (!compruebo)
                    {
                        sql += " where productos_id = @ProductosId";
                        compruebo = true;
                    }
                    else
                    {
                        sql += " and productos_id = @ProductosId";
                    }                      
                    comando.Parameters.AddWithValue("@ProductosId", filtro.ProductoId);
                }
                if (filtro.Unidades != 0)
                {
                    if (!compruebo)
                    {
                        sql += " where unidades = @Unidades";
                        compruebo = true;
                    }
                    else
                    {
                        sql += " and unidades = @Unidades";
                    }
                    comando.Parameters.AddWithValue("@Unidades", filtro.Unidades);
                }

                comando.Connection = conexion;
                comando.CommandText = sql;

                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    listaFacturas.Add(new LineaFactura(
                            Convert.ToInt32(lector["numero"]),
                            new Factura(Convert.ToInt32(lector["facturas_numero"])),
                            lector["productos_id"].ToString(),
                            Convert.ToInt32(lector["unidades"])));
                }
            }
            return listaFacturas;
        }

        public void Actualizar(LineaFactura lf)
        {
            using (SqlConnection conexion = GestionConexion.GetConexion())
            {
                conexion.Open();
                String sql = "update LineasFactura set productos_id = @Productos_Id, unidades = @Unidades where numero = @Numero and facturas_numero = @Facturas_Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", lf.Numero);
                comando.Parameters.AddWithValue("@Facturas_Numero", lf.Factura.Numero);
                comando.Parameters.AddWithValue("Productos_Id", lf.ProductoId);
                comando.Parameters.AddWithValue("@Unidades", lf.Unidades);
                comando.ExecuteNonQuery();
            }
        }
    }
}
