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
    public class TratamentoPacienteService : ITratamentoPacienteService
    {
        private readonly ApiContext _dbContext;
        public TratamentoPacienteService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TratamentoPaciente> GetItemTratamentoPaciente(long id)
        {
            try
            {
                return await _dbContext.TratamentoPacientes
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

        public async Task<List<TratamentoPacienteDto>> GetListTratamentoPacientes()
        {
            try
            {
                return await _dbContext.TratamentoPacientes
                                        .Include(x => x.Paciente)
                                        .Select(z => new TratamentoPacienteDto()
                                        {
                                            Id = z.Id,
                                            Diagnostico = z.Diagnostico,
                                            AnoDiagnostico = z.AnoDiagnostico,
                                            Medico = z.Medico,
                                            StatusTratamento = z.StatusTratamento,
                                            TipoCirurgia = z.TipoCirurgia
                                        })
                                        .OrderBy(x => x.Diagnostico)
                                        .AsNoTracking()
                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<TratamentoPaciente> InsertTratamentoPaciente(TratamentoPacienteDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (model.PacienteId == 0)
                        throw new ArgumentException("Error ao validar usuário.");

                    var _tratamentoPaciente = new TratamentoPaciente()
                    {
                        AnoDiagnostico = model.AnoDiagnostico,
                        Diagnostico = model.Diagnostico,
                        Medico = model.Medico,
                        PacienteId = model.PacienteId,
                        StatusTratamento = model.StatusTratamento,
                        TipoCirurgia = model.TipoCirurgia,
                        DataAtualizacao = DateTime.Now,
                        DataCriacao = DateTime.Now
                    };

                    await _dbContext.AddAsync(_tratamentoPaciente);
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return await GetItemTratamentoPaciente(_tratamentoPaciente.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }

        public async Task UpdateTratamentoPaciente(TratamentoPacienteDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _tratamentoPaciente = await _dbContext.TratamentoPacientes.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

                    if (_tratamentoPaciente == null)
                        throw new ArgumentException("Tratamento do paciente não encontrado.");

                    _tratamentoPaciente.AnoDiagnostico = model.AnoDiagnostico;
                    _tratamentoPaciente.Diagnostico = model.Diagnostico;
                    _tratamentoPaciente.Medico = model.Medico;
                    _tratamentoPaciente.PacienteId = model.PacienteId;
                    _tratamentoPaciente.StatusTratamento = model.StatusTratamento;
                    _tratamentoPaciente.TipoCirurgia = model.TipoCirurgia;
                    _tratamentoPaciente.DataAtualizacao = DateTime.Now;

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

        public async Task DeleteTratamentoPaciente(long id)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _tratamentoPaciente = await _dbContext.TratamentoPacientes.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (_tratamentoPaciente == null)
                        throw new ArgumentException("Tratamento do paciente não encontrado");

                    _dbContext.Remove(_tratamentoPaciente);
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