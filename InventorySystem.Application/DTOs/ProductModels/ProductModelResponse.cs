namespace InventorySystem.Application.DTOs.ProductModels;

public sealed record ProductModelResponse
(
    Guid Id,
    string ModelName,
    Guid CategoryId,
    Guid BrandId
);
