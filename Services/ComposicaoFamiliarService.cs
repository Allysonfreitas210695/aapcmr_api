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
    public class ComposicaoFamiliarService : IComposicaoFamiliarService
    {

        private readonly ApiContext _dbContext;
        public ComposicaoFamiliarService(ApiContext apiContext)
        {
            _dbContext = apiContext;
        }

        public async Task<ComposicaoFamiliar> GetItemComposicaoFamiliar(long id)
        {
            try
            {
                return await _dbContext.ComposicaoFamiliares
                                        .Where(x => x.Id == id)
                                        .Include(x => x.Paciente)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<List<ComposicaoFamiliar>> GetListComposicaoFamiliares()
        {
            try
            {
                return await _dbContext.ComposicaoFamiliares
                                        .Include(x => x.Paciente)
                                        .AsNoTracking()
                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<ComposicaoFamiliar> InsertComposicaoFamiliar(ComposicaoFamiliarDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (!_dbContext.Pacientes.Where(x => x.Id == model.PacienteId).Any())
                        throw new ArgumentException("paciente não encontrado!");

                    var _composicaoFamiliar = new ComposicaoFamiliar()
                    {
                        IdadeFamiliar = model.IdadeFamiliar,
                        NomeFamiliar = model.NomeFamiliar,
                        PacienteId = model.PacienteId,
                        Renda = model.Renda,
                        VinculoFamiliar = model.VinculoFamiliar,
                        DataAtualizacao = DateTime.Now,
                        DataCriacao = DateTime.Now
                    };

                    await _dbContext.AddAsync(_composicaoFamiliar);
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return await GetItemComposicaoFamiliar(_composicaoFamiliar.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }

        public async Task UpdateComposicaoFamiliar(ComposicaoFamiliarDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _composicaoFamiliar = await _dbContext.ComposicaoFamiliares.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    if (_composicaoFamiliar == null)
                        throw new ArgumentException("Paciente não encontrado");

                    _composicaoFamiliar.NomeFamiliar = model.NomeFamiliar;
                    _composicaoFamiliar.Renda = model.Renda;
                    _composicaoFamiliar.VinculoFamiliar = model.VinculoFamiliar;
                    _composicaoFamiliar.IdadeFamiliar = model.IdadeFamiliar;
                    _composicaoFamiliar.PacienteId = model.PacienteId;

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

        public async Task DeleteComposicaoFamiliar(long id)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _composicaoFamiliar = await _dbContext.ComposicaoFamiliares.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (_composicaoFamiliar == null)
                        throw new ArgumentException("Paciente não encontrado");

                    _dbContext.Remove(_composicaoFamiliar);
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