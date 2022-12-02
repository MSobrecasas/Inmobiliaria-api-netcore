using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Inmobiliaria.Models
{
    public class Inmueble
    {
        [Key]
        public int id_inmueble { get; set; }
        [ForeignKey("tipoInmueble")]
        public int id_tipo_inmueble { get; set; }
        [JsonIgnore]
        public TipoInmueble? tipoInmueble { get; set; }
        [Required]
        [StringLength(255)]
        public string? desc_inmueble { get; set; }
        [Required]
        [StringLength(255)]
        public string? ubic_inmueble { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        [Required]
        public float costo_inmueble {get; set; }
        public bool vendido { get; set; } = false;


     
    }
}
