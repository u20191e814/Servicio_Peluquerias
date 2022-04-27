namespace Servicio_Peluquerias.Entidades.mostrarEspecialistas
{
    public class structure_output_especialistas
    {
        public string status { get; set; }
        public List<Especialistas> data { get; set; }
        public string statusMessage { get; set; }
    }

    public class Especialistas
    {
        public int Pk_especialistas { get; set; }
        public string  Nombre { get; set; }
        public string Direccion { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }    
        public int Calificacion { get; set; }
        public int Fk_categoria { get; set; }
        public string imagenBase64 { get; set; }
        public int Fk_distrito { get; set; }

    }
}
