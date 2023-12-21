using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_aapcmr.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TratamentoPacienteController : ControllerBase
    {
        private readonly ITratamentoPacienteService _service;
        public TratamentoPacienteController(ITratamentoPacienteService service)
        {
            _service = service;
        }

         [HttpGet]
        [Route("{tratamentoPacienteId}")]
        public async Task<IActionResult> GetItemPaciente(long tratamentoPacienteId)
        {
            try
            {
                return Ok(await _service.GetItemTratamentoPaciente(tratamentoPacienteId));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListTratamentoPacientes()
        {
            try
            {
                return Ok(await _service.GetListTratamentoPacientes());
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertTratamentoPaciente([FromBody] TratamentoPacienteDto model)
        {
            try
            {
                return Ok(await _service.InsertTratamentoPaciente(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTratamentoPaciente([FromBody] TratamentoPacienteDto model)
        {
            try
            {
                await _service.UpdateTratamentoPaciente(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{tratamentoPacienteId}")]
        public async Task<IActionResult> DeleteTratamentoPaciente(long tratamentoPacienteId)
        {
            try
            {
                await _service.DeleteTratamentoPaciente(tratamentoPacienteId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}