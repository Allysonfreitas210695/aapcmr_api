using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Repository
{
    public class SituacaoHabitacional
    {
        public long Id { get; set; }
  
        public string Transporte { get; set; }
        public string Moradia { get; set; }
        public string Casa { get; set; }
        public long Numero { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public long PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public static void ConfiguraModelo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SituacaoHabitacional>(etd =>
            {
                etd.HasKey(c => c.Id);
                etd.Property(c => c.Id).ValueGeneratedOnAdd();
                etd.Property(c => c.Transporte).HasMaxLength(50).IsRequired();
                etd.Property(c => c.Casa).HasMaxLength(50).IsRequired();
                etd.Property(c => c.Moradia).HasMaxLength(50).IsRequired();
                etd.Property(c => c.Numero).IsRequired();
                etd.Property(c => c.Bairro).HasMaxLength(80).IsRequired();
                etd.Property(c => c.UF).HasMaxLength(2).IsRequired();
                etd.Property(c => c.Cep).HasMaxLength(8).IsRequired();
                etd.Property(c => c.Logradouro).HasMaxLength(8);
                etd.Property(c => c.Complemento).HasMaxLength(8);
                etd.Property(c => c.Cidade).HasMaxLength(40);
                etd.Property(c => c.DataCriacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.Property(c => c.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<SituacaoHabitacional>().ToTable("SituacaoHabitacionais");
        }
    }
}