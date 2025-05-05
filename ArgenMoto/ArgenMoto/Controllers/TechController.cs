using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Application.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ArgenMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechController : ControllerBase
    {
        private readonly ITechnService _TechService;
        public TechController(ITechnService techService)
        {
            _TechService = techService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<TechResponse>), 200)]
        public async Task<IActionResult> GetAllTurns()
        {
            var result = await _TechService.GetTech();
            return new JsonResult(result) { StatusCode = 200 };
        }
        [HttpGet("Me")]
        [ProducesResponseType(typeof(TechResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 404)]
        public async Task<IActionResult> GetTechById()
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var result = await _TechService.GetTechById(userId);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 404 };
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(TechResponse), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> RegisterTech([FromBody] TechRequest request)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var result = await _TechService.RegisterTech(request, userId);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
