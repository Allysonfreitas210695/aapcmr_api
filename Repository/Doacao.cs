using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Repository
{
    public class Doacao
    {
        public long Id { get; set; }
        public string NomeDoador { get; set; }
        public string Telefone { get; set; }
        public float ValorDoacao { get; set; }
        public DateTime DataDoacao { get; set; }
        public long Numero { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string TipoDeEnvioValor { get; set; }
        public bool StatusDoacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public static void ConfiguraModelo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doacao>(etd =>
            {
                etd.HasKey(c => c.Id);
                etd.Property(c => c.Id).ValueGeneratedOnAdd();
                etd.Property(c => c.NomeDoador).HasMaxLength(80).IsRequired();
                etd.Property(c => c.Telefone).IsRequired();
                etd.Property(c => c.ValorDoacao).IsRequired();
                etd.Property(c => c.DataDoacao).HasColumnType("datetime").IsRequired();
                etd.Property(c => c.Numero).IsRequired();
                etd.Property(c => c.Bairro).HasMaxLength(80).IsRequired();
                etd.Property(c => c.UF).HasMaxLength(2).IsRequired();
                etd.Property(c => c.Cep).HasMaxLength(8).IsRequired();
                etd.Property(c => c.Logradouro).HasMaxLength(120);
                etd.Property(c => c.Complemento).HasMaxLength(120);
                etd.Property(c => c.Cidade).HasMaxLength(40).IsRequired();
                etd.Property(c => c.TipoDeEnvioValor).IsRequired();
                etd.Property(c => c.StatusDoacao).IsRequired();
                etd.Property(c => c.DataCriacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.Property(c => c.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Doacao>().ToTable("Doacoes");
        }
    }
}