using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public long Numero { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set;}
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool CestaBasica { get; set; }
        public List<TratamentoPaciente> TratamentoPacientes { get; set; }

        public static void ConfiguraModelo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>(etd =>
            {
                etd.HasKey(c => c.Id);
                etd.Property(c => c.Id).ValueGeneratedOnAdd();
                etd.Property(c => c.Nome).HasMaxLength(100).IsRequired();
                etd.Property(c => c.StatusCivil).HasMaxLength(15).IsRequired();
                etd.Property(c => c.Naturalidade).HasMaxLength(40).IsRequired();
                etd.Property(c => c.DataNascimento).HasColumnType("datetime").IsRequired();
                etd.Property(c => c.SUSNumero).HasMaxLength(15).IsRequired();
                etd.Property(c => c.CPF).HasMaxLength(15).IsRequired();
                etd.Property(c => c.Numero).IsRequired();
                etd.Property(c => c.Bairro).HasMaxLength(80).IsRequired();
                etd.Property(c => c.UF).HasMaxLength(2).IsRequired();
                etd.Property(c => c.Cep).HasMaxLength(8).IsRequired();
                etd.Property(c => c.Logradouro).HasMaxLength(8);
                etd.Property(c => c.Complemento).HasMaxLength(8);
                etd.Property(c => c.Cidade).HasMaxLength(40);
                etd.Property(c => c.DataCriacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.Property(c => c.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                //fazer o relacioanmento
                etd.HasOne(c => c.Usuario).WithMany(u => u.Pacientes).HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Paciente>().ToTable("Pacientes");
        }
    }
}