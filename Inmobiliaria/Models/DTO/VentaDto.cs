using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models.DTO
{
    public class VentaDto
    {
        public int id_venta { get; set; }
        public int id_inmueble { get; set; }
        public int id_cliente { get; set; }
        public int id_condicion { get; set; }
        public int id_forma_pago { get; set; }
        public string? desc_venta { get; set; }
        public float total_venta { get; set; }
        public float total_iva { get; set; }
        public float total_general { get; set; }
        public DateTime fecha_venta { get; set; }
    }
}
