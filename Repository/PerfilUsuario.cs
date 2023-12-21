using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Repository
{
    public class PerfilUsuario
    {
        public long Id { get; set; }
        public string Perfil { get; set; }
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public static void ConfiguraModelo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerfilUsuario>(etd =>
            {
                etd.HasKey(c => c.Id);
                etd.Property(c => c.Id).ValueGeneratedOnAdd();
                etd.Property(c => c.Perfil).HasMaxLength(15).IsRequired();
                etd.HasOne(pu => pu.Usuario).WithOne(u => u.PerfilUsuario).HasForeignKey<PerfilUsuario>(pu => pu.UsuarioId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<PerfilUsuario>().ToTable("PerfilUsuarios");
        }
    }
}