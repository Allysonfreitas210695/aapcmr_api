using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Repository
{
    public class RelatorioMensal
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public double Entrada { get; set; }
        public double Saida { get; set; }
        public double Saldo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public long TipoGastoId { get; set; }
        public TipoGasto TipoGasto { get; set; }

        public static void ConfiguraModelo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RelatorioMensal>(etd =>
            {
                etd.HasKey(c => c.Id);
                etd.Property(c => c.Id).ValueGeneratedOnAdd();
                etd.Property(c => c.Data).HasColumnType("datetime").IsRequired();
                etd.Property(c => c.DataCriacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.Property(c => c.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                etd.HasOne(c => c.TipoGasto).WithMany(c => c.RelatorioMensais).HasForeignKey(c => c.TipoGastoId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<RelatorioMensal>().ToTable("RelatorioMensais");
        }
    }
}