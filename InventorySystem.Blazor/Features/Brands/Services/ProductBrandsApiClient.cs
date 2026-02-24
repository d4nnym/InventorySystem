using InventorySystem.Blazor.Infrastructure.Http;
using InventorySystem.Blazor.Features.Brands.Contracts;
namespace InventorySystem.Blazor.Features.Brands.Services;

public class ProductBrandsApiClient(ApiClient api)
{
    private readonly ApiClient _api = api;
    public async Task<IReadOnlyCollection<ProductBrandResponse>> GetAllAsync(CancellationToken ct = default)
        => await _api.GetAsync<List<ProductBrandResponse>>("api/brands", ct) ?? [];
    public async Task<ProductBrandResponse?> CreateAsync(CreateProductBrandRequest request, CancellationToken ct = default)
        => await _api.PostAsyncWithResponse<CreateProductBrandRequest, ProductBrandResponse>("api/brands", request, ct);
}
