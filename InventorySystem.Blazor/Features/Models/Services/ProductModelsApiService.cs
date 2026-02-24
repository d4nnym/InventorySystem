using InventorySystem.Blazor.Features.Categories.Contracts;
using InventorySystem.Blazor.Features.Models.Contracts;
using InventorySystem.Blazor.Infrastructure.Http;
namespace InventorySystem.Blazor.Features.Models.Services;

public sealed class ProductModelsApiService(ApiClient api)
{
    private readonly ApiClient _api = api;

    public async Task<IReadOnlyCollection<ProductModelResponse>> GetAllAsync(CancellationToken ct = default)
        => await _api.GetAsync<List<ProductModelResponse>>("api/models", ct) ?? [];
    public async Task<IReadOnlyCollection<ProductModelDetailResponse>> GetDetailsAsync(CancellationToken ct = default)
        => await _api.GetAsync<List<ProductModelDetailResponse>>("api/models/details", ct) ?? [];
    public async Task<ProductModelResponse?> CreateAsync(CreateProductModelRequest request, CancellationToken ct = default)
    => await _api.PostAsyncWithResponse<CreateProductModelRequest, ProductModelResponse>("api/categories", request, ct);
}
