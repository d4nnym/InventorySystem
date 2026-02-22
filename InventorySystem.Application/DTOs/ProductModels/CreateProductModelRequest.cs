namespace InventorySystem.Application.DTOs.ProductModels;

public sealed record CreateProductModelRequest
(
    Guid CategoryId,
    Guid BrandId,
    string ModelName
);
