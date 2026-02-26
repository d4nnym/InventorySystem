using InventorySystem.Application.DTOs.ProductCategories;
using InventorySystem.Application.DTOs.ProductModels;
using InventorySystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.API.Controllers;

[ApiController]
[Route("api/productmodels")]
public class ProductModelController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<ProductModelResponse>>> GetAllAsync(
        [FromServices] IProductModelService modelService, CancellationToken ct)
        => Ok(await modelService.GetAllAsync(ct));

    [HttpGet("{id:guid}", Name = "Models_GetById")]
    public async Task<ActionResult<ProductModelResponse>> GetByIdAsync(
        Guid id,
        [FromServices] IProductModelService modelService, CancellationToken ct)
    {
        var result = await modelService.GetByIdAsync(id, ct);
        return result is null ? NotFound() : Ok(result);
    } 

    [HttpGet("details")]
    public async Task<ActionResult<IReadOnlyCollection<ProductModelDetailResponse>>> GetDetailsAsync(
        [FromServices] IProductModelService modelService, CancellationToken ct)
        => Ok(await modelService.GetDetailAsync(ct));

    [HttpPost]
    public async Task<ActionResult<ProductModelResponse>> CreateAsync(
    [FromBody] CreateProductModelRequest request,
    [FromServices] IProductModelService modelService,
    CancellationToken ct)
    {
        var created = await modelService.CreateAsync(request, ct);
        return CreatedAtRoute("Models_GetById", new { id = created.Id }, created);
    }
  
}
