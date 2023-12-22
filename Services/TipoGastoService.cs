using api_aapcmr.Config;
using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using api_aapcmr.Repository;
using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Services
{
    public class TipoGastoService : ITipoGastoService
    {
        private readonly ApiContext _dbContext;
        public TipoGastoService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TipoGasto> GetItemTipoGasto(long id)
        {
            try
            {
                return await _dbContext.TipoGastos.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<List<TipoGasto>> GetListTipoGastos()
        {
            try
            {
                return await _dbContext.TipoGastos.AsNoTracking().OrderBy(x => x.Descricao).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<TipoGasto> InsertTipoGasto(TipoGastoDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (string.IsNullOrEmpty(model.Descricao))
                        throw new ArgumentException("Descrição inválida.");

                    var _TipoGasto = new TipoGasto()
                    {
                        Descricao = model.Descricao,
                        DataAtualizacao = DateTime.Now,
                        DataCriacao = DateTime.Now
                    };

                    await _dbContext.AddAsync(_TipoGasto);
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return await GetItemTipoGasto(_TipoGasto.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }

        public async Task UpdateTipoGasto(TipoGastoDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _TipoGasto = await _dbContext.TipoGastos.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

                    if (_TipoGasto == null)
                        throw new ArgumentException("Movimentação não encontrado.");

                    _TipoGasto.Descricao = model.Descricao;
                    _TipoGasto.DataAtualizacao = DateTime.Now;
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

        public async Task DeleteTipoGasto(long id)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _TipoGasto = await _dbContext.TipoGastos.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (_TipoGasto == null)
                        throw new ArgumentException("Movimentação não encontrado");

                    _dbContext.Remove(_TipoGasto);
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