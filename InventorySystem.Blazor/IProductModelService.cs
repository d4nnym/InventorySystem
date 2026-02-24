using InventorySystem.Application.DTOs.ProductModels;
namespace InventorySystem.Application.Interfaces;

public interface IProductModelService
{
    Task<ProductModelResponse> CreateAsync(CreateProductModelRequest request, CancellationToken ct);

    Task<IReadOnlyCollection<ProductModelResponse>> GetAllAsync(CancellationToken ct);

    Task<IReadOnlyCollection<ProductModelDetailResponse>> GetDetailAsync(CancellationToken ct);
    
    Task<ProductModelResponse> GetByIdAsync(Guid id, CancellationToken ct);
}
