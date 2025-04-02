using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnController : ControllerBase
    {
        private readonly ITurnService _turnService;
        public TurnController(ITurnService turnService)
        {
            _turnService = turnService;
        }
        /// <summary>
        /// Obtiene una lista de turns.
        /// </summary>
        /// <response code="200">Éxito al recuperar los turns.</response>
        /// <remarks>
        [HttpGet]
        [ProducesResponseType(typeof(List<TurnResponse>), 200)]
        public async Task<IActionResult> GetAllTurns()
        {
            var result = await _turnService.GetTurns();
            return new JsonResult(result) { StatusCode = 200 };
        }
        /// <summary>
        /// Crea un nuevo turno.
        /// </summary>
        /// <response code="201">turno creado con éxito.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <remarks>Permite la creación de un nuevo turno en el sistema.</remarks>
        [HttpPost]
        [ProducesResponseType(typeof(TurnResponse), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> RegisterTurn(TurnRequest request)
        {
            try
            {
                var result = await _turnService.RegisterTurn(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 400 };
            }
            catch (ExceptionConflict ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 409 };
            }
        }
        /// <summary>
        /// Obtiene detalles de un turno específico.
        /// </summary>
        /// <response code="200">Éxito al recuperar los detalles del turno.</response>
        /// <response code="404">turno no encontrado.</response>
        /// <remarks>Recupera los detalles de un turno por su ID único.</remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TurnResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 404)]
        public async Task<IActionResult> GetTurnById(int id)
        {
            try
            {
                var result = await _turnService.GetTurnsById(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 404 };
            }
        }
        /// <summary>
        /// Actualiza un turno existente.
        /// </summary>
        /// <response code="200">turno actualizado con éxito.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="404">turno no encontrado.</response>
        /// <response code="409">Conflicto al actualizar el turno.</response>
        /// <remarks>Permite la actualización de los detalles de un turno específico.</remarks>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TurnResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 409)]
        public async Task<IActionResult> UpdateTurn(int id, TurnRequest request)
        {
            try
            {
                var result = await _turnService.UpdateTurn(id, request);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 400 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 404 };
            }
            catch (ExceptionConflict ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 409 };
            }
        }
        /// <summary>
        /// Elimina un turno específico.
        /// </summary>
        /// <response code="200">turno eliminado con éxito.</response>
        /// <response code="404">turno no encontrado.</response>
        /// <remarks>Permite la eliminación de un turno del sistema usando su ID.</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TurnResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 409)]
        public async Task<IActionResult> DeleteTurn(int id)
        {
            try
            {
                var result = await _turnService.DeleteTurn(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 404 };
            }
            catch (ExceptionConflict ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 409 };
            }
        }
    }
}

