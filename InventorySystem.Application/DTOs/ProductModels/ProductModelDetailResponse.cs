using InventorySystem.Application.DTOs.ProductCategories;
using InventorySystem.Application.DTOs.ProductBrands;

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
