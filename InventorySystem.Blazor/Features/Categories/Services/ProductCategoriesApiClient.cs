using InventorySystem.Blazor.Infrastructure.Http;
using InventorySystem.Blazor.Features.Categories.Contracts;
namespace InventorySystem.Blazor.Features.Categories.Services;

public sealed class ProductCategoriesApiClient(ApiClient api)
{

    public async Task<IReadOnlyCollection<ProductCategoryResponse>> GetAllAsync(CancellationToken ct = default)
    {
        var list = await api.GetAsync<List<ProductCategoryResponse>>("api/categories", ct);
        return list ?? [];
    } 

    public async Task<ProductCategoryResponse?> CreateAsync(CreateProductCategoryRequest request, CancellationToken ct = default)
    => await api.PostAsyncWithResponse<CreateProductCategoryRequest, ProductCategoryResponse>("api/categories", request, ct);
}


