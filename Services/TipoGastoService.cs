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
    public class TipoGastoService : ITipoGastoService
    {
        private readonly ApiContext _dbContext;
        public TipoGastoService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TipoGasto> GetItemMovimentacaoGasto(long id)
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

        public async Task<List<TipoGasto>> GetListMovimentacaoGastos()
        {
            try
            {
                return await _dbContext.TipoGastos.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<TipoGasto> InsertMovimentacaoGasto(TipoGastoDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (string.IsNullOrEmpty(model.Descricao))
                        throw new ArgumentException("Descrição inválida.");

                    var _movimentacaoGasto = new TipoGasto()
                    {
                        Descricao = model.Descricao,
                        DataAtualizacao = DateTime.Now,
                        DataCriacao = DateTime.Now
                    };

                    await _dbContext.AddAsync(_movimentacaoGasto);
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return await GetItemMovimentacaoGasto(_movimentacaoGasto.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }

        public async Task UpdateMovimentacaoGasto(TipoGastoDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _movimentacaoGasto = await _dbContext.TipoGastos.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

                    if (_movimentacaoGasto == null)
                        throw new ArgumentException("Movimentação não encontrado.");

                    _movimentacaoGasto.Descricao = model.Descricao;
                    _movimentacaoGasto.DataAtualizacao = DateTime.Now;
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

        public async Task DeleteMovimentacaoGasto(long id)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _movimentacaoGasto = await _dbContext.TipoGastos.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (_movimentacaoGasto == null)
                        throw new ArgumentException("Movimentação não encontrado");

                    _dbContext.Remove(_movimentacaoGasto);
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