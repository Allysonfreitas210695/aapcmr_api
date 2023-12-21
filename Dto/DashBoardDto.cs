using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Repository;

namespace api_aapcmr.Dto
{
    public class FiltroDashBoardDto
    {
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
    }

    public class DashBoardDto
    {
        public float ValorTotalDoacao { get; set; }
        public float ValorTotalDesposito { get; set; }
        public float ValorTotalMessageiro { get; set; }
        public List<DoacaoListDto> DoacoesPendenteDtos { get; set; }
        public List<DoacaoListDto> DoacoesRecebidasDtos { get; set; }
        public List<Paciente> PacientesInativosDtos { get; set; }
        public List<Paciente> PacientesAtivoDtos { get; set; }
    }

    public class DoacaoListDto
    {
        public long Id { get; set; }
        public string NomeDoador { get; set; }
        public string Telefone { get; set; }
        public float ValorDoacao { get; set; }
        public string DataDoacao { get; set; }
        public string Endereco { get; set; }
        public string TipoDeEnvioValor { get; set; }
        public string StatusDoacao { get; set; }
    }
}