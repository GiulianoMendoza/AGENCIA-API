﻿using Application.Exceptions;
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
    public class MotoController : ControllerBase
    {
        private readonly IMotoService _motoService;
        public MotoController(IMotoService motoService)
        {
            _motoService = motoService;
        }
        /// <summary>
        /// Obtiene una lista de productos.
        /// </summary>
        /// <response code="200">Éxito al recuperar los productos.</response>
        /// <remarks>
        /// Recupera una lista de productos disponibles, con opciones de filtrado.
        /// </remarks>
        /// <param name="categories">Filtrar productos por categorías. Es posible filtrar por 1 o más categorías. Filtro opcional.</param>
        /// <param name="name">Filtrar productos por nombre. Es posible filtrar por nombres incompletos</param>
        /// <param name="limit">Limita el número de productos devueltos.</param>
        /// <param name="offset">Número de productos a omitir antes de empezar a devolver los resultados.</param>
        [HttpGet]
        [ProducesResponseType(typeof(List<MotoGetResponse>), 200)]
        public async Task<IActionResult> GetProductByFilter([FromQuery] List<int> categories, string? name, int limit = 0, int offset = 0)
        {
            var result = await _motoService.GetMotoByFilters(categories, name, limit, offset);
            return new JsonResult(result) { StatusCode = 200 };
        }
        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <response code="201">Producto creado con éxito.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="409">Conflicto, el producto ya existe.</response>
        /// <remarks>Permite la creación de un nuevo producto en el sistema.</remarks>
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(MotoResponse), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        [ProducesResponseType(typeof(ApiError), 409)]
        public async Task<IActionResult> RegisterProduct(MotoRequest request)
        {
            try
            {
                var result = await _motoService.RegisterMoto(request);
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
        /// Obtiene detalles de un producto específico.
        /// </summary>
        /// <response code="200">Éxito al recuperar los detalles del producto.</response>
        /// <response code="404">Producto no encontrado.</response>
        /// <remarks>Recupera los detalles de un producto por su ID único.</remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MotoResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 404)]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            try
            {
                var result = await _motoService.GetMotoById(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 404 };
            }
        }
        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <response code="200">Producto actualizado con éxito.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="404">Producto no encontrado.</response>
        /// <response code="409">Conflicto al actualizar el producto.</response>
        /// <remarks>Permite la actualización de los detalles de un producto específico.</remarks>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MotoResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 409)]
        public async Task<IActionResult> UpdateProduct(Guid id, MotoRequest request)
        {
            try
            {
                var result = await _motoService.UpdateMoto(id, request);
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
        /// Elimina un producto específico.
        /// </summary>
        /// <response code="200">Producto eliminado con éxito.</response>
        /// <response code="404">Producto no encontrado.</response>
        /// <response code="409">Producto asociado a una venta.</response>
        /// <remarks>Permite la eliminación de un producto del sistema usando su ID.</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MotoResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 409)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                var result = await _motoService.DeleteMoto(id);
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
