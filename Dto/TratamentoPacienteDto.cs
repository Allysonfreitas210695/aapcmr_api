namespace api_aapcmr.Dto
{
    public class TratamentoPacienteDto
    {
        public long Id { get; set; }
        public string Diagnostico { get; set; }
        public string StatusTratamento { get; set; }
        public string Medico { get; set; }
        public string TipoCirurgia { get; set; }
        public long AnoDiagnostico { get; set; }
        public string HospitalTratamento { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataObservacao { get; set; }
        public long PacienteId { get; set; }
        public bool HistoricoFamiliaCancer { get; set; }
        public bool  UsoEntorpecente { get; set; }
    }
}