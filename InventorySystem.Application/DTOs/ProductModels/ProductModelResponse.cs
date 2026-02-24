namespace InventorySystem.Application.DTOs.ProductModels;

public sealed record ProductModelResponse
(
    Guid Id,
    Guid CategoryId,
    Guid BrandId,
    string ModelName
);
