using api_aapcmr.Dto;
using api_aapcmr.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_aapcmr.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class DashBoardController : Controller
    {
        private readonly IDashBoardService _service;

        public DashBoardController(IDashBoardService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> GetDashboard([FromBody] FiltroDashBoardDto model)
        {
            try
            {
                return Ok(await _service.GetDashboard(model));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

    }
}