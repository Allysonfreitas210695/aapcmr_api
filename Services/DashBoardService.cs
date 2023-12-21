using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                _dashBoardDto.DoacoesPendenteDtos = await _dbContext.Doacoes.Where(x => x.StatusDoacao == false).ToListAsync();
                _dashBoardDto.DoacoesRecebidasDtos = await _dbContext.Doacoes.Where(x => x.StatusDoacao == true).ToListAsync();
                _dashBoardDto.PacientesAtivoDtos = await _dbContext.Pacientes.Where(x => x.Status == true).ToListAsync();
                _dashBoardDto.PacientesInativosDtos = await _dbContext.Pacientes.Where(x => x.Status == false).ToListAsync();
                return _dashBoardDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }
    }
}