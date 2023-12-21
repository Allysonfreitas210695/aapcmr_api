using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Config;
using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using api_aapcmr.Repository;
using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Services
{
    public class AcoesApoioService : IAcoesApoioService
    {
        private readonly ApiContext _dbContext;

        public AcoesApoioService(ApiContext context)
        {
            _dbContext = context;
        }

        public async Task<AcoesApoio> GetItemAcoesApoio(long id)
        {
            try
            {
                return await _dbContext.AcoesApoios.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<List<AcoesApoio>> GetListAcoesApoios()
        {
            try
            {
                return await _dbContext.AcoesApoios.OrderBy(x => x.Descricao).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<AcoesApoio> InsertAcoesApoio(AcoesApoioDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {

                    var _acoesApoio = new AcoesApoio()
                    {
                        Descricao = model.Descricao,
                        DataAtualizacao = DateTime.Now,
                        DataCriacao = DateTime.Now
                    };

                    await _dbContext.AddAsync(_acoesApoio);
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return await GetItemAcoesApoio(_acoesApoio.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }

        public async Task UpdateAcoesApoio(AcoesApoioDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _acaoApoio = await _dbContext.AcoesApoios.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

                    if (_acaoApoio == null)
                        throw new ArgumentException("Ação de apoio não encontrado.");

                    _acaoApoio.Descricao = model.Descricao;
                    _acaoApoio.DataAtualizacao = DateTime.Now;
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }

        public async Task DeleteAcoesApoio(long id)
        {
           using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _acaoApoio = await _dbContext.AcoesApoios.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (_acaoApoio == null)
                        throw new ArgumentException("Paciente não encontrado");

                    _dbContext.Remove(_acaoApoio);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }
    }
}