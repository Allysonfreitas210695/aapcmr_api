using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Repository
{
    public class Paciente
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string StatusCivil { get; set; }
        public string Naturalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public string SUSNumero { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public bool Status { get; set; }
        public string TelefoneFixo { get; set; }
        public string Celular { get; set; }
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool CestaBasica { get; set; }
        public List<TratamentoPaciente> TratamentoPacientes { get; set; }
        public long? SituacaoHabitacionalId { get; set; }
        public SituacaoHabitacional SituacaoHabitacional { get; set; }
        public List<ComposicaoFamiliar> ComposicaoFamiliares { get; set; }

        public static void ConfiguraModelo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>(etd =>
            {
                etd.HasKey(c => c.Id);
                etd.Property(c => c.Id).ValueGeneratedOnAdd();
                etd.Property(c => c.Nome).HasMaxLength(100).IsRequired();
                etd.Property(c => c.Sexo).HasMaxLength(15).IsRequired();
                etd.Property(c => c.StatusCivil).HasMaxLength(15).IsRequired();
                etd.Property(c => c.Naturalidade).HasMaxLength(40).IsRequired();
                etd.Property(c => c.DataNascimento).HasColumnType("datetime").IsRequired();
                etd.Property(c => c.SUSNumero).HasMaxLength(15).IsRequired();
                etd.Property(c => c.CPF).HasMaxLength(15).IsRequired();
                etd.Property(c => c.TelefoneFixo).HasMaxLength(15);
                etd.Property(c => c.Celular).HasMaxLength(15);
                etd.Property(c => c.DataCriacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.Property(c => c.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.HasOne(c => c.Usuario).WithMany(u => u.Pacientes).HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.SetNull);
                etd.HasOne(c => c.SituacaoHabitacional).WithOne(sh => sh.Paciente).HasForeignKey<Paciente>(c => c.SituacaoHabitacionalId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Paciente>().ToTable("Pacientes");
        }
    }
}