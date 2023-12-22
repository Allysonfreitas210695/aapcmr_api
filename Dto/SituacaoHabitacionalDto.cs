namespace api_aapcmr.Dto
{
    public class SituacaoHabitacionalDto
    {
        public long Id { get; set; }
        public bool Transporte { get; set; }
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
        public bool Luz { get; set; }
        public bool Agua { get; set; }
        public bool InstalacaoSanitaria { get; set; }
    }
}