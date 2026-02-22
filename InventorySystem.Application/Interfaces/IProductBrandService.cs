using InventorySystem.Application.DTOs.ProductBrands;
namespace InventorySystem.Application.Interfaces;

public interface IProductBrandService
{
    Task<BrandResponse> CreateAsync(CreateBrandRequest request, CancellationToken ct);
    Task<IReadOnlyCollection<BrandResponse>> GetAllAsync(CancellationToken ct);

}
