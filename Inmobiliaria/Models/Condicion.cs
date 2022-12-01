using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Condicion
    {
        [Key]
        public int id_condicion { get; set; }
        [Required]
        [StringLength(100)]
        public string? des_condicion { get;  set; }


    }
}
