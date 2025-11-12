using ApiRest4.Modelo;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ApiRest4.Repositorio;
using System.Runtime.CompilerServices;
using System.Data;

namespace ApiRest4.Repositorio
{
    public class ProductosSQLServer : IProductosEnMemoria
    {
        private string CadenaConexion;
        public ProductosSQLServer(AccesoDatos cadenaConexion)
        {
            CadenaConexion = cadenaConexion.CadenaConexionSQL;
        }
        private SqlConnection conexion()
        {
            return new SqlConnection(CadenaConexion);
        }
        public void BorrarProducto(string SKU)
        {
            throw new NotImplementedException();
        }
        public void CrearProducto(Producto p)
        {
            SqlConnection sqlConexion = conexion();
            SqlCommand Comm = null;
            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.ProductosAlta";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@Nombre", SqlDbType.VarChar, 500).Value = p.Nombre;
                Comm.Parameters.Add("@Descripcion", SqlDbType.VarChar, 5000).Value = p.Descripcion;
                Comm.Parameters.Add("@Precio", SqlDbType.Float).Value = p.Precio;
                Comm.Parameters.Add("@SKU", SqlDbType.VarChar, 100).Value = p.SKU;
                Comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Comm?.Dispose();
                sqlConexion?.Close();
                sqlConexion?.Dispose();
            }
        }

        public Producto DameProducto(string SKU)
        {
            SqlConnection sqlConexion = conexion();
            SqlCommand Comm = null;
            Producto p = null;
            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.Productos_Obtener";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@SKU", SqlDbType.VarChar, 100).Value = SKU;
                SqlDataReader reader= Comm.ExecuteReader();
                if (reader.Read())
                {
                    p = new Producto
                    {
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToDouble(reader["Precio"].ToString()),
                        SKU = reader["SKU"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("=================Se produjo un error al dar de alta: " + ex);
                throw;
            }
            finally
            {
                Comm?.Dispose();
                sqlConexion?.Close();
                sqlConexion?.Dispose();
            }
            return p;
        }

        public IEnumerable<Producto> DameProductos()
        {
            SqlConnection sqlConexion = conexion();
            SqlCommand Comm = null;
            List<Producto> productos = new List<Producto>();
            Producto p = null;
            try
            {
                sqlConexion.Open();

                Comm = sqlConexion.CreateCommand();
                Console.WriteLine("Comando creado correctamente.");

                Comm.CommandText = "dbo.Productos_Obtener";
                Comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = Comm.ExecuteReader();

                while (reader.Read())
                {
                    p = new Producto
                    {
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToDouble(reader["Precio"].ToString()),
                        SKU = reader["SKU"].ToString()
                    };
                    productos.Add(p);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("=================Se produjo un error al dar de alta: " + ex);
                throw;
            }
            finally
            {
                Comm?.Dispose();
                sqlConexion?.Close();
                sqlConexion?.Dispose();
            }
            return productos;
        }

        public void ModificarProducto(Producto p)
        {
            throw new NotImplementedException();
        }
    }
}
