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
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _service;
        public PacienteController(IPacienteService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("{pacienteId}")]
        public async Task<IActionResult> GetListPaciente(long pacienteId)
        {
            try
            {
                return Ok(await _service.GetItemPaciente(pacienteId));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListPaciente()
        {
            try
            {
                return Ok(await _service.GetListPacientes());
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> InsertPaciente([FromBody] PacienteDto model)
        {
            try
            {
                return Ok(await _service.InsertPaciente(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaciente([FromBody] PacienteDto model)
        {
            try
            {
                await _service.UpdatePaciente(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{pacienteId}")]
        public async Task<IActionResult> DeletePaciente(long pacienteId)
        {
            try
            {
                await _service.DeletePaciente(pacienteId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}