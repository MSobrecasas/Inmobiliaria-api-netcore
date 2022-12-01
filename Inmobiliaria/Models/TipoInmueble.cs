using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class TipoInmueble
    {

        [Key]
        public int id_tipo_inmueble { get; set; }
        [Required]
        [StringLength(255)]
        public string? desc_inmueble { get; set; }

    }
}
