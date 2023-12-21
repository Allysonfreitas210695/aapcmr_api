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
    public class DoacaoService : IDoacaoService
    {

        private readonly ApiContext _dbContext;
        public DoacaoService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Doacao> GetItemDoacao(long id)
        {
            try
            {
                return await _dbContext.Doacoes
                                        .Where(x => x.Id == id)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<List<Doacao>> GetListDoacaos()
        {
            try
            {
                return await _dbContext.Doacoes
                                        .AsNoTracking()
                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Doacao> InsertDoacao(DoacaoDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _doacao = new Doacao()
                    {
                        Bairro = model.Bairro,
                        Cep = model.Cep,
                        NomeDoador = model.NomeDoador,
                        Cidade = model.Cidade,
                        Complemento = model.Complemento,
                        DataDoacao = model.DataDoacao.Date,
                        Logradouro = model.Logradouro,
                        Numero = model.Numero,
                        StatusDoacao = model.StatusDoacao,
                        Telefone = model.Telefone,
                        TipoDeEnvioValor = model.TipoDeEnvioValor,
                        UF = model.UF,
                        ValorDoacao = model.ValorDoacao,
                        DataAtualizacao = DateTime.Now,
                        DataCriacao = DateTime.Now
                    };

                    await _dbContext.AddAsync(_doacao);
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return await GetItemDoacao(_doacao.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }

        public async Task UpdateDoacao(DoacaoDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _doacao = await _dbContext.Doacoes.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    if (_doacao == null)
                        throw new ArgumentException("Doação não encontrada!");
                        
                    _doacao.StatusDoacao = model.StatusDoacao;
                    _doacao.DataAtualizacao = DateTime.Now;

                    await _dbContext.AddAsync(_doacao);
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