using InventorySystem.Blazor.Infrastructure.Http;
using InventorySystem.Blazor.Features.Models.Contracts;

namespace InventorySystem.Blazor.Features.Models.Services;

public sealed class ProductModelsApiClient(ApiClient api)
{
    //private readonly ApiClient _api = api;

    public async Task<IReadOnlyCollection<ProductModelResponse>> GetAllAsync(CancellationToken ct = default)
    {
        var list = await api.GetAsync<List<ProductModelResponse>>("api/productmodels", ct) ?? [];
        return list ?? [];
    }

    public async Task<IReadOnlyCollection<ProductModelDetailResponse>> GetDetailsAsync(CancellationToken ct = default)
    {
        var list = await api.GetAsync<List<ProductModelDetailResponse>>("api/productmodels/details", ct) ?? [];
        return list ?? [];
    }
    public async Task<ProductModelResponse?> CreateAsync(CreateProductModelRequest request, CancellationToken ct = default)
    => await api.PostAsyncWithResponse<CreateProductModelRequest, ProductModelResponse>("api/productmodels", request, ct);
}
