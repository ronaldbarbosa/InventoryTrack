using InventoryTrack.Domain.Common;

namespace InventoryTrack.Domain.Entities;

public class ProductImage : BaseEntity
{
    public string Name { get; set; }
    public string Extension { get; set; } 
    public string StorageLink { get; set; } 
    public DateTime CreatedAt { get; set; }

    public ProductImage(string name, string extension, string storageLink, DateTime createdAt)
    {
        Validate(name, extension, storageLink, createdAt);
        
        Name = name;
        Extension = extension;
        StorageLink = storageLink;
        CreatedAt = createdAt;
    }
    
    public ProductImage(Guid id, string name, string extension, string storageLink, DateTime createdAt)
    {
        Validate(name, extension, storageLink, createdAt);
        
        Id = id;
        Name = name;
        Extension = extension;
        StorageLink = storageLink;
        CreatedAt = createdAt;
    }

    private static void Validate(string name, string extension, string storageLink, DateTime createdAt)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null, empty or whitespace.");
        }
        
        if (string.IsNullOrEmpty(extension) || string.IsNullOrWhiteSpace(extension))
        {
            throw new ArgumentException("Extension cannot be null, empty or whitespace.");
        }
        
        if (string.IsNullOrEmpty(storageLink) || string.IsNullOrWhiteSpace(storageLink))
        {
            throw new ArgumentException("Storage link cannot be null, empty or whitespace.");
        }

        if (createdAt == default(DateTime) || createdAt > DateTime.Now)
        {
            throw new ArgumentException("Created at must have a valid date.");
        }
    }
}