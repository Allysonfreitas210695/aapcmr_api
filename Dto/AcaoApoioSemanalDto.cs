namespace api_aapcmr.Dto
{
    public class AcaoApoioSemanalDto
    {
        public long Id { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public long AcoesApoioId { get; set; }
    }
}