using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_aapcmr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticanteController : ControllerBase
    {
        private readonly IAutenticanteService _service;

        public AutenticanteController(IAutenticanteService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateUser([FromBody] FiltroAutenticacaoDto model)
        {
            try
            {
                return Ok(await _service.AutenticanteUser(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}