using BootcampCLT.Api.Request;
using BootcampCLT.Api.Response;
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
            _logger.LogInformation("Obteniendo todos los productos activos.");

            var result = await _mediator.Send(new GetProductosQuery());

            _logger.LogInformation("Se obtuvieron {Cantidad} productos.", result.Count);
            return Ok(result);
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
            var result = await _mediator.Send(new GetProductoByIdQuery(id));

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="request">Datos del producto a crear.</param>
        /// <returns>Producto creado.</returns>
        //[HttpPost("v1/api/productos")]
        //[ProducesResponseType(typeof(ProductoResponse), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public ActionResult<ProductoResponse> CreateProducto([FromBody] CreateProductoRequest request)
        //{
        //    return Created(string.Empty, null);
        //}

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
        public ActionResult<ProductoResponse> UpdateProducto(
            [FromRoute] int id,
            [FromBody] UpdateProductoRequest request)
        {
            return Ok();
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
        public ActionResult<ProductoResponse> PatchProducto(
            [FromRoute] int id,
            [FromBody] PatchProductoRequest request)
        {
            return Ok();
        }

        /// <summary>
        /// Elimina un producto existente.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        [HttpDelete("v1/api/productos/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteProducto([FromRoute] int id)
        {
            return NoContent();
        }
    }
}


// del profesor
