namespace InventorySystem.Blazor.Features.Categories.Contracts;

public sealed record class CreateProductCategoryRequest(string CategoryName);
public sealed record class ProductCategoryResponse(Guid Id, string CategoryName);