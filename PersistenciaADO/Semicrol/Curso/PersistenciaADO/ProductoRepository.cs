using Semicrol.Curso.Dominio;
using Semicrol.Curso.Filtros;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Curso.PersistenciaADO
{
    class ProductoRepository
    {
        class LineaFacturaRepository
        {

            public void Insertar(Producto p)
            {
                using (SqlConnection conexion = GestionConexion.GetConexion())
                {
                    conexion.Open();
                    String sql = "insert into Productos values(@Id ,@Nombre, @Importe, @Categoria)";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@Id", p.Id);
                    comando.Parameters.AddWithValue("@Nombre", p.Nombre);
                    comando.Parameters.AddWithValue("@Importe", p.Importe);
                    comando.Parameters.AddWithValue("@Categoria", p.Categoria);
                    comando.ExecuteNonQuery();
                }
            }
            public void Borrar(Producto p)
            {
                using (SqlConnection conexion = GestionConexion.GetConexion())
                {
                    conexion.Open();
                    String sql = "delete from Productos where id = @Id";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@Id", p.Id);
                    comando.ExecuteNonQuery();
                }
            }

            public List<Producto> BuscarTodos()
            {
                List<Producto> listaFacturas = new List<Producto>();
                using (SqlConnection conexion = GestionConexion.GetConexion())
                {
                    conexion.Open();
                    String sql = "select * from LineasFactura";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    SqlDataReader lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        listaFacturas.Add(
                            new Producto(
                                lector["id"].ToString(),
                                lector["nombre"].ToString(),
                                Convert.ToDouble(lector["importe"]),
                                lector["categoria"].ToString()));
                    }
                }
                return listaFacturas;
            }

            public Producto BuscarUno(string id)
            {
                Producto p = null;
                using (SqlConnection conexion = GestionConexion.GetConexion())
                {
                    conexion.Open();
                    String sql = "select * from Facturas where id= @Id";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@Id", p.Id);
                    SqlDataReader lector = comando.ExecuteReader();
                    if (!lector.Read())
                    {
                        throw new Exception("No se ha encontrado la factura");
                    }
                    p = new Producto(
                                lector["id"].ToString(),
                                lector["nombre"].ToString(),
                                Convert.ToDouble(lector["importe"]),
                                lector["categoria"].ToString());
                }
                return p;
            }

            public List<Producto> BuscarTodos(FiltroProducto filtro)
            {
                List<Producto> listaProductos = new List<Producto>();
                using (SqlConnection conexion = GestionConexion.GetConexion())
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand();
                    String sql = "select * from Productos";

                    bool compruebo = false;

                    if (filtro.Id != null)
                    {
                        sql += " where id = @Id";
                        comando.Parameters.AddWithValue("@Id", filtro.Id);
                        compruebo = true;
                    }
                    if (filtro.Nombre != null)
                    {
                        if (!compruebo)
                        {
                            sql += " where nombre = @Nombre";
                            compruebo = true;
                        }
                        else
                        {
                            sql += " and nombre = @Nombre";
                        }
                        comando.Parameters.AddWithValue("@Nombre", filtro.Nombre);
                    }
                    if (filtro.Importe != 0.0)
                    {
                        if (!compruebo)
                        {
                            sql += " where importe = @Importe";
                            compruebo = true;
                        }
                        else
                        {
                            sql += " and importe = @Importe";
                        }
                        comando.Parameters.AddWithValue("@Importe", filtro.Importe);
                    }
                    if (filtro.Categoria != null)
                    {
                        if (!compruebo)
                        {
                            sql += " where categoria = @Categoria";
                            compruebo = true;
                        }
                        else
                        {
                            sql += " and categoria = @Categoria";
                        }
                        comando.Parameters.AddWithValue("@Categoria", filtro.Categoria);
                    }

                    comando.Connection = conexion;
                    comando.CommandText = sql;

                    SqlDataReader lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        listaProductos.Add(new Producto(
                                lector["id"].ToString(),
                                lector["nombre"].ToString(),
                                Convert.ToDouble(lector["importe"]),
                                lector["categoria"].ToString()));
                    }
                }
                return listaProductos;
            }

            public void Actualizar(Producto p)
            {
                using (SqlConnection conexion = GestionConexion.GetConexion())
                {
                    conexion.Open();
                    String sql = "update Productos set nombre = @Nombre, importe = @Importe, categoria = @Categoria where id = @Id";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@Id", p.Id);
                    comando.Parameters.AddWithValue("@Nombre", p.Nombre);
                    comando.Parameters.AddWithValue("@Importe", p.Importe);
                    comando.Parameters.AddWithValue("@Categoria", p.Categoria);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
