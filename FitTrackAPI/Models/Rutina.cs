namespace FitTrackAPI.Models
{
    public class Rutina
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
