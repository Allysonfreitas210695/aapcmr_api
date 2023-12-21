using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Repository
{
    public class AcaoApoioSemanal
    {
         public long Id { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public long AcoesApoioId { get; set; }
        public AcoesApoio AcoesApoio { get; set; }

        public static void ConfiguraModelo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcaoApoioSemanal>(etd =>
            {
                etd.HasKey(c => c.Id);
                etd.Property(c => c.Id).ValueGeneratedOnAdd();
                etd.Property(c => c.DataInicial).HasColumnType("datetime");
                etd.Property(c => c.DataFinal).HasColumnType("datetime");
                etd.Property(c => c.DataCriacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.Property(c => c.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.HasOne(c => c.AcoesApoio).WithMany(u => u.AcaoApoioSemanais).HasForeignKey(x => x.AcoesApoioId).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<AcaoApoioSemanal>().ToTable("AcaoApoioSemanais");
        }
    }
}