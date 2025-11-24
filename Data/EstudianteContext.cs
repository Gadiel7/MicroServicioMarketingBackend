using Microsoft.EntityFrameworkCore;
using MicroServicioMarketingBackend.Modelo;

namespace MicroServicioMarketingBackend.Data
{
    public class EstudianteContext : DbContext
    {
        public EstudianteContext(DbContextOptions<EstudianteContext> options) : base(options) { }
        public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
    }
}
