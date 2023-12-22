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
        Task<List<RelatorioMensal>> FiltroRelatorioMovimentacao(RelatorioMovimentacaoFiltroDto filtro);
        Task<List<Doacao>> FiltroRelatorioDoacoes(RelatorioDoacaoFiltroDto filtro);
        Task<List<Doacao>> FiltroRelatorioDoacaoDeposito(RelatorioDoacaoFiltroDto filtro);
        Task<List<Doacao>> FiltroRelatorioDoacaoMessageiro(RelatorioDoacaoFiltroDto filtro);
    }
}