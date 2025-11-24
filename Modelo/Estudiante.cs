namespace MicroServicioMarketingBackend.Modelo
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
    }
}
