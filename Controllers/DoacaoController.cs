using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> UpdateDoacao([FromBody] DoacaoDto model)
        {
            try
            {
                await _service.UpdateDoacao(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}