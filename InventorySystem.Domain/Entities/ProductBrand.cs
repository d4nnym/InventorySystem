

namespace InventorySystem.Domain.Entities;

public class ProductBrand
{
    public Guid Id { get; private set; }

    public string BrandName { get; private set; } = default!;
    
    private readonly List<ProductModel> _models = new();
    public IReadOnlyCollection<ProductModel> Models => _models;
    private ProductBrand() { }
    public ProductBrand(string brandName)
    {
        Id = Guid.NewGuid();
        Rename(brandName);
    }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("El nombre de la Marca es requerido", nameof(newName));
        BrandName = newName.Trim();
    }
}
