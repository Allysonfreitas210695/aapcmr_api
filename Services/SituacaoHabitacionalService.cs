using api_aapcmr.Config;
using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using api_aapcmr.Repository;
using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Services
{
    public class SituacaoHabitacionalService : ISituacaoHabitacionalService
    {
        private readonly ApiContext _dbContext;
        public SituacaoHabitacionalService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SituacaoHabitacional> GetItemSituacaoHabitacional(long id)
        {
            try
            {
                return await _dbContext.SituacaoHabitacionais
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

        public async Task<SituacaoHabitacional> InsertSituacaoHabitacional(SituacaoHabitacionalDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _paciente = await _dbContext.Pacientes.Where(x => x.Id == model.PacienteId).FirstOrDefaultAsync();
                    if (_paciente == null)
                        throw new ArgumentException("Paciente não encontrado.");

                    var _situacaoHabitacional = new SituacaoHabitacional()
                    {
                        Bairro = model.Bairro,
                        Casa = model.Casa,
                        Cep = model.Cep,
                        Cidade = model.Cidade,
                        Complemento = model.Complemento,
                        Logradouro = model.Logradouro,
                        Moradia = model.Moradia,
                        Numero = model.Numero,
                        Transporte = model.Transporte,
                        InstalacaoSanitaria = model.InstalacaoSanitaria,
                        Agua = model.Agua,
                        Luz = model.Luz,
                        UF = model.UF,
                        PacienteId = model.PacienteId,
                        DataAtualizacao = DateTime.Now,
                        DataCriacao = DateTime.Now
                    };

                    await _dbContext.AddAsync(_situacaoHabitacional);
                    await _dbContext.SaveChangesAsync();

                    _paciente.SituacaoHabitacionalId = _situacaoHabitacional.Id;
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return await GetItemSituacaoHabitacional(_situacaoHabitacional.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }

        public async Task UpdateSituacaoHabitacional(SituacaoHabitacionalDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _situacaoHabitacional = await _dbContext.SituacaoHabitacionais.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

                    if (_situacaoHabitacional == null)
                        throw new ArgumentException("Situação habitacional não encontrado.");

                    _situacaoHabitacional.Bairro = model.Bairro;
                    _situacaoHabitacional.Casa = model.Casa;
                    _situacaoHabitacional.Cep = model.Cep;
                    _situacaoHabitacional.Cidade = model.Cidade;
                    _situacaoHabitacional.Complemento = model.Complemento;
                    _situacaoHabitacional.Logradouro = model.Logradouro;
                    _situacaoHabitacional.Moradia = model.Moradia;
                    _situacaoHabitacional.Numero = model.Numero;
                    _situacaoHabitacional.Transporte = model.Transporte;
                    _situacaoHabitacional.InstalacaoSanitaria = model.InstalacaoSanitaria;
                    _situacaoHabitacional.Agua = model.Agua;
                    _situacaoHabitacional.Luz = model.Luz;
                    _situacaoHabitacional.UF = model.UF;
                    _situacaoHabitacional.PacienteId = model.PacienteId;
                    _situacaoHabitacional.DataAtualizacao = DateTime.Now;

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