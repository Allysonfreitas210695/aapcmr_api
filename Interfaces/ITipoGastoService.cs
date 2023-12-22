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
        Task<TipoGasto> GetItemTipoGasto(long id);
        Task<List<TipoGasto>> GetListTipoGastos();
        Task UpdateTipoGasto(TipoGastoDto model);
        Task<TipoGasto> InsertTipoGasto(TipoGastoDto model);
        Task DeleteTipoGasto(long id);
    }
}