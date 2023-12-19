using api_aapcmr.Repository;
using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Config
{
    public class ApiContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<AcoesApoio> AcoesApoios { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Usuario.ConfiguraModelo(modelBuilder);
            PerfilUsuario.ConfiguraModelo(modelBuilder);
            Paciente.ConfiguraModelo(modelBuilder);
            AcoesApoio.ConfiguraModelo(modelBuilder);
        }
    }
}