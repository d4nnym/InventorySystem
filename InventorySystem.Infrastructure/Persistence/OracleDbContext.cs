using InventorySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure.Persistence;

public class OracleDbContext(DbContextOptions<OracleDbContext> options) : DbContext(options)
{
    //public DbSet<ProductCategory> Categories => Set<ProductCategory>();
    public DbSet<ProductCategory> Categories { get; set; } = null!;
    public DbSet<ProductBrand> Brands { get; set; } = null!;
    public DbSet<ProductModel> ProductModels { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<AttributeDefinition> Attributes { get; set; } = null!;
    public DbSet<AttributeValue> AttributeValues { get; set; } = null!;
    public DbSet<ProductAttribute> ProductAttributes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.HasDefaultSchema("INVENTORY_SYSTEM").UseCollation("USING_NLS_COMP");
        modelBuilder.HasDefaultSchema("INVENTORY_SYSTEM");

        modelBuilder.Entity<ProductCategory>(e =>
        {
            e.ToTable("TBL_INV_SYS_CATEGORIES");
            e.HasKey(x => x.Id);

            e.Property(x => x.Id).HasColumnName("ID").ValueGeneratedNever();

            e.Property(x => x.CategoryName).HasColumnName("CATEGORY_NAME")
            .HasMaxLength(255)
            .IsUnicode(false)
            .IsRequired();

            e.HasIndex(x => x.CategoryName).IsUnique();

        });

        modelBuilder.Entity<ProductBrand>(e =>
        {
            e.ToTable("TBL_INV_SYS_BRANDS");
            e.HasKey(x => x.Id);

            e.Property(x => x.Id).HasColumnName("ID").ValueGeneratedNever();

            e.Property(x => x.BrandName).HasColumnName("BRAND_NAME")
            .HasMaxLength(255)
            .IsUnicode(false)
            .IsRequired();

            e.HasIndex(x => x.BrandName).IsUnique();

        });

        modelBuilder.Entity<ProductModel>(e =>
        {
            e.ToTable("TBL_INV_SYS_MODELS");
            e.HasKey(x => x.Id);

            e.Property(x => x.Id).HasColumnName("ID").ValueGeneratedNever();

            e.Property(x => x.ModelName).HasColumnName("MODEL_NAME")
            .HasMaxLength(255)
            .IsUnicode(false)
            .IsRequired();

            e.HasIndex(x => x.ModelName).IsUnique();

            e.HasOne(x => x.Category)
            .WithMany(m1 => m1.Models)
            .HasForeignKey(x => x.CategoryId);

            e.HasOne(x => x.Brand)
            .WithMany(m2 => m2.Models)
            .HasForeignKey(x => x.BrandId);

            e.HasIndex(x => new { x.BrandId, x.ModelName }).IsUnique();
        });

        modelBuilder.Entity<Product>(e =>
        {
            e.ToTable("TBL_INV_SYS_PRODUCTS");
            e.HasKey(x => x.Id);

            e.Property(x => x.Id).HasColumnName("ID").ValueGeneratedNever();

            e.Property(x => x.ProductName).HasColumnName("PRODUCT_NAME").HasMaxLength(512).IsRequired().IsUnicode(false);

            e.Property(x => x.Sku).HasColumnName("SKU").HasMaxLength(32).IsUnicode(false).IsRequired();

            e.Property(x => x.Description).HasColumnName("DESCRIPTION").HasColumnType("CLOB");

            e.HasOne(x => x.Model)
            .WithMany(p => p.Products)
            .HasForeignKey(x => x.ModelId);
        });

        modelBuilder.Entity<AttributeDefinition>(e=>
        {
            e.ToTable("TBL_INV_SYS_ATTRIBUTES");

            e.HasKey(x => x.Id);

            e.Property(x => x.Id).HasColumnName("ID").ValueGeneratedNever();

            e.Property(x => x.AttributeName).HasColumnName("ATTRIBUTE_NAME").HasMaxLength(255).IsUnicode(false).IsRequired();

            e.HasIndex(x => x.AttributeName).IsUnique();
        });

        modelBuilder.Entity<AttributeValue>(e =>
        {
            e.ToTable("TBL_INV_SYS_ATTRIBUTE_VALUES");
            e.HasKey(x => x.Id);

            e.Property(x => x.Id).HasColumnName("ID").ValueGeneratedNever();

            e.Property(x => x.Value).HasColumnName("VALUE").HasMaxLength(255).IsUnicode(false).IsRequired();
            
            e.HasOne(x => x.Attribute)
            .WithMany(av => av.AttributeValues)
            .HasForeignKey(x => x.AttributeId);

            e.HasIndex(x => new { x.AttributeId, x.Value }).IsUnique();
        });

        modelBuilder.Entity<ProductAttribute>(e =>
        {
            e.ToTable("TBL_INV_SYS_PRODUCT_ATTRIBUTES");
            e.HasKey(x => new { x.ProductId,x.AttributeValueId });

            e.Property(x => x.ProductId).HasColumnName("PRODUCT_ID").ValueGeneratedNever();
            e.Property(x => x.AttributeValueId).HasColumnName("VALUE_ID").ValueGeneratedNever();

            e.HasOne(e => e.Product)
            .WithMany(pa => pa.ProductAttributes)
            .HasForeignKey(x => x.ProductId);

            e.HasOne(e => e.AttributeValue)
            .WithMany(pav => pav.ProductAttributeValues)
            .HasForeignKey(x => x.AttributeValueId);

        });
    }
}

