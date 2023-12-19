using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Dto;

namespace api_aapcmr.Interfaces
{
    public interface IAutenticanteService
    {
        Task<AuthenticateDto> AutenticanteUser(FiltroAutenticacaoDto model);
    }
}