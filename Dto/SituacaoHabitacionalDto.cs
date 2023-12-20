using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_aapcmr.Dto
{
    public class SituacaoHabitacionalDto
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
        public long PacienteId { get; set; }
    }
}