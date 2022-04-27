namespace Servicio_Peluquerias.Entidades.mostrarEspecialistas
{
    public class structure_output_mostrarEspecialistas
    {
        public string status { get; set; }
        public List<ubicacion> data { get; set; }
        public string statusMessage { get; set; }
    }

    public class ubicacion
    {
        public int id { get; set; }
        public string  nombre { get; set; }
    }
}
