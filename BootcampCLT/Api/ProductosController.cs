using BootcampCLT.Api.Request;
using BootcampCLT.Api.Response;
using BootcampCLT.Application.Command;
using BootcampCLT.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BootcampCLT.Api
{

    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(
            IMediator mediator,
            ILogger<ProductoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene el listado completo de productos activos.
        /// </summary>
        /// <returns>Lista de productos.</returns>
        [HttpGet("v1/api/productos")]
        [ProducesResponseType(typeof(List<ProductoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ProductoResponse>>> GetAllProductos()
        {
            _logger.LogInformation("Inicio GetAllProductos");

            try
            {
                var result = await _mediator.Send(new GetProductosQuery());

                _logger.LogInformation(
                    "GetAllProductos completado. Cantidad={Cantidad}",
                    result.Count);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el listado de productos");
                throw;
            }
        }

        /// <summary>
        /// Obtiene el detalle de un producto por su identificador.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <returns>Producto encontrado.</returns>
        [HttpGet("v1/api/productos/{id:int}")]
        [ProducesResponseType(typeof(ProductoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductoResponse>> GetProductoById([FromRoute] int id)
        {
            _logger.LogInformation("Inicio GetProductoById. ProductoId={ProductoId}", id);

            try
            {
                var result = await _mediator.Send(new GetProductoByIdQuery(id));

                if (result is null)
                {
                    _logger.LogWarning( "Producto no encontrado. ProductoId={ProductoId}", id);

                    return NotFound();
                }

                _logger.LogInformation("Producto obtenido correctamente. ProductoId={ProductoId}", id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener producto. ProductoId={ProductoId}", id);

                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="request">Datos del producto a crear.</param>
        /// <returns>Producto creado.</returns>
        [HttpPost("v1/api/productos")]
        [ProducesResponseType(typeof(ProductoResponse), StatusCodes.Status201Created)]
        public async Task<ActionResult<ProductoResponse>> CreateProducto([FromBody] CreateProductoRequest request)
        {
            _logger.LogInformation("Inicio CreateProducto. Codigo={Codigo}", request.Codigo);

            try
            {
                var result = await _mediator.Send(new CreateProductoCommand(request));

                _logger.LogInformation(
                    "Producto creado correctamente. ProductoId={ProductoId}, Codigo={Codigo}",
                    result.Id,
                    result.Codigo);

                return CreatedAtAction(nameof(GetProductoById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al crear producto. Codigo={Codigo}",
                    request.Codigo);

                throw;
            }
        }

        /// <summary>
        /// Actualiza completamente un producto existente.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <param name="request">Datos completos a actualizar.</param>
        [HttpPut("v1/api/productos/{id:int}")]
        [ProducesResponseType(typeof(ProductoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductoResponse>> UpdateProducto(
            [FromRoute] int id,
            [FromBody] UpdateProductoRequest request)
        {
            _logger.LogInformation("Inicio UpdateProducto. ProductoId={ProductoId}",id);

            try
            {
                var result = await _mediator.Send(new UpdateProductoCommand(id, request));

                if (result is null)
                {
                    _logger.LogWarning(
                        "Producto no encontrado para actualizar. ProductoId={ProductoId}",
                        id);

                    return NotFound();
                }

                _logger.LogInformation(
                    "Producto actualizado correctamente. ProductoId={ProductoId}",
                    id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al actualizar producto. ProductoId={ProductoId}",
                    id);

                throw;
            }
        }

        /// <summary>
        /// Actualiza parcialmente un producto existente.
        /// Solo se modificarán los campos enviados.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <param name="request">Campos a actualizar.</param>
        [HttpPatch("v1/api/productos/{id:int}")]
        [ProducesResponseType(typeof(ProductoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductoResponse>> PatchProducto(
            [FromRoute] int id,
            [FromBody] PatchProductoRequest request)
        {
            _logger.LogInformation( "Inicio PatchProducto. ProductoId={ProductoId}", id);

            try
            {
                var result = await _mediator.Send(new PatchProductoCommand(id, request));

                if (result is null)
                {
                    _logger.LogWarning(
                        "Producto no encontrado para patch. ProductoId={ProductoId}",
                        id);

                    return NotFound();
                }

                _logger.LogInformation(
                    "Producto actualizado parcialmente. ProductoId={ProductoId}",
                    id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al actualizar parcialmente producto. ProductoId={ProductoId}",
                    id);

                throw;
            }
        }

        /// <summary>
        /// Elimina un producto existente.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        [HttpDelete("v1/api/productos/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            _logger.LogInformation("Inicio DeleteProducto. ProductoId={ProductoId}", id);

            try
            {
                var deleted = await _mediator.Send(new DeleteProductoCommand(id));

                if (!deleted)
                {
                    _logger.LogWarning("Producto no encontrado para eliminar. ProductoId={ProductoId}", id);

                    return NotFound();
                }

                _logger.LogInformation( "Producto eliminado correctamente. ProductoId={ProductoId}", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al eliminar producto. ProductoId={ProductoId}",
                    id);

                throw;
            }

        }
    }
}
