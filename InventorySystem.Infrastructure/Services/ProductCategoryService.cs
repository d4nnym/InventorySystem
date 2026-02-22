using InventorySystem.Application.DTOs.ProductCategories;
using InventorySystem.Application.Interfaces;
using InventorySystem.Domain.Entities;
using InventorySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure.Services;

public sealed class ProductCategoryService(OracleDbContext db) : IProductCategoryService
{
    public async Task<IReadOnlyCollection<CategoryResponse>> GetAllAsync(CancellationToken ct)
    {

        return await db.Categories
            .AsNoTracking()
            .OrderByDescending(c => c.CategoryName)
            .Select(c => new CategoryResponse(c.Id, c.CategoryName))
            .ToListAsync(ct);

    }
    public async Task<CategoryResponse> CreateAsync(CreateCategoryRequest request, CancellationToken ct)
    {
        var category = new ProductCategory(request.CategoryName);

        await db.Categories.AddAsync(category, ct);
        await db.SaveChangesAsync(ct);

        return new CategoryResponse(
            category.Id,
            category.CategoryName
        );
    }


}
