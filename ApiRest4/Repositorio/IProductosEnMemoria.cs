using ApiRest4.Modelo;
using Microsoft.Extensions.Hosting;
using System.Collections;
using System.Collections.Generic;

namespace ApiRest4.Repositorio
{
    public interface IProductosEnMemoria
    {
        Producto DameProducto(string SKU);
        IEnumerable<Producto> DameProductos();

        void CrearProducto(Producto p);

        void ModificarProducto(Producto p);

        void BorrarProducto(string SKU);
    }
}
