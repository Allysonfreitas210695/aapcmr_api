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
    public class UsuarioService : IUsuarioService
    {
        private readonly ApiContext _dbContext;
        private readonly IEmailService _emailService;
        public UsuarioService(ApiContext dbContext, IEmailService emailService)
        {
            _dbContext = dbContext;
            _emailService = emailService;
        }

        public async Task<Usuario> GetItemUsuario(long id)
        {
            try
            {
                return await _dbContext.Usuarios.Where(x => x.Id == id).Include(x => x.PerfilUsuario).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<List<Usuario>> GetListUsuarios()
        {
            try
            {
                return await _dbContext.Usuarios.Include(x => x.PerfilUsuario).OrderBy(x => x.Nome).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Usuario> InsertUsuario(UsuarioDto model)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (await _dbContext.Usuarios.Where(x => x.Email == model.Email).AnyAsync())
                        throw new ArgumentException("Já existe um usuário com esse email");

                    var _usuario = new Usuario()
                    {
                        Email = model.Email,
                        Nome = model.Nome,
                        Senha = string.IsNullOrEmpty(model.Senha) ? "123mudar" : model.Senha,
                        DataAtualizacao = DateTime.Now,
                        DataCriacao = DateTime.Now,
                    };

                    await _dbContext.AddAsync(_usuario);
                    await _dbContext.SaveChangesAsync();

                    var _perfilUsuario = new PerfilUsuario()
                    {
                        Perfil = "Administrador",
                        UsuarioId = _usuario.Id
                    };

                    await _dbContext.AddAsync(_perfilUsuario);
                    await _dbContext.SaveChangesAsync();
                    //Enviar o email para usuario Administrador
                    await _emailService.SendEmailAsync(model.Email, "Cadastro de Administrator", "<body>bem vido ao sistema</body>");
                    await transaction.CommitAsync();
                    return await GetItemUsuario(_usuario.Id);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
                }
            }
        }

        public async Task UpdateUsuario(UsuarioDto model)
        {
            try
            {
                var _usuario = await _dbContext.Usuarios.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

                if (_usuario == null)
                    throw new ArgumentException("Usuário não encontrado.");

                _usuario.Nome = model.Nome;
                _usuario.Email = model.Email;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task DeleteUsuario(long id)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var _usuario = await _dbContext.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (_usuario == null)
                        throw new ArgumentException("Usuário não encontrado");

                    if (_dbContext.PerfilUsuarios.Where(x => x.UsuarioId == id).FirstOrDefault() == null)
                        throw new ArgumentException("Perfil não encontrado");

                    _dbContext.Remove(_dbContext.PerfilUsuarios.Where(x => x.UsuarioId == id).First());
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Remove(_usuario);
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

        public async Task EsqueceuSenha(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    throw new ArgumentException("Error no envio do email");

                Usuario usuario = await _dbContext.Usuarios.Where(x => x.Email == email).FirstOrDefaultAsync();

                if (usuario == null)
                    throw new ArgumentException("Não existe nenhum usuário com esse email");

                await _emailService.SendEmailAsync(usuario.Email, "Esqueceu senha", $"<body>Sua senha: {usuario.Senha}</body>");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task TrocaSenha(long usuarioId, string senhaAntiga, string senhaNova)
        {
            try
            {   
                var _usuario = await _dbContext.Usuarios.Where(x => x.Id == usuarioId && x.Senha == senhaAntiga).FirstOrDefaultAsync();

                if(_usuario == null)
                    throw new ArgumentException("Erro na senha antiga.");

                _usuario.Senha = senhaNova;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }
    }
}