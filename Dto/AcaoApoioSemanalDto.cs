using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_aapcmr.Dto
{
    public class AcaoApoioSemanalDto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public long AcoesApoioId { get; set; }
    }
}