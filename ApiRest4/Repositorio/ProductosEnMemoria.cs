using ApiRest4.Modelo;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace ApiRest4.Repositorio
{
    public class ProductosEnMemoria: IProductosEnMemoria
    {

        private readonly List<Producto> productos = new()
        {
            new Producto{ Id = 1, Nombre = "Martillo", Descripcion = "Martillo super preciso", Precio = 12.99, FechaAlta = DateTime.Now, SKU = "MART01"},
            new Producto{ Id = 2, Nombre = "Destornillador", Descripcion = "Destornillador de estrella", Precio = 8.49, FechaAlta = DateTime.Now, SKU = "DEST01" },
            new Producto{ Id = 3, Nombre = "Llave Inglesa", Descripcion = "Llave inglesa ajustable", Precio = 15.75, FechaAlta = DateTime.Now, SKU = "LLAVIN01"},
            new Producto{ Id = 4, Nombre = "Taladro", Descripcion = "Taladro electrico potente", Precio = 45.00, FechaAlta = DateTime.Now, SKU = "TALA01"},
        };

        public IEnumerable<Producto> DameProductos()
        {
            return productos;
        }

        public Producto DameProducto(string SKU)
        {
            return productos.Where(p => p.SKU == SKU).SingleOrDefault();
        }

        public void CrearProducto(Producto p)
        {
            productos.Add(p);
        }

        public void ModificarProducto(Producto p)
        {
            int indice = productos.FindIndex(existeProducto => existeProducto.Id == p.Id);
            productos[indice] = p;
        }

        public void BorrarProducto(string SKU)
        {
            int indice = productos.FindIndex(existeProducto => existeProducto.SKU == SKU);
            productos.RemoveAt(indice);
        }
    }
}
