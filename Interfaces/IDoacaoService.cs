using api_aapcmr.Dto;
using api_aapcmr.Repository;

namespace api_aapcmr.Interfaces
{
    public interface IDoacaoService
    {
        Task<Doacao> GetItemDoacao(long id);
        Task<List<Doacao>> GetListDoacaos();
        Task UpdateDoacao(long doacaoId, bool StatusDoacao);
        Task UpdateItemDoacao(DoacaoDto model);
        Task<Doacao> InsertDoacao(DoacaoDto model);
        Task DeleteDoacao(long doacaoId);
    }
}