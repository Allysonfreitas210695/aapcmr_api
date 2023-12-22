using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_aapcmr.Dto
{
    public class PerfilPacienteDto
    {
        public long Id { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string Religiao { get; set; }
        public string Profissiao { get; set; }
        public bool ProgramaGoverno { get; set; }
        public long PacienteId { get; set; }
    }
}