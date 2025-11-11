using System.ComponentModel.DataAnnotations;

namespace ApiRest4.DTO
{
    public class ProductoActualizarDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public string SKU { get; init; }
    }
}
