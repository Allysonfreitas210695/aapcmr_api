using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Dto;
using api_aapcmr.Repository;

namespace api_aapcmr.Interfaces
{
    public interface IPerfilPacienteService
    {
        
        Task<PerfilPaciente> GetItemPerfilPaciente(long id);
        Task<List<PerfilPaciente>> GetListPerfilPacientes();
        Task UpdatePerfilPaciente(PerfilPacienteDto model);
        Task<PerfilPaciente> InsertPerfilPaciente(PerfilPacienteDto model);
        Task DeletePerfilPaciente(long id);
    }
}