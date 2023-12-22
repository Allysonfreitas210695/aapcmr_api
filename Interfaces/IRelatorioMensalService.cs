using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Dto;
using api_aapcmr.Repository;

namespace api_aapcmr.Interfaces
{
    public interface IRelatorioMensalService
    {
        Task<RelatorioMensal> GetItemRelatorioMensal(long id);
        Task<List<RelatorioMensal>> GetListRelatorioMensals();
        Task UpdateRelatorioMensal(RelatorioMensalDto model);
        Task<RelatorioMensal> InsertRelatorioMensal(RelatorioMensalDto model);
        Task DeleteRelatorioMensal(long id);
        Task<List<RelatorioMensal>> FiltroRelatorioMensal(RelatorioMensalFiltroDto filtro);
    }
}