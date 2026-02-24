using InventorySystem.Application.DTOs.ProductModels;
using InventorySystem.Application.DTOs.ProductBrands;
using InventorySystem.Application.DTOs.ProductCategories;
using InventorySystem.Application.Interfaces;
using InventorySystem.Domain.Entities;
using InventorySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure.Services;

public sealed class ProductModelService(OracleDbContext db) : IProductModelService
{
    public async Task<IReadOnlyCollection<ProductModelResponse>> GetAllAsync(CancellationToken ct)
    {
        return await db.ProductModels
            .AsNoTracking()
            .OrderByDescending(c => c.ModelName)
            .Select(c => new ProductModelResponse(c.Id, c.CategoryId, c.BrandId, c.ModelName))
            .ToListAsync(ct);
    }

    public async Task<ProductModelResponse?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await db.ProductModels
             .AsNoTracking()
             .Where(c => c.Id == id)
             .Select(c => new ProductModelResponse(c.Id, c.CategoryId, c.BrandId, c.ModelName))
             .FirstOrDefaultAsync(ct);
    }

    public async Task<IReadOnlyCollection<ProductModelDetailResponse>> GetDetailAsync(CancellationToken ct)
    {
        return await db.ProductModels
             .AsNoTracking()
             .OrderByDescending(c => c.ModelName)
             .Select(c => new ProductModelDetailResponse(
                c.Id,
                c.CategoryId,
                c.BrandId,
                c.ModelName,
                new CategoryResponse(c.Category.Id, c.Category.CategoryName),
                new BrandResponse(c.Brand.Id, c.Brand.BrandName)

             ))
             .ToListAsync(ct);
    }

    public async Task<ProductModelResponse> CreateAsync(CreateProductModelRequest request, CancellationToken ct)
    {
        var model = new ProductModel(request.CategoryId,request.BrandId,request.ModelName);
        await db.ProductModels.AddAsync(model, ct);
        await db.SaveChangesAsync(ct);
        return new ProductModelResponse(
            model.Id,
            model.CategoryId,
            model.BrandId,
            model.ModelName
        );
    }

    

}
