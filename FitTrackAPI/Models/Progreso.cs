namespace FitTrackAPI.Models
{
    public class Progreso
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public double PesoActual { get; set; }
        public double IMC { get; set; }
        public string Observaciones { get; set; }
    }
}
