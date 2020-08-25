using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Semicrol.Curso.Dominio;
using Semicrol.Curso.Filtros;
using Semicrol.Curso.Interfaces;

namespace Semicrol.Curso.PersistenciaADO
{
    public class FacturaRepository : IFacturaRepository
    {
        public void Insertar(Factura f)
        {
            using (SqlConnection conexion = GestionConexion.GetConexion())
            {
                conexion.Open();
                String sql = "insert into Facturas values(@Numero ,@Concepto)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", f.Numero);
                comando.Parameters.AddWithValue("@Concepto", f.Concepto);
                comando.ExecuteNonQuery();
            }
        }

        public void Borrar(Factura f)
        {
            using (SqlConnection conexion = GestionConexion.GetConexion())
            {
                conexion.Open();
                String sql = "delete from Facturas where numero = @Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", f.Numero);
                comando.ExecuteNonQuery();
            }
        }

        public List<Factura> BuscarTodos()
        {
            List<Factura> listaFacturas = new List<Factura>();
            using (SqlConnection conexion = GestionConexion.GetConexion())
            {
                conexion.Open();
                String sql = "select * from Facturas";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    listaFacturas.Add(new Factura(Convert.ToInt32(lector["numero"]), Convert.ToString(lector["concepto"])));
                }
            }
            return listaFacturas;
        }

        public List<Factura> BuscarTodosConLineas()
        {
            List<Factura> listaFacturas = new List<Factura>();
            using (SqlConnection conexion = GestionConexion.GetConexion())
            {
                conexion.Open();
                String sql = "select Facturas.numero as facturaNumero,LineasFactura.numero as lineaNumero, concepto, productos_id,unidades from Facturas inner join LineasFactura on Facturas.numero = LineasFactura.facturas_numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                Factura f = new Factura(0);

                while (lector.Read())
                {
                    Factura aux = new Factura(Convert.ToInt32(lector["facturaNumero"]));
                    if(f.Numero != aux.Numero)
                    {
                        if (!listaFacturas.Contains(aux))
                        {

                            f = new Factura(Convert.ToInt32(lector["facturaNumero"]),
                                Convert.ToString(lector["concepto"]));
                            listaFacturas.Add(f);
                        }
                        else
                        {
                            f = listaFacturas[listaFacturas.IndexOf(aux)];
                        }
                    }
                    f.AddLineaFactura(new LineaFactura(
                            Convert.ToInt32(lector["lineaNumero"]),
                            f,
                            lector["productos_id"].ToString(),
                            Convert.ToInt32(lector["unidades"])));
                }
            }
            return listaFacturas;
        }

        public Factura BuscarUno(int numFactura)
        {
            Factura f1 = null;
            using (SqlConnection conexion = GestionConexion.GetConexion())
            {
                conexion.Open();
                String sql = "select * from Facturas where numero= @numeroFactura";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@numeroFactura", numFactura);
                SqlDataReader lector = comando.ExecuteReader();
                if (!lector.Read())
                {
                    throw new Exception("No se ha encontrado la factura");
                }
                f1 = new Factura(Convert.ToInt32(lector["numero"]), Convert.ToString(lector["concepto"]));
            }
            return f1;
        }

        public List<Factura> BuscarTodos(FiltroFactura filtro)
        {
            List<Factura> listaFacturas = new List<Factura>();
            using (SqlConnection conexion = GestionConexion.GetConexion())
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
               String sql = "select * from Facturas";
                if (filtro.Numero != 0)
                {
                    sql += " where Numero = @Numero";
                    comando.Parameters.AddWithValue("@Numero", filtro.Numero);
                    if (filtro.Concepto != null)
                    {
                        sql += " and Concepto = @Concepto";
                        comando.Parameters.AddWithValue("@Concepto", filtro.Concepto);
                    }
                }
                else if (filtro.Concepto != null)
                {
                    sql += " where Concepto = @Concepto";
                    comando.Parameters.AddWithValue("@Concepto", filtro.Concepto);
                }

                comando.Connection = conexion;
                comando.CommandText = sql;

                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    listaFacturas.Add(new Factura(Convert.ToInt32(lector["numero"]), Convert.ToString(lector["concepto"])));
                }
            }
            return listaFacturas;
        }

        public void Actualizar(Factura f)
        {
            using (SqlConnection conexion = GestionConexion.GetConexion())
            {
                conexion.Open();
                String sql = "update Facturas set concepto = @Concepto where numero = @Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", f.Numero);
                comando.Parameters.AddWithValue("@Concepto", f.Concepto);
                comando.ExecuteNonQuery();
            }
        }



    }
}
