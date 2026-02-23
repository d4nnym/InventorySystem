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

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CategoryResponse>> GetByIdAsync(
        [FromRoute] Guid id,
        [FromServices] IProductCategoryService categoryService, CancellationToken ct)
        => Ok(await categoryService.GetByIdAsync(id, ct));

    [HttpPost]
    public async Task<ActionResult<CategoryResponse>> CreateAsync(
        [FromBody] CreateCategoryRequest request,
        [FromServices] IProductCategoryService categoryService, CancellationToken ct)
    {
        //var createdCategory = await categoryService.CreateAsync(request, ct);
        await categoryService.CreateAsync(request, ct);
        return Ok();
    }
}
