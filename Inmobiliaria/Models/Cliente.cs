using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Cliente
    {
        [Key]
        public int id_cliente { get; set; }
        [Required]
        [StringLength(50)]
        public string? nombre_cliente { get; set; }
        [Required]
        [StringLength(255)]
        public string? dir_cliente { get; set; }
        [Required]
        [StringLength(50)]
        public string? correo_cliente { get; set; }
        public long telefono_cliente { get; set; }


    }
}
