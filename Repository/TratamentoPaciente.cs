using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Repository
{
    public class TratamentoPaciente
    {
        public long Id { get; set; }
        public string Diagnostico { get; set; }
        public string StatusTratamento { get; set; }
        public string Medico { get; set; }
        public string TipoCirurgia { get; set; }
        public long AnoDiagnostico { get; set; }
        public string HospitalTratamento { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataObservacao { get; set; }
        public bool HistoricoFamiliaCancer { get; set; }
        public bool  UsoEntorpecente { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public long PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public static void ConfiguraModelo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TratamentoPaciente>(etd =>
            {
                etd.HasKey(c => c.Id);
                etd.Property(c => c.Id).ValueGeneratedOnAdd();
                etd.Property(c => c.Diagnostico).HasMaxLength(50).IsRequired();
                etd.Property(c => c.Medico).HasMaxLength(60).IsRequired();
                etd.Property(c => c.StatusTratamento).HasMaxLength(50).IsRequired();
                etd.Property(c => c.AnoDiagnostico).IsRequired();
                etd.Property(c => c.HospitalTratamento).HasMaxLength(120).IsRequired();
                etd.Property(c => c.Observacao).HasMaxLength(250);
                etd.Property(c => c.DataObservacao).HasColumnType("datetime");
                etd.Property(c => c.DataCriacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.Property(c => c.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.HasOne(c => c.Paciente).WithMany(c => c.TratamentoPacientes).HasForeignKey(c => c.PacienteId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TratamentoPaciente>().ToTable("TratamentoPacientes");
        }
    }
}