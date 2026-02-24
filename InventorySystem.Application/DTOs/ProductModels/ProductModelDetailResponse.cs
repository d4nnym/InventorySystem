using InventorySystem.Application.DTOs.ProductBrands;
using InventorySystem.Application.DTOs.ProductCategories;

namespace InventorySystem.Application.DTOs.ProductModels;

public sealed record ProductModelDetailResponse
(
    Guid Id,
    Guid CategoryId,
    Guid BrandId,
    string ModelName,
    CategoryResponse Category,
    BrandResponse Brand
);
