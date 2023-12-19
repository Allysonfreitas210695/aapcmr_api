using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_aapcmr.Dto
{
    public class PacienteDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string StatusCivil { get; set; }
        public string Naturalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Cidade { get; set; }
        public long Numero { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public long UsuarioId { get; set; }
    }

     public class PacienteListDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string StatusCivil { get; set; }
        public string Naturalidade { get; set; }
        public string DataNascimento { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
    }
}