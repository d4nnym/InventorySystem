using InventorySystem.Application.DTOs.ProductCategories;

namespace InventorySystem.Application.Interfaces;

public interface IProductCategoryService
{
    Task<CategoryResponse> CreateAsync(CreateCategoryRequest request, CancellationToken ct);

    Task<IReadOnlyCollection<CategoryResponse>> GetAllAsync(CancellationToken ct);
}
