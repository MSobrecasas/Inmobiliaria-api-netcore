using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class FormaPago
    {
        [Key]
        public int id_forma_pago { get; set; }
        [Required]
        [StringLength(100)]
        public string? desc_forma_Pago { get; set; }

    }
}
