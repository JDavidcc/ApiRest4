using ApiRest4.Modelo;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
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
            Console.WriteLine("=== INICIO CrearProducto ===");
            Console.WriteLine($"CadenaConexion: {CadenaConexion}");

            SqlConnection sqlConexion = conexion();
            Console.WriteLine($"sqlConexion == null ? {sqlConexion == null}");

            SqlCommand Comm = null;

            try
            {
                Console.WriteLine("Intentando abrir la conexión...");
                sqlConexion.Open();
                Console.WriteLine("Conexión abierta correctamente.");

                Console.WriteLine("Creando comando...");
                Comm = sqlConexion.CreateCommand();
                Console.WriteLine("Comando creado correctamente.");

                Comm.CommandText = "dbo.ProductosAlta";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@Nombre", SqlDbType.VarChar, 500).Value = p.Nombre;
                Comm.Parameters.Add("@Descripcion", SqlDbType.VarChar, 5000).Value = p.Descripcion;
                Comm.Parameters.Add("@Precio", SqlDbType.Float).Value = p.Precio;
                Comm.Parameters.Add("@SKU", SqlDbType.VarChar, 100).Value = p.SKU;

                Console.WriteLine("Ejecutando procedimiento almacenado...");
                Comm.ExecuteNonQuery();

                Console.WriteLine("Procedimiento ejecutado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ ERROR: " + ex);
                throw;
            }
            finally
            {
                Comm?.Dispose();
                sqlConexion?.Close();
                sqlConexion?.Dispose();
                Console.WriteLine("=== FIN CrearProducto ===");
            }
        }

        public Producto DameProducto(string SKU)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> DameProductos()
        {
            throw new NotImplementedException();
        }

        public void ModificarProducto(Producto p)
        {
            throw new NotImplementedException();
        }
    }
}
