using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api_aapcmr.AppSettings;
using api_aapcmr.Config;
using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api_aapcmr.Services
{
    public class AutenticanteService : IAutenticanteService
    {
        private readonly ApiContext _dbContext;
        public AutenticanteService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<AuthenticateDto> AutenticanteUser(FiltroAutenticacaoDto model)
        {
            try
            {
                // Recupera o usuário
                var user = await _dbContext.Usuarios
                .Where(x => x.Email == model.Email && x.Senha == model.Senha)
                .Include(x => x.PerfilUsuario)
                .AsNoTracking()
                .FirstOrDefaultAsync();

                // Verifica se o usuário existe
                if (user == null)
                    throw new ArgumentException("Usuário ou senha inválidos");

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Settings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim(ClaimTypes.Role, user.PerfilUsuario.Perfil),
                    }),
                    Expires = DateTime.UtcNow.AddHours(24),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var _token = tokenHandler.WriteToken(token);

                return new AuthenticateDto()
                {
                    Id = user.Id,
                    Nome = user.Nome,
                    Token = _token,
                    Expires = tokenDescriptor.Expires
                };
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }
    }
}