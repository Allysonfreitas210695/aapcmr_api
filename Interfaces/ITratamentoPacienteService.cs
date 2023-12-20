using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Dto;
using api_aapcmr.Repository;

namespace api_aapcmr.Interfaces
{
    public interface ITratamentoPacienteService
    {
        Task<TratamentoPaciente> GetItemTratamentoPaciente(long id);
        Task<List<TratamentoPacienteDto>> GetListTratamentoPacientes();
        Task UpdateTratamentoPaciente(TratamentoPacienteDto model);
        Task<TratamentoPaciente> InsertTratamentoPaciente(TratamentoPacienteDto model);
        Task DeleteTratamentoPaciente(long id);
    }
}