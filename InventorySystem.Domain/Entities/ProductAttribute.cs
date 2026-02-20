namespace InventorySystem.Domain.Entities;

public class ProductAttribute
{
    public Guid ProductId { get; private set; }

    public Guid AttributeValueId { get; private set; }

    public Product Product { get; private set; } = default!;
    public AttributeValue AttributeValue { get; private set; } = default!;
    public ProductAttribute() { }

    public ProductAttribute(Guid productId, Guid attributeValueId)
    {
        ProductId = productId;
        AttributeValueId = attributeValueId;
    }


}

