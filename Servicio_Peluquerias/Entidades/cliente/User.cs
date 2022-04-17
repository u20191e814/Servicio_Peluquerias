using System.ComponentModel.DataAnnotations;

namespace Servicio_Peluquerias.Entidades
{
    public class User
    {
        [Required]
        public string correo { get; set; }
        [Required]
        public string clave { get; set; }
    }
}
