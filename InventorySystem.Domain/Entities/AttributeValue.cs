namespace InventorySystem.Domain.Entities;

public class AttributeValue
{
    public Guid Id { get; set; }
    public Guid AttributeId { get; set; }
    public string Value { get; set; } = default!;
    public Attribute Attribute { get; set; } = default!;

    private readonly List<ProductAttribute> _productAttribute = new();
    public IReadOnlyCollection<ProductAttribute> ProductAttributeValues => _productAttribute;
    /*public IReadOnlyCollection<ProductAttribute> ProductAttributeValues => _productAttribute.AsReadOnly();
     No utilizar AsReadOnly() si no es necesario, ya que IReadOnlyCollection<T> ya proporciona una interfaz de solo lectura. 
    Asimismo, el uso de AsReadOnly() puede generar una sobrecarga adicional innecesaria
     */

    public AttributeValue() { }

    public AttributeValue(Guid attributeId, string value)
    {
        Id = Guid.NewGuid();
        AttributeId = attributeId;
        SetValue(value);
        
    }

    public void SetValue(string value)
    {
        /*if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        }*/
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Value requerido.");
        if (value.Length > 256) throw new ArgumentException("Value max 256.");
        Value = value.Trim();
    }

}
