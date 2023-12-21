namespace api_aapcmr.Dto
{
    public class PacienteDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string StatusCivil { get; set; }
        public string Naturalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public string SUSNumero { get; set; }
        public string Sexo { get; set; }
        public bool Status { get; set; }
        public string CPF { get; set; }
        public long UsuarioId { get; set; }
        public bool CestaBasica { get; set; }
    }

    public class PacienteListDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string StatusCivil { get; set; }
        public string Naturalidade { get; set; }
        public string DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public string Status { get; set; }
        public string Endereco { get; set; }
        public string CestaBasica { get; set; }
    }

    public class FiltroConsultaPacienteDto
    {
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string SUSNumero { get; set; }
        public string CPF { get; set; }
        public bool CestaBasica { get; set; }
    }
}