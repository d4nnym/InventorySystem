using InventorySystem.Blazor.Infrastructure.Http;
using InventorySystem.Blazor.Features.Categories.Contracts;
namespace InventorySystem.Blazor.Features.Categories.Services;

public sealed class ProductCategoriesApiClient(ApiClient api)
{
    //private readonly HttpClient _http = factory.CreateClient("InventorySystem");

    /*public async Task<IReadOnlyList<ProductCategoryResponse>> GetAllAsync(CancellationToken ct = default)
        => await _http.GetFromJsonAsync<List<ProductCategoryResponse>>("api/categories", ct) ?? [];*/
    public async Task<IReadOnlyCollection<ProductCategoryResponse>> GetAllAsync(CancellationToken ct = default)
    {
        var list = await api.GetAsync<List<ProductCategoryResponse>>("api/categories", ct);
        return list ?? [];
    } 

    /*public async Task<ProductCategoryResponse> CreateAsync (CreateProductCategoryRequest request,CancellationToken ct = default)
    {
        var response = await _http.("api/categories", request, ct);
        response.EnsureSuccessStatusCode();

        return (await response.Content.ReadFromJsonAsync<ProductCategoryResponse>(cancellationToken: ct))!;
    }*/
    public async Task<ProductCategoryResponse?> CreateAsync(CreateProductCategoryRequest request, CancellationToken ct = default)
    => await api.PostAsyncWithResponse<CreateProductCategoryRequest, ProductCategoryResponse>("api/categories", request, ct);
}


