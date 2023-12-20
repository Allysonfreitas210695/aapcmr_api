using api_aapcmr.Dto;
using api_aapcmr.Repository;

namespace api_aapcmr.Interfaces
{
    public interface IPacienteService
    {
        Task<Paciente> GetItemPaciente(long id);
        Task<List<PacienteListDto>> GetListPacientes();
        Task<List<PacienteListDto>> ConsultaPacientes(FiltroConsultaPacienteDto filtro);
        Task UpdatePaciente(PacienteDto model);
        Task<Paciente> InsertPaciente(PacienteDto model);
        Task DeletePaciente(long id);
    }
}