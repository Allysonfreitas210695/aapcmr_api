using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_aapcmr.Dto
{
    public class RelatorioMensalDto
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public double Entrada { get; set; }
        public double Saida { get; set; }
        public double? Saldo { get; set; }
        public string DescricaoTipoGasto { get; set; }
        public long TipoGastoId { get; set; }
    }

     public class RelatorioMensalFiltroDto
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }

    public class RelatorioMensalExcelDto
    {
        public double TotalEntrada { get; set; }
        public double TotalSaida { get; set; }
        public double? TotalSaldo { get; set; }
        public List<RelatorioMensalDto> RelatorioMensalDtos { get; set; }
    }
}