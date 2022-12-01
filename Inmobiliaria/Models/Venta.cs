using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Inmobiliaria.Models
{
    public class Venta
    {
        [Key]
        public int id_venta { get; set; }
        [ForeignKey("inmueble")]
        public int id_inmueble { get; set; }
        [JsonIgnore]
        public Inmueble? inmueble { get; set; }
        [ForeignKey("cliente")]
        public int id_cliente { get; set; }
        [JsonIgnore]
        public Cliente? cliente { get; set; }
        [ForeignKey("condicion")]
        public int id_condicion { get; set; }
        [JsonIgnore]
        public Condicion? condicion { get; set; }
        [ForeignKey("formaPago")]
        public int id_forma_pago { get; set; }
        [JsonIgnore]
        public FormaPago? formaPago { get; set; }
        [Required]
        [StringLength(255)]
        public string? desc_venta { get; set; }
        public float total_venta { get; set; }
        public float total_iva { get; set; }
        public float total_general { get; set; }
        public DateTime fecha_venta { get; set; }


    }
}
