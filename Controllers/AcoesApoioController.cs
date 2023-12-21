using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_aapcmr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcoesApoioController : ControllerBase
    {
        private readonly IAcoesApoioService _service;
        public AcoesApoioController(IAcoesApoioService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("{acaoApoioId}")]
        public async Task<IActionResult> GetListPaciente(long acaoApoioId)
        {
            try
            {
                return Ok(await _service.GetItemAcoesApoio(acaoApoioId));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListAcoesApoio()
        {
            try
            {
                return Ok(await _service.GetListAcoesApoios());
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertAcoesApoio([FromBody] AcoesApoioDto model)
        {
            try
            {
                return Ok(await _service.InsertAcoesApoio(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAcoesApoio([FromBody] AcoesApoioDto model)
        {
            try
            {
                await _service.UpdateAcoesApoio(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{acaoApoioId}")]
        public async Task<IActionResult> DeleteAcoesApoio(long acaoApoioId)
        {
            try
            {
                await _service.DeleteAcoesApoio(acaoApoioId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}