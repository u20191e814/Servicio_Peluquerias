namespace Servicio_Peluquerias.Entidades.subCategoria
{
    public class SubCategoria
    {
        public int Pk_subCategoria { get; set; }
        public string Nombre { get; set; }
        public int Fk_categoria { get; set; }
        public float Precio { get; set; }
    }
}
