using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ArgenMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        /// <summary>
        /// Obtiene un listado de ventas.
        /// </summary>
        /// <response code="200">Éxito al recuperar las ventas.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <remarks>Recupera un resumen de las ventas realizadas, con opción de filtrado por fecha.</remarks>
        [HttpGet]
        [Authorize(Roles = "admin,vendedor,user,tecnico")]
        [ProducesResponseType(typeof(SaleGetResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> GetAllSale(DateTime from, DateTime to)
        {
            try
            {
                var result = await _saleService.GetSale(from, to);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 400 };
            }

        }
        /// <summary>
        /// Registra una nueva venta.
        /// </summary>
        /// <response code="201">Venta registrada con éxito.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <remarks>Permite ingresar una nueva venta al sistema.</remarks>
        [HttpPost]
        [Authorize(Roles = "admin,user,vendedor")]
        [ProducesResponseType(typeof(SaleResponse), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> RegisterSale(SaleRequest request)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var result = await _saleService.RegisterSale(request, userId);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 400 };
            }
        }
        /// <summary>
        /// Obtiene detalles de una venta específica.
        /// </summary>
        /// <response code="200">Éxito al recuperar los detalles de la venta.</response>
        /// <response code="404">Venta no encontrada.</response>
        /// <remarks>Recupera los detalles de una venta por su ID único.</remarks>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,vendedor,user")]
        [ProducesResponseType(typeof(SaleResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 404)]
        public async Task<IActionResult> GetSaleById(int id)
        {
            try
            {
                var result = await _saleService.GetSaleById(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 404 };
            }
        }
    }
}
