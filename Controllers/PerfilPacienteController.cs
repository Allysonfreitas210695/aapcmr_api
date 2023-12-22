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
    public class PerfilPacienteController : ControllerBase
    {
        private readonly IPerfilPacienteService _service;
        public PerfilPacienteController(IPerfilPacienteService service)
        {
            _service = service;
        }

          [HttpGet]
        [Route("{perfilPacienteId}")]
        public async Task<IActionResult> GetItemPerfilPaciente(long perfilPacienteId)
        {
            try
            {
                return Ok(await _service.GetItemPerfilPaciente(perfilPacienteId));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListPerfilPacientes()
        {
            try
            {
                return Ok(await _service.GetListPerfilPacientes());
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertPerfilPaciente([FromBody] PerfilPacienteDto model)
        {
            try
            {
                return Ok(await _service.InsertPerfilPaciente(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerfilPaciente([FromBody] PerfilPacienteDto model)
        {
            try
            {
                await _service.UpdatePerfilPaciente(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{perfilPacienteId}")]
        public async Task<IActionResult> DeletePerfilPaciente(long perfilPacienteId)
        {
            try
            {
                await _service.DeletePerfilPaciente(perfilPacienteId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}