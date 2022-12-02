using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models.DTO
{
    public class InmuebleDto
    {
        public int id_inmueble { get; set; }
        public int id_tipo_inmueble { get; set; }
        public string? desc_inmueble { get; set; }
        public string? ubic_inmueble { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public float costo_inmueble { get; set; }
        public bool vendido { get; set; } = false;
    }
}
