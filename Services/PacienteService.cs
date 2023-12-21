using api_aapcmr.Config;
using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using api_aapcmr.Repository;
using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly ApiContext _dbContext;
        public PacienteService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Paciente> GetItemPaciente(long id)
        {
            try
            {
                return await _dbContext.Pacientes
                                        .Where(x => x.Id == id)
                                        .Include(x => x.Usuario)
                                        .Include(x => x.TratamentoPacientes)
                                        .Include(x => x.SituacaoHabitacional)
                                        .Include(x => x.ComposicaoFamiliares)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<List<PacienteListDto>> GetListPacientes()
        {
            try
            {
                return await _dbContext.Pacientes
                                        .Include(x => x.Usuario)
                                        .Include(x => x.SituacaoHabitacional)
                                        .Select(z => new PacienteListDto()
                                        {
                                            Id = z.Id,
                                            Nome = z.Nome,
                                            CPF = z.CPF,
                                            DataNascimento = z.DataNascimento.ToString("dd/MM/yyyy"),
                                            Endereco = z.SituacaoHabitacional != null ? $"{z.SituacaoHabitacional.Bairro}, {z.SituacaoHabitacional.Cep}, {z.SituacaoHabitacional.Cidade} - {z.SituacaoHabitacional.Numero}" : "",
                                            Naturalidade = z.Naturalidade,
                                            Status = z.Status ? "Ativo" : "Inativo",
                                            StatusCivil = z.StatusCivil,
                                            Sexo = z.Sexo,
                                            CestaBasica = z.CestaBasica ? "Sim" : "Não",
                                            Celular = z.Celular,
                                            TelefoneFixo = z.TelefoneFixo
                                        })
                                        .OrderBy(x => x.Nome)
                                        .AsNoTracking()
                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Paciente> InsertPaciente(PacienteDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (await _dbContext.Pacientes.Where(x => x.CPF == model.CPF).AnyAsync())
                        throw new ArgumentException("Já existe um usuário com esse CPF.");

                    if (await _dbContext.Pacientes.Where(x => !string.IsNullOrEmpty(model.SUSNumero) && x.SUSNumero == model.SUSNumero).AnyAsync())
                        throw new ArgumentException("Já existe um usuário com esse número do SUS.");

                    var _paciente = new Paciente()
                    {
                        Nome = model.Nome,
                        CPF = model.CPF,
                        DataNascimento = model.DataNascimento.Date,
                        Naturalidade = model.Naturalidade,
                        SUSNumero = model.SUSNumero,
                        StatusCivil = model.StatusCivil,
                        CestaBasica = model.CestaBasica,
                        Sexo = model.Sexo,
                        Status = model.Status,
                        UsuarioId = model.UsuarioId,
                        Celular = model.Celular,
                        TelefoneFixo = model.TelefoneFixo,
                        DataAtualizacao = DateTime.Now,
                        DataCriacao = DateTime.Now
                    };

                    await _dbContext.AddAsync(_paciente);
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return await GetItemPaciente(_paciente.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }

        public async Task UpdatePaciente(PacienteDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (await _dbContext.Pacientes.Where(x => x.Id != model.Id && !string.IsNullOrEmpty(model.SUSNumero) && x.SUSNumero == model.SUSNumero).AnyAsync())
                        throw new ArgumentException("Já existe um usuário com esse némero do SUS.");

                    var _paciente = await _dbContext.Pacientes.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

                    if (_paciente == null)
                        throw new ArgumentException("Paciente não encontrado.");

                    _paciente.Nome = model.Nome;
                    _paciente.CPF = model.CPF;
                    _paciente.DataNascimento = model.DataNascimento;
                    _paciente.Naturalidade = model.Naturalidade;
                    _paciente.Sexo = model.Sexo;
                    _paciente.Status = model.Status;
                    _paciente.SUSNumero = model.SUSNumero;
                    _paciente.StatusCivil = model.StatusCivil;
                    _paciente.UsuarioId = model.UsuarioId;
                    _paciente.CestaBasica = model.CestaBasica;
                    _paciente.Celular = model.Celular;
                    _paciente.TelefoneFixo = model.TelefoneFixo;

                    _paciente.DataAtualizacao = DateTime.Now;

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
        public async Task DeletePaciente(long id)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _paciente = await _dbContext.Pacientes.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (_paciente == null)
                        throw new ArgumentException("Paciente não encontrado");

                    _dbContext.RemoveRange(_dbContext.TratamentoPacientes.Where(x => x.PacienteId == _paciente.Id).ToList());
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Remove(_paciente);
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

        public async Task<List<PacienteListDto>> ConsultaPacientes(FiltroConsultaPacienteDto filtro)
        {
            try
            {
                return await _dbContext.Pacientes
                .Where(x =>
                            (string.IsNullOrEmpty(filtro.Nome) || x.Nome == filtro.Nome) &&
                            x.CPF == filtro.CPF &&
                            x.CestaBasica == filtro.CestaBasica &&
                            (filtro.DataNascimento == null || filtro.DataNascimento.Value.Date == x.DataNascimento.Date) &&
                            (string.IsNullOrEmpty(filtro.SUSNumero) || filtro.SUSNumero == x.SUSNumero)
                )
                .Include(x => x.SituacaoHabitacional)
                .Select(z => new PacienteListDto()
                {
                    Id = z.Id,
                    CestaBasica = z.CestaBasica ? "SIM" : "NÃO",
                    CPF = z.CPF,
                    DataNascimento = z.DataNascimento.ToString("dd/MM/yyyy"),
                    Endereco = z.SituacaoHabitacional != null ? $"{z.SituacaoHabitacional.Bairro}, {z.SituacaoHabitacional.Cep}, {z.SituacaoHabitacional.Cidade} - {z.SituacaoHabitacional.Numero}" : "",
                    Naturalidade = z.Naturalidade,
                    Nome = z.Nome,
                    StatusCivil = z.StatusCivil,
                    Status = z.Status ? "Atico" : "Inativo"
                })
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