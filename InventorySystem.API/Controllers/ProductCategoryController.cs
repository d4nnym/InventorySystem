using InventorySystem.Infrastructure.Services;
using InventorySystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using InventorySystem.Application.DTOs.ProductCategories;
namespace InventorySystem.API.Controllers;

[ApiController]
[Route("api/categories")]
public class ProductCategoryController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<CategoryResponse>>> GetAllAsync(
        [FromServices] IProductCategoryService categoryService, CancellationToken ct) 
        => Ok(await categoryService.GetAllAsync(ct));
    
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
