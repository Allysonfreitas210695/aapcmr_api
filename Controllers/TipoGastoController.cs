using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_aapcmr.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TipoGastoController : ControllerBase
    {
        private readonly ITipoGastoService _service;
        public TipoGastoController(ITipoGastoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{tipoGastoId}")]
        public async Task<IActionResult> GetListTipoGastoId(long tipoGastoId)
        {
            try
            {
                return Ok(await _service.GetItemTipoGasto(tipoGastoId));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListTipoGastos()
        {
            try
            {
                return Ok(await _service.GetListTipoGastos());
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertTipoGasto([FromBody] TipoGastoDto model)
        {
            try
            {
                return Ok(await _service.InsertTipoGasto(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTipoGasto([FromBody] TipoGastoDto model)
        {
            try
            {
                await _service.UpdateTipoGasto(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{TipoGastoId}")]
        public async Task<IActionResult> DeleteTipoGasto(long pacienteId)
        {
            try
            {
                await _service.DeleteTipoGasto(pacienteId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}