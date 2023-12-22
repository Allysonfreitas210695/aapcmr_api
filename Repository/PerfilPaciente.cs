using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Repository
{
    public class PerfilPaciente
    {
        public long Id { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string Religiao { get; set; }
        public string Profissao { get; set; }
        public bool ProgramaGoverno { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public long PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public static void ConfiguraModelo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerfilPaciente>(etd =>
            {
                etd.HasKey(c => c.Id);
                etd.Property(c => c.Id).ValueGeneratedOnAdd();
                etd.Property(c => c.NomePai).HasMaxLength(100).IsRequired();
                etd.Property(c => c.NomeMae).HasMaxLength(15).IsRequired();
                etd.Property(c => c.Religiao).HasMaxLength(30).IsRequired();
                etd.Property(c => c.Profissao).HasMaxLength(40).IsRequired();
                etd.Property(c => c.DataCriacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.Property(c => c.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<PerfilPaciente>().ToTable("PerfilPacientes");
        }
    }
}