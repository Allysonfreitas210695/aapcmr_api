using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Repository;

namespace api_aapcmr.Dto
{
    public class FiltroDashBoardDto
    {
        public DateTime? DataInical { get; set; }
        public DateTime? DataFinal { get; set; }
    }

    public class DashBoardDto
    {
        public List<Doacao> DoacoesPendenteDtos { get; set; }
        public List<Doacao> DoacoesRecebidasDtos { get; set; }
        public List<Paciente> PacientesInativosDtos { get; set; }
        public List<Paciente> PacientesAtivoDtos { get; set; }
    }
}