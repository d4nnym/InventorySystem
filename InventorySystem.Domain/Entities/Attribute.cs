namespace InventorySystem.Domain.Entities;

public class Attribute
{
    public Guid Id { get; private set; }
    public string AttributeName { get; private set; } = default!;

    private readonly List<AttributeValue> _attributeValues = new();

    public IReadOnlyCollection<AttributeValue> AttributeValues => _attributeValues;

    public Attribute() { }

    public Attribute(string attributeName)
    {
        Id = Guid.NewGuid();
        Rename(attributeName);
    }

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("AttributeName requerido.");
        if (name.Length > 128) throw new ArgumentException("AttributeName max 128.");
        AttributeName = name.Trim();
    }

}