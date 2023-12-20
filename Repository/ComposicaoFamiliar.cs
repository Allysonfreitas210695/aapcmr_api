using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Repository
{
    public class ComposicaoFamiliar
    {
        public long Id { get; set; }
        public string NomeFamiliar { get; set; }
        public int IdadeFamiliar { get; set; }
        public string VinculoFamiliar { get; set; }
        public float Renda { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public long PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public static void ConfiguraModelo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComposicaoFamiliar>(etd =>
            {
                etd.HasKey(c => c.Id);
                etd.Property(c => c.Id).ValueGeneratedOnAdd();
                etd.Property(c => c.NomeFamiliar).HasMaxLength(100).IsRequired();
                etd.Property(c => c.IdadeFamiliar).IsRequired();
                etd.Property(c => c.VinculoFamiliar).HasMaxLength(40).IsRequired();
                etd.Property(c => c.Renda).IsRequired();
                etd.Property(c => c.DataCriacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.Property(c => c.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.HasOne(c => c.Paciente).WithMany(c => c.ComposicaoFamiliares).HasForeignKey(c => c.PacienteId).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<ComposicaoFamiliar>().ToTable("ComposicaoFamilias");
        }
    }
}