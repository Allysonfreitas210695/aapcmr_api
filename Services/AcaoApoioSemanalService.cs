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
    public class AcaoApoioSemanalService : IAcaoApoioSemanalService
    {
        private readonly ApiContext _dbContext;
        public AcaoApoioSemanalService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AcaoApoioSemanal> GetItemAcaoApoioSemanal(long id)
        {
            try
            {
                return await _dbContext.AcaoApoioSemanais.Where(x => x.Id == id).Include(x => x.AcoesApoio).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<List<AcaoApoioSemanal>> GetListAcaoApoioSemanals()
        {
            try
            {
                return await _dbContext.AcaoApoioSemanais.Include(x => x.AcoesApoio).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<AcaoApoioSemanal> InsertAcaoApoioSemanal(AcaoApoioSemanalDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {

                    var _acaoApoioSemanal = new AcaoApoioSemanal()
                    {
                        Descricao = model.Descricao,
                        AcoesApoioId = model.AcoesApoioId,
                        DataAtualizacao = DateTime.Now,
                        DataCriacao = DateTime.Now
                    };

                    await _dbContext.AddAsync(_acaoApoioSemanal);
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return await GetItemAcaoApoioSemanal(_acaoApoioSemanal.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }

        public async Task UpdateAcaoApoioSemanal(AcaoApoioSemanalDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _acaoApoioSemanal = await _dbContext.AcaoApoioSemanais.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

                    if (_acaoApoioSemanal == null)
                        throw new ArgumentException("Ação de apoio semanal não encontrado.");

                    if (model.AcoesApoioId == 0)
                        throw new ArgumentException("Ação de apoio não encontrado.");

                    _acaoApoioSemanal.Descricao = model.Descricao;
                    _acaoApoioSemanal.DataInicial = model.DataInicial;
                    _acaoApoioSemanal.DataFinal = model.DataFinal;
                    _acaoApoioSemanal.AcoesApoioId = model.AcoesApoioId;
                    _acaoApoioSemanal.DataAtualizacao = DateTime.Now;

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

        public async Task DeleteAcaoApoioSemanal(long id)
        {
             using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _acaoApoioSemanal = await _dbContext.AcaoApoioSemanais.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (_acaoApoioSemanal == null)
                        throw new ArgumentException("Ação semanal não encontrado.");

                    _dbContext.Remove(_acaoApoioSemanal);
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