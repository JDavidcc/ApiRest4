using ApiRest4.DTO;
using ApiRest4.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest4
{
    public static class Utilidades
    {
        public static ProductoDTO convertirDTO(this Producto p)
        {
            if (p != null)
            {
                return new ProductoDTO
                {
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    SKU = p.SKU,

                };
            }

            return null;
        }
    }
}
