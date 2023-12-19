using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Dto;
using api_aapcmr.Repository;

namespace api_aapcmr.Interfaces
{
    public interface IAcoesApoioService
    {
        Task<AcoesApoio> GetItemAcoesApoio(long id);
        Task<List<AcoesApoio>> GetListAcoesApoios();
        Task UpdateAcoesApoio(AcoesApoioDto model);
        Task<AcoesApoio> InsertAcoesApoio(AcoesApoioDto model);
        Task DeleteAcoesApoio(long id);
    }
}