using System.Net;
using System.Net.Http.Json;

namespace InventorySystem.Blazor.Infrastructure.Http;

public sealed class ApiClient
{
    private readonly HttpClient _http;

    public ApiClient(HttpClient http) => _http = http;

    public async Task<T?> GetAsync<T>(string uri, CancellationToken ct)
    {
        var response = await _http.GetAsync(uri, ct);

        if (response.StatusCode == HttpStatusCode.NotFound)
            return default;

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>(cancellationToken: ct);
    }

    public async Task PostAsync<TBody>(string uri, TBody body, CancellationToken ct = default)
    {
        var response = await _http.PostAsJsonAsync(uri, body, ct);
        response.EnsureSuccessStatusCode();
    }

    public async Task<TResult?> PostAsyncWithResponse<TBody, TResult>(
        string uri,
        TBody body,
        CancellationToken ct = default)
    {
        var response = await _http.PostAsJsonAsync(uri, body, ct);

        if (response.StatusCode == HttpStatusCode.NotFound)
            return default;

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResult>(cancellationToken: ct);
    }
}