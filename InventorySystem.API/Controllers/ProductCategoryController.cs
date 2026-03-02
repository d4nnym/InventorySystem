using InventorySystem.Application.DTOs.ProductCategories;
using InventorySystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InventorySystem.API.Controllers;

[ApiController]
[Route("api/categories")]
public class ProductCategoryController : ControllerBase
{
    private readonly ILogger<ProductCategoryController> _logger;
    private readonly IProductCategoryService _service;
    public ProductCategoryController(
        ILogger<ProductCategoryController> logger,
        IProductCategoryService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<CategoryResponse>>> GetAllAsync(
        [FromServices] IProductCategoryService categoryService, CancellationToken ct)
        => Ok(await categoryService.GetAllAsync(ct));

    [HttpGet("{id:guid}", Name = "Categories_GetById")]
    public async Task<ActionResult<CategoryResponse>> GetByIdAsync(
    Guid id,
    [FromServices] IProductCategoryService categoryService,
    CancellationToken ct)
    {
            var result = await categoryService.GetByIdAsync(id, ct);
            return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryResponse>> CreateAsync(
    [FromBody] CreateCategoryRequest request,
    [FromServices] IProductCategoryService categoryService,
    CancellationToken ct)
    {
        try
        {
            var created = await categoryService.CreateAsync(request, ct);
            return CreatedAtRoute("Categories_GetById", new { id = created.Id }, created);
        }
        catch (DuplicateNameException ex)
        {
            return Problem(
                title: "Nombre de Categoría Duplicado",
                detail: ex.Message,
                statusCode: StatusCodes.Status409Conflict);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear la cetegoría");

            return Problem(
                title: "Error interno",
                detail: "Ocurrió un error inesperado al crear la categoría.",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}
