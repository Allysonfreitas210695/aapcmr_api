using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_aapcmr.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ComposicaoFamiliarController : ControllerBase
    {
        private readonly IComposicaoFamiliarService _service;
        public ComposicaoFamiliarController(IComposicaoFamiliarService service)
        {
            _service = service;
        }

         [HttpGet]
        [Route("{composicaoFamiliarId}")]
        public async Task<IActionResult> GetItemComposicaoFamiliar(long composicaoFamiliarId)
        {
            try
            {
                return Ok(await _service.GetItemComposicaoFamiliar(composicaoFamiliarId));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListComposicaoFamilias()
        {
            try
            {
                return Ok(await _service.GetListComposicaoFamiliares());
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertComposicaoFamiliar([FromBody] ComposicaoFamiliarDto model)
        {
            try
            {
                return Ok(await _service.InsertComposicaoFamiliar(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComposicaoFamiliar([FromBody] ComposicaoFamiliarDto model)
        {
            try
            {
                await _service.UpdateComposicaoFamiliar(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{composicaoFamiliarId}")]
        public async Task<IActionResult> DeleteComposicaoFamiliar(long composicaoFamiliarId)
        {
            try
            {
                await _service.DeleteComposicaoFamiliar(composicaoFamiliarId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}