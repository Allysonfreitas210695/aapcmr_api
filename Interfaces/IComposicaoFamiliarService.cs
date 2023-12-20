using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Dto;
using api_aapcmr.Repository;

namespace api_aapcmr.Interfaces
{
    public interface IComposicaoFamiliarService
    {
        Task<ComposicaoFamiliar> GetItemComposicaoFamiliar(long id);
        Task<List<ComposicaoFamiliar>> GetListComposicaoFamiliares();
        Task UpdateComposicaoFamiliar(ComposicaoFamiliarDto model);
        Task<ComposicaoFamiliar> InsertComposicaoFamiliar(ComposicaoFamiliarDto model);
        Task DeleteComposicaoFamiliar(long id);
    }
}