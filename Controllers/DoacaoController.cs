using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_aapcmr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoacaoController : ControllerBase
    {
        private readonly IDoacaoService _service;
        public DoacaoController(IDoacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{doacaoId}")]
        public async Task<IActionResult> GetItemDoacao(long doacaoId)
        {
            try
            {
                return Ok(await _service.GetItemDoacao(doacaoId));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListDoacoes()
        {
            try
            {
                return Ok(await _service.GetListDoacaos());
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertDoacao([FromBody] DoacaoDto model)
        {
            try
            {
                return Ok(await _service.InsertDoacao(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("{doacaoId}/{StatusDoacao}")]
        public async Task<IActionResult> UpdateDoacao(long doacaoId, bool StatusDoacao)
        {
            try
            {
                await _service.UpdateDoacao(doacaoId, StatusDoacao);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemDoacao([FromBody] DoacaoDto model)
        {
            try
            {
                await _service.UpdateItemDoacao(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{doacaoId}")]
        public async Task<IActionResult> DeleteDoacao(long doacaoId)
        {
            try
            {
                await _service.DeleteDoacao(doacaoId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}