using ApiRest4.DTO;
using ApiRest4.Modelo;
using ApiRest4.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ApiRest4.Controllers
{
    [Route("productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosEnMemoria repositorio;
        public ProductosController(IProductosEnMemoria r)
        {
            this.repositorio = r;
        }
        
        [HttpGet]
        public IEnumerable<ProductoDTO> DameProductos()
        {
            var listaProductos = repositorio.DameProductos().Select(p=>p.convertirDTO());
            return listaProductos;
        }
        [HttpGet("{codProducto}")]
        public ActionResult<ProductoDTO> DameProducto(string codProducto)
        {
            var producto = repositorio.DameProducto(codProducto).convertirDTO();
            if (producto is null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPost]
        public ActionResult<ProductoDTO> CrearProducto(ProductoDTO p)
        {
            Producto producto = new Producto
            {
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                SKU = p.SKU,
                FechaAlta = DateTime.Now
            };
            repositorio.CrearProducto(producto);

            return producto.convertirDTO();
        }

        [HttpPut]
        public ActionResult<ProductoDTO> ModificarProducto(String codProducto, ProductoActualizarDTO p)
        {
            Producto existeProducto = repositorio.DameProducto(codProducto);
            if (existeProducto == null)
            {
                return NotFound();
            }
            existeProducto.Nombre = p.Nombre;
            existeProducto.Descripcion = p.Descripcion;
            existeProducto.Precio = p.Precio;

            repositorio.ModificarProducto(existeProducto);

            return existeProducto.convertirDTO();
        }

        [HttpDelete]
        public ActionResult BorrarProducto(String codProducto)
        {
            Producto existeProducto = repositorio.DameProducto(codProducto);
            if (existeProducto is null)
            {
                return NotFound();
            }
            repositorio.BorrarProducto(codProducto);

            return NoContent();
        }
    }
}
