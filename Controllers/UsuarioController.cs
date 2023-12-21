using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_aapcmr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{usuarioId}")]
        public async Task<IActionResult> GetListUsuarios(long usuarioId)
        {
            try
            {
                return Ok(await _service.GetItemUsuario(usuarioId));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListUsuarios()
        {
            try
            {
                return Ok(await _service.GetListUsuarios());
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("EsqueceuSenha/{email}")]
        public async Task<IActionResult> EsqueceuSenha(string email)
        {
            try
            {
                await _service.EsqueceuSenha(email);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> InsertUsuario([FromBody] UsuarioDto model)
        {
            try
            {
                return Ok(await _service.InsertUsuario(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] UsuarioDto model)
        {
            try
            {
                await _service.UpdateUsuario(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{usuarioId}")]
        public async Task<IActionResult> DeleteUsuario(long usuarioId)
        {
            try
            {
                await _service.DeleteUsuario(usuarioId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("TrocaSenha/{usuarioId}/{senhaAntiga}/{senhaNova}")]
        public async Task<IActionResult> TrocaSenha(long usuarioId, string senhaAntiga, string senhaNova)
        {
            try
            {
                await _service.TrocaSenha(usuarioId, senhaAntiga, senhaNova);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}