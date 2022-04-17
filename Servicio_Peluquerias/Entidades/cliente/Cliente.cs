using System.ComponentModel.DataAnnotations;

namespace Servicio_Peluquerias.Entidades
{
    public class Cliente
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string telefono { get; set; }
        [Required]
        public string Clave { get; set; }
    }
}
