using InventorySystem.Infrastructure.Persistence;
using InventorySystem.Application.Interfaces;
using InventorySystem.Domain.Entities;
using InventorySystem.Application.DTOs.ProductBrands;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure.Services;


public sealed class ProductBrandService (OracleDbContext db) : IProductBrandService
{
    public async Task<IReadOnlyCollection<BrandResponse>> GetAllAsync(CancellationToken ct)
    {
        return await db.Brands
            .AsNoTracking()
            .OrderByDescending(b => b.BrandName)
            .Select(b => new BrandResponse(b.Id, b.BrandName))
            .ToListAsync(ct);
    }

    public async Task<BrandResponse?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await db.Brands
            .AsNoTracking()
            .Where(b => b.Id == id)
            .Select(b => new BrandResponse(b.Id, b.BrandName))
            .FirstOrDefaultAsync(ct);
    }

    public async Task<BrandResponse> CreateAsync(CreateBrandRequest request, CancellationToken ct)
    {
        var brand = new ProductBrand(request.BrandName);
        await db.Brands.AddAsync(brand, ct);
        await db.SaveChangesAsync(ct);

        return new BrandResponse(
            brand.Id,
            brand.BrandName
        );
    }
}
