namespace InventorySystem.Blazor.Features.Brands.Contracts;

public sealed record CreateProductBrandRequest(string Name);

public sealed record ProductBrandResponse(Guid Id,string Name);
