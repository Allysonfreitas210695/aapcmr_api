using api_aapcmr.Config;
using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Services
{
    public class DashBoardService : IDashBoardService
    {
        private readonly ApiContext _dbContext;
        public DashBoardService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DashBoardDto> GetDashboard(FiltroDashBoardDto filtro)
        {
            try
            {
                DashBoardDto _dashBoardDto = new DashBoardDto();

                _dashBoardDto.ValorTotalDoacao = await _dbContext.Doacoes
                                                                        .Where(x => x.StatusDoacao == true &&
                                                                        ((filtro.DataInicial == null && filtro.DataFinal == null) || (filtro.DataInicial != null && filtro.DataFinal != null &&
                                                                            x.DataDoacao.Date >= filtro.DataInicial.Value.Date &&
                                                                            x.DataDoacao.Date <= filtro.DataFinal.Value.Date)
                                                                        ))
                                                                        .AsNoTracking()
                                                                        .SumAsync(x => x.ValorDoacao);

                _dashBoardDto.ValorTotalMessageiro = await _dbContext.Doacoes
                                                                        .Where(x => x.StatusDoacao == true && x.TipoDeEnvioValor == "Mensageiro" &&
                                                                        ((filtro.DataInicial == null && filtro.DataFinal == null) || (filtro.DataInicial != null && filtro.DataFinal != null &&
                                                                            x.DataDoacao.Date >= filtro.DataInicial.Value.Date &&
                                                                            x.DataDoacao.Date <= filtro.DataFinal.Value.Date)
                                                                        ))
                                                                        .AsNoTracking()
                                                                        .SumAsync(x => x.ValorDoacao);

                _dashBoardDto.ValorTotalDesposito = await _dbContext.Doacoes
                                                                       .Where(x => x.StatusDoacao == true && x.TipoDeEnvioValor == "Depósito" &&
                                                                       ((filtro.DataInicial == null && filtro.DataFinal == null) || (filtro.DataInicial != null && filtro.DataFinal != null &&
                                                                           x.DataDoacao.Date >= filtro.DataInicial.Value.Date &&
                                                                           x.DataDoacao.Date <= filtro.DataFinal.Value.Date)
                                                                       ))
                                                                       .AsNoTracking()
                                                                       .SumAsync(x => x.ValorDoacao);

                _dashBoardDto.DoacoesPendenteDtos = await _dbContext.Doacoes
                                                                        .Where(x => x.StatusDoacao == false &&
                                                                        ((filtro.DataInicial == null && filtro.DataFinal == null) || (filtro.DataInicial != null && filtro.DataFinal != null &&
                                                                            x.DataDoacao.Date >= filtro.DataInicial.Value.Date &&
                                                                            x.DataDoacao.Date <= filtro.DataFinal.Value.Date)
                                                                        ))
                                                                        .OrderBy(x => x.NomeDoador).ThenBy(x => x.DataCriacao)
                                                                        .Select(z => new DoacaoListDto()
                                                                        {
                                                                            Id = z.Id,
                                                                            DataDoacao = z.DataDoacao.ToString("dd/MM/yyyy"),
                                                                            Endereco = $"{z.Bairro}, {z.Cep}, {z.Cidade} - {z.Numero}",
                                                                            NomeDoador = z.NomeDoador,
                                                                            Telefone = z.Telefone,
                                                                            TipoDeEnvioValor = z.TipoDeEnvioValor,
                                                                            StatusDoacao = "Pendente",
                                                                            ValorDoacao = z.ValorDoacao
                                                                        })
                                                                        .AsNoTracking()
                                                                        .ToListAsync();


                _dashBoardDto.DoacoesRecebidasDtos = await _dbContext.Doacoes
                                                                            .Where(x => x.StatusDoacao == true &&
                                                                            ((filtro.DataInicial == null && filtro.DataFinal == null) || (filtro.DataInicial != null && filtro.DataFinal != null &&
                                                                                x.DataDoacao.Date >= filtro.DataInicial.Value.Date &&
                                                                                x.DataDoacao.Date <= filtro.DataFinal.Value.Date)
                                                                            ))
                                                                            .OrderBy(x => x.NomeDoador).ThenBy(x => x.DataCriacao)
                                                                            .Select(z => new DoacaoListDto()
                                                                            {
                                                                                Id = z.Id,
                                                                                DataDoacao = z.DataDoacao.ToString("dd/MM/yyyy"),
                                                                                Endereco = $"{z.Bairro}, {z.Cep}, {z.Cidade} - {z.Numero}",
                                                                                NomeDoador = z.NomeDoador,
                                                                                Telefone = z.Telefone,
                                                                                TipoDeEnvioValor = z.TipoDeEnvioValor,
                                                                                StatusDoacao = "Recebido",
                                                                                ValorDoacao = z.ValorDoacao
                                                                            })
                                                                            .AsNoTracking()
                                                                            .ToListAsync();

                _dashBoardDto.PacientesAtivoDtos = await _dbContext.Pacientes
                                                                        .Where(x => x.Status == true &&
                                                                            ((filtro.DataInicial == null && filtro.DataFinal == null) || (filtro.DataInicial != null && filtro.DataFinal != null &&
                                                                                x.DataCriacao.Date >= filtro.DataInicial.Value.Date &&
                                                                                x.DataCriacao.Date <= filtro.DataFinal.Value.Date)
                                                                            ))
                                                                        .OrderBy(x => x.Nome).ThenBy(x => x.DataCriacao)
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
                                                                        .AsNoTracking()
                                                                        .ToListAsync();

                _dashBoardDto.PacientesInativosDtos = await _dbContext.Pacientes
                                                                        .Where(x => x.Status == false &&
                                                                            ((filtro.DataInicial == null && filtro.DataFinal == null) || (filtro.DataInicial != null && filtro.DataFinal != null &&
                                                                                x.DataCriacao.Date >= filtro.DataInicial.Value.Date &&
                                                                                x.DataCriacao.Date <= filtro.DataFinal.Value.Date)
                                                                            ))
                                                                        .OrderBy(x => x.Nome).ThenBy(x => x.DataCriacao)
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
                                                                        .AsNoTracking()
                                                                        .ToListAsync();
                return _dashBoardDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }
    }
}