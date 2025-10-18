namespace FitTrackAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
    }
}
