using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Dto;
using api_aapcmr.Repository;

namespace api_aapcmr.Interfaces
{
    public interface IAcaoApoioSemanalService
    {
        Task<AcaoApoioSemanal> GetItemAcaoApoioSemanal(long id);
        Task<List<AcaoApoioSemanal>> GetListAcaoApoioSemanals();
        Task UpdateAcaoApoioSemanal(AcaoApoioSemanalDto model);
        Task<AcaoApoioSemanal> InsertAcaoApoioSemanal(AcaoApoioSemanalDto model);
        Task DeleteAcaoApoioSemanal(long id);
    }
}