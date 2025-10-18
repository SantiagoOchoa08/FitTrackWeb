namespace FitTrackAPI.Models
{
    public class Ejercicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string GrupoMuscular { get; set; }
        public string Descripcion { get; set; }
        public int DuracionSegundos { get; set; }
        public int CaloriasEstimadas { get; set; }
    }
}
