using InventorySystem.Application.DTOs.ProductBrands;
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

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BrandResponse>> GetByIdAsync(
        [FromRoute] Guid id,
        [FromServices] IProductBrandService brandService, CancellationToken ct)
        => Ok(await brandService.GetByIdAsync(id, ct));

    [HttpPost]
    public async Task<ActionResult<BrandResponse>> CreateAsync(
        [FromBody] CreateBrandRequest request,
        [FromServices] IProductBrandService brandService, CancellationToken ct)
    {
        await brandService.CreateAsync(request, ct);
        return Ok();
    }
}
