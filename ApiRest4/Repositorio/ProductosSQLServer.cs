using ApiRest4.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ApiRest4.Repositorio;

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

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al dar de alta" + ex.ToString());
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
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
