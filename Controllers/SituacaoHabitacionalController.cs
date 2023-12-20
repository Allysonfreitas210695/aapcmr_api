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
    public class SituacaoHabitacionalController : ControllerBase
    {
        private readonly ISituacaoHabitacionalService _service;
        public SituacaoHabitacionalController(ISituacaoHabitacionalService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{situacaoHabitacionalId}")]
        public async Task<IActionResult> GetItemSituacaoHabitacional(long situacaoHabitacionalId)
        {
            try
            {
                return Ok(await _service.GetItemSituacaoHabitacional(situacaoHabitacionalId));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertSituacaoHabitacional([FromBody] SituacaoHabitacionalDto model)
        {
            try
            {
                return Ok(await _service.InsertSituacaoHabitacional(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSituacaoHabitacional([FromBody] SituacaoHabitacionalDto model)
        {
            try
            {
                await _service.UpdateSituacaoHabitacional(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}