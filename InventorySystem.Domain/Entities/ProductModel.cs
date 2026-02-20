

namespace InventorySystem.Domain.Entities;

public class ProductModel
{
    public Guid Id { get; private set; } 
    public Guid BrandId { get; private set; }
    public Guid CategoryId { get; private set; }
    public ProductBrand Brand { get; private set; } = default!;
    public ProductCategory Category { get; private set; } = default!;
    public string ModelName { get; private set; } = default!;

    private readonly List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products;

    private ProductModel() { }

    public ProductModel(Guid categoryId, Guid  brandId,string modelName)
    {
        Id = Guid.NewGuid();
        BrandId = brandId;
        CategoryId = categoryId;
        Rename(modelName);
    }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("El nombre del Modelo es requerido", nameof(newName));
        ModelName = newName.Trim();
    }

}
