using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_aapcmr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcaoApoioSemanalController : ControllerBase
    {
        private readonly IAcaoApoioSemanalService _service;
        public AcaoApoioSemanalController(IAcaoApoioSemanalService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{acaoApoioSemanalId}")]
        public async Task<IActionResult> GetItemAcaoApoioSemanal(long acaoApoioSemanalId)
        {
            try
            {
                return Ok(await _service.GetItemAcaoApoioSemanal(acaoApoioSemanalId));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListAcaoApoioSemanals()
        {
            try
            {
                return Ok(await _service.GetListAcaoApoioSemanals());
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertAcaoApoioSemanal([FromBody] AcaoApoioSemanalDto model)
        {
            try
            {
                return Ok(await _service.InsertAcaoApoioSemanal(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAcaoApoioSemanal([FromBody] AcaoApoioSemanalDto model)
        {
            try
            {
                await _service.UpdateAcaoApoioSemanal(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{acaoApoioSemanalId}")]
        public async Task<IActionResult> DeleteAcaoApoioSemanal(long acaoApoioSemanalId)
        {
            try
            {
                await _service.DeleteAcaoApoioSemanal(acaoApoioSemanalId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}