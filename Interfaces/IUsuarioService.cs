using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Dto;
using api_aapcmr.Repository;

namespace api_aapcmr.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> GetItemUsuario(long id);
        Task<List<Usuario>> GetListUsuarios();
        Task UpdateUsuario(UsuarioDto model);
        Task<Usuario> InsertUsuario(UsuarioDto model);
        Task DeleteUsuario(long id);
        Task EsqueceuSenha(string email);
    }
}