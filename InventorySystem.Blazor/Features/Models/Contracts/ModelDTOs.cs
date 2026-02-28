namespace InventorySystem.Blazor.Features.Models.Contracts;

public sealed record CreateProductModelRequest(
    Guid? CategoryId,
    Guid? BrandId,
    string ModelName
);

public sealed record ProductModelResponse(
    Guid Id,
    Guid CategoryId,
    Guid Brand,
    string ModelName
);

public sealed record ProductModelDetailResponse(
    Guid Id,
    Guid CategoryId,
    Guid Brand,
    string ModelName,
    string CategoryName,
    string BrandName
);
