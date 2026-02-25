namespace InventorySystem.Blazor.Features.Brands.Contracts;

public sealed record CreateProductBrandRequest(string BrandName);

public sealed record ProductBrandResponse(Guid Id,string BrandName);
