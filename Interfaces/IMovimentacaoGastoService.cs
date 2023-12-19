using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Dto;
using api_aapcmr.Repository;

namespace api_aapcmr.Interfaces
{
    public interface IMovimentacaoGastoService
    {
        Task<MovimentacaoGasto> GetItemMovimentacaoGasto(long id);
        Task<List<MovimentacaoGasto>> GetListMovimentacaoGastos();
        Task UpdateMovimentacaoGasto(MovimentacaoGastoDto model);
        Task<MovimentacaoGasto> InsertMovimentacaoGasto(MovimentacaoGastoDto model);
        Task DeleteMovimentacaoGasto(long id);
    }
}