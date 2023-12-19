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
                                        .Select(z => new PacienteListDto()
                                        {
                                            Id = z.Id,
                                            Nome = z.Nome,
                                            CPF = z.CPF,
                                            DataNascimento = z.DataNascimento.ToString("dd/MM/yyyy"),
                                            Endereco = $"{z.Bairro}, {z.Cep}, {z.Cidade} - {z.Numero}",
                                            Naturalidade = z.Naturalidade,
                                            RG = z.RG,
                                            StatusCivil = z.StatusCivil
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

                    if (await _dbContext.Pacientes.Where(x => x.RG == model.RG).AnyAsync())
                        throw new ArgumentException("Já existe um usuário com esse RG.");

                    var _paciente = new Paciente()
                    {
                        Nome = model.Nome,
                        Bairro = model.Bairro,
                        Cep = model.Cep,
                        Complemento = model.Complemento,
                        CPF = model.CPF,
                        DataNascimento = model.DataNascimento.Date,
                        Logradouro = model.Logradouro,
                        Naturalidade = model.Naturalidade,
                        Numero = model.Numero,
                        RG = model.RG,
                        Cidade = model.Cidade,
                        StatusCivil = model.StatusCivil,
                        UF = model.UF,
                        UsuarioId = model.UsuarioId,
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
                    var _paciente = await _dbContext.Pacientes.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

                    if (_paciente == null)
                        throw new ArgumentException("Paciente não encontrado.");

                    _paciente.Nome = model.Nome;
                    _paciente.Cidade = model.Cidade;
                    _paciente.Bairro = model.Bairro;
                    _paciente.Cep = model.Cep;
                    _paciente.Complemento = model.Complemento;
                    _paciente.CPF = model.CPF;
                    _paciente.DataNascimento = model.DataNascimento;
                    _paciente.Logradouro = model.Logradouro;
                    _paciente.Naturalidade = model.Naturalidade;
                    _paciente.Numero = model.Numero;
                    _paciente.RG = model.RG;
                    _paciente.StatusCivil = model.StatusCivil;
                    _paciente.UF = model.UF;
                    _paciente.UsuarioId = model.UsuarioId;

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
    }
}