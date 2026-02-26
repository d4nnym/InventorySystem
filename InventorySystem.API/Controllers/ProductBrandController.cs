using InventorySystem.Application.DTOs.ProductBrands;
using InventorySystem.Application.DTOs.ProductCategories;
using InventorySystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.API.Controllers;

[ApiController]
[Route("api/brands")]
public class ProductBrandController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<BrandResponse>>> GetAllAsync(
        [FromServices] IProductBrandService brandService, CancellationToken ct)
        => Ok(await brandService.GetAllAsync(ct));

    [HttpGet("{id:guid}", Name = "Brands_GetById")]
    public async Task<ActionResult<BrandResponse>> GetByIdAsync(
        Guid id,
        [FromServices] IProductBrandService brandService, CancellationToken ct)
    {
        var result = await brandService.GetByIdAsync(id, ct);
        return result is null ? NotFound() : Ok(result);
    }
   
    [HttpPost]
    public async Task<ActionResult<BrandResponse>> CreateAsync(
    [FromBody] CreateBrandRequest request,
    [FromServices] IProductBrandService brandService,
    CancellationToken ct)
    {
        var created = await brandService.CreateAsync(request, ct);
        return CreatedAtRoute("Brands_GetById", new { id = created.Id }, created);
    }
}
