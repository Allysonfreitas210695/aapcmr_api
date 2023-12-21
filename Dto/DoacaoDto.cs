namespace api_aapcmr.Dto
{
    public class DoacaoDto
    {
        public long Id { get; set; }
        public string NomeDoador { get; set; }
        public string Telefone { get; set; }
        public float ValorDoacao { get; set; }
        public DateTime DataDoacao { get; set; }
        public long Numero { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string TipoDeEnvioValor { get; set; }
        public bool StatusDoacao { get; set; }
    }
}