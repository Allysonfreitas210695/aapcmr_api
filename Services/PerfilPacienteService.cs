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
    public class PerfilPacienteService : IPerfilPacienteService
    {
        private readonly ApiContext _dbContext;

        public PerfilPacienteService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PerfilPaciente> GetItemPerfilPaciente(long id)
        {
            try
            {
                return await _dbContext.PerfilPacientes
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

        public async Task<List<PerfilPaciente>> GetListPerfilPacientes()
        {
            try
            {
                return await _dbContext.PerfilPacientes
                                        .Include(x => x.Paciente)
                                        .AsNoTracking()
                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<PerfilPaciente> InsertPerfilPaciente(PerfilPacienteDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _paciente = await _dbContext.Pacientes.Where(x => x.Id == model.PacienteId).FirstOrDefaultAsync();
                    if (_paciente == null)
                        throw new ArgumentException("Paciente não encontrado.");

                    var _perfilPaciente = new PerfilPaciente()
                    {
                        NomeMae = model.NomeMae,
                        NomePai = model.NomePai,
                        Profissiao = model.Profissiao,
                        ProgramaGoverno = model.ProgramaGoverno,
                        Religiao = model.Religiao,
                        DataAtualizacao = DateTime.Now,
                        DataCriacao = DateTime.Now
                    };

                    await _dbContext.AddAsync(_perfilPaciente);
                    await _dbContext.SaveChangesAsync();

                    _paciente.PerfilPacienteId = _perfilPaciente.Id;
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return await GetItemPerfilPaciente(_perfilPaciente.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }

        public async Task UpdatePerfilPaciente(PerfilPacienteDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {


                    var _paciente = await _dbContext.Pacientes.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    if (_paciente == null)
                        throw new ArgumentException("Paciente não encontrado.");

                    var _perfilPaciente = await _dbContext.PerfilPacientes.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    if (_perfilPaciente == null)
                        throw new ArgumentException("Perfil do paciente não encontrado.");

                    _perfilPaciente.NomeMae = model.NomeMae;
                    _perfilPaciente.NomePai = model.NomePai;
                    _perfilPaciente.Profissiao = model.Profissiao;
                    _perfilPaciente.ProgramaGoverno = model.ProgramaGoverno;
                    _perfilPaciente.Religiao = model.Religiao;
                    _perfilPaciente.DataAtualizacao = DateTime.Now;

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

        public async Task DeletePerfilPaciente(long id)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _perfilPaciente = await _dbContext.PerfilPacientes.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (_perfilPaciente == null)
                        throw new ArgumentException("Perfil do paciente não encontrado.");

                    _dbContext.Remove(_perfilPaciente);
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