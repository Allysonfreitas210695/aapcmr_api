using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_aapcmr.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RelatorioMensalController : ControllerBase
    {
        private readonly IRelatorioMensalService _service;
        public RelatorioMensalController(IRelatorioMensalService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{relatorioMensalId}")]
        public async Task<IActionResult> GetItemRelatorioMensal(long relatorioMensalId)
        {
            try
            {
                return Ok(await _service.GetItemRelatorioMensal(relatorioMensalId));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListPerfilPacientes()
        {
            try
            {
                return Ok(await _service.GetListRelatorioMensals());
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertRelatorioMensal([FromBody] RelatorioMensalDto model)
        {
            try
            {
                return Ok(await _service.InsertRelatorioMensal(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRelatorioMensal([FromBody] RelatorioMensalDto model)
        {
            try
            {
                await _service.UpdateRelatorioMensal(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{relatorioMensalId}")]
        public async Task<IActionResult> DeleteRelatorioMensal(long relatorioMensalId)
        {
            try
            {
                await _service.DeleteRelatorioMensal(relatorioMensalId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("FiltroRelatorioMensal")]
        public async Task<IActionResult> FiltroRelatorioMensal([FromBody] RelatorioMensalFiltroDto filtro)
        {
            try
            {
                return Ok(await _service.FiltroRelatorioMensal(filtro));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}