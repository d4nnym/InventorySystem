using InventorySystem.Application.DTOs.ProductCategories;
using InventorySystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.API.Controllers;

[ApiController]
[Route("api/categories")]
public class ProductCategoryController : ControllerBase
{
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
        var created = await categoryService.CreateAsync(request, ct);
        return CreatedAtRoute("Categories_GetById", new { id = created.Id }, created);
    }
}
