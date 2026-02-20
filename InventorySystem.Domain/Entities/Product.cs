
namespace InventorySystem.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public Guid ModelId { get; private set; }
    public string Sku { get; private set; } = default!;
    public string ProductName { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    public ProductModel Model { get; private set; } = default!;

    private readonly List<ProductAttribute> _productAttributes = new();
    public IReadOnlyCollection<ProductAttribute> ProductAttributes => _productAttributes;

    private Product() { }

    public Product(Guid modelId, string sku, string productName, string description)
    {
        Id = Guid.NewGuid();
        ModelId = modelId;
        SetSku(sku);
        Rename(productName);
        SetDescription(description);
    }

    public void SetSku(string sku)
    {
        if (string.IsNullOrWhiteSpace(sku)) throw new ArgumentException("SKU requerido.");
        if (sku.Length > 32) throw new ArgumentException("SKU max 32.");
        Sku = sku.Trim();
    }

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Nombre de producto requerido.");
        if (name.Length > 512) throw new ArgumentException("Nombre de Producto max 512.");
        ProductName = name.Trim();
    }

    public void SetDescription(string desc)
    {
        if (string.IsNullOrWhiteSpace(desc)) throw new ArgumentException("Descripción requerida.");
        Description = desc;
    }

}
