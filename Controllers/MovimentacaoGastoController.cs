using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_aapcmr.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class MovimentacaoGastoController : ControllerBase
    {
        private readonly ITipoGastoService _service;
        public MovimentacaoGastoController(ITipoGastoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{movimentacaoGastoId}")]
        public async Task<IActionResult> GetListMovimentacaoGastoId(long movimentacaoGastoId)
        {
            try
            {
                return Ok(await _service.GetItemMovimentacaoGasto(movimentacaoGastoId));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListMovimentacaoGastos()
        {
            try
            {
                return Ok(await _service.GetListMovimentacaoGastos());
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertMovimentacaoGasto([FromBody] TipoGastoDto model)
        {
            try
            {
                return Ok(await _service.InsertMovimentacaoGasto(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovimentacaoGasto([FromBody] TipoGastoDto model)
        {
            try
            {
                await _service.UpdateMovimentacaoGasto(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{movimentacaoGastoId}")]
        public async Task<IActionResult> DeleteMovimentacaoGasto(long pacienteId)
        {
            try
            {
                await _service.DeleteMovimentacaoGasto(pacienteId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}