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
    public class RelatorioMensalService : IRelatorioMensalService
    {
        private readonly ApiContext _dbContext;

        public RelatorioMensalService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RelatorioMensal> GetItemRelatorioMensal(long id)
        {
            try
            {
                return await _dbContext.RelatorioMensais
                                        .Where(x => x.Id == id)
                                        .Include(x => x.TipoGasto)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<List<RelatorioMensal>> GetListRelatorioMensals()
        {
            try
            {
                return await _dbContext.RelatorioMensais
                                        .Include(x => x.TipoGasto)
                                        .OrderByDescending(x => x.Data).ThenBy(x => x.DataCriacao)
                                        .AsNoTracking()
                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<RelatorioMensal> InsertRelatorioMensal(RelatorioMensalDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _tipoGasto = await _dbContext.TipoGastos.Where(x => x.Id == model.TipoGastoId).FirstOrDefaultAsync();
                    if (_tipoGasto == null)
                        throw new ArgumentException("Esse tipo de Gasto não está cadastrando.");

                    var _relatorioMensal = new RelatorioMensal()
                    {
                        Data = model.Data.Date,
                        Entrada = model.Entrada,
                        Saida = model.Saida,
                        Saldo = model.Entrada - model.Saida,
                        TipoGastoId = model.TipoGastoId,
                        DataAtualizacao = DateTime.Now,
                        DataCriacao = DateTime.Now
                    };

                    await _dbContext.AddAsync(_relatorioMensal);
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return await GetItemRelatorioMensal(_relatorioMensal.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }

        public async Task UpdateRelatorioMensal(RelatorioMensalDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _tipoGasto = await _dbContext.TipoGastos.Where(x => x.Id == model.TipoGastoId).FirstOrDefaultAsync();
                    if (_tipoGasto == null)
                        throw new ArgumentException("Esse tipo de Gasto não está cadastrando.");

                    var _relatorioMensal = await _dbContext.RelatorioMensais.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    if (_relatorioMensal == null)
                        throw new ArgumentException("Relatório não encontrado.");

                    _relatorioMensal.Data = model.Data.Date;
                    _relatorioMensal.Entrada = model.Entrada;
                    _relatorioMensal.Saida = model.Saida;
                    _relatorioMensal.Saldo = model.Entrada - model.Saida;
                    _relatorioMensal.TipoGastoId = model.TipoGastoId;
                    _relatorioMensal.DataAtualizacao = DateTime.Now;

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

        public async Task DeleteRelatorioMensal(long id)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {

                    var _relatorioMensal = await _dbContext.RelatorioMensais.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (_relatorioMensal == null)
                        throw new ArgumentException("Relatório não encontrado.");

                    _dbContext.Remove(_relatorioMensal);
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

        public async Task<List<RelatorioMensal>> FiltroRelatorioMensal(RelatorioMensalFiltroDto filtro)
        {
             try
            {
                return await _dbContext.RelatorioMensais
                                        .Where(x => x.Data.Date >= filtro.DataInicial.Date && x.Data.Date <= filtro.DataFinal.Date)
                                        .Include(x => x.TipoGasto)
                                        .OrderByDescending(x => x.Data).ThenBy(x => x.DataCriacao)
                                        .AsNoTracking()
                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }
    }
}