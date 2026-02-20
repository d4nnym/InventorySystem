using System.Xml.Linq;

namespace InventorySystem.Domain.Entities;

public class ProductCategory
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string CategoryName { get; private set; } = default!;

    //public ICollection<Model> Models { get; set; } = new List<Model>();
    private readonly List<ProductModel> _models = new();
    public IReadOnlyCollection<ProductModel> Models => _models;
    private ProductCategory() { }

    public ProductCategory(string categoryName)
    {
        Id = Guid.NewGuid();
        Rename(categoryName);
    }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("El nombre de la Categoría es requerido", nameof(newName));

        CategoryName = newName.Trim();
    }

}
