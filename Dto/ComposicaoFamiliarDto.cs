namespace api_aapcmr.Dto
{
    public class ComposicaoFamiliarDto
    {
        public long Id { get; set; }
        public string NomeFamiliar { get; set; }
        public int IdadeFamiliar { get; set; }
        public string VinculoFamiliar { get; set; }
        public float Renda { get; set; }
        public long PacienteId { get; set; }
    }
}