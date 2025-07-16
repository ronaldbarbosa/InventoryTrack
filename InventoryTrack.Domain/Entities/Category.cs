using InventoryTrack.Domain.Common;

namespace InventoryTrack.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; }

    public Category(string name)
    {
        Validate(name);
        Name = name;
    }

    public Category(Guid id, string name)
    {
        Validate(name);
        Id = id;
        Name = name;
    }

    private static void Validate(string name)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null, empty or whitespace.");
        }
    }
}