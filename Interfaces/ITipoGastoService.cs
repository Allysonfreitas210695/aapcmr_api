using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Dto;
using api_aapcmr.Repository;

namespace api_aapcmr.Interfaces
{
    public interface ITipoGastoService
    {
        Task<TipoGasto> GetItemMovimentacaoGasto(long id);
        Task<List<TipoGasto>> GetListMovimentacaoGastos();
        Task UpdateMovimentacaoGasto(TipoGastoDto model);
        Task<TipoGasto> InsertMovimentacaoGasto(TipoGastoDto model);
        Task DeleteMovimentacaoGasto(long id);
    }
}