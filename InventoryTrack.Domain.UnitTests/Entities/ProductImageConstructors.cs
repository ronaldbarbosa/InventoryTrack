using InventoryTrack.Domain.Entities;

namespace InventoryTrack.Domain.UnitTests.Entities;

public class ProductImageConstructors
{
    [Theory]
    [InlineData("Image Name", ".png", "http://somelink.com", "07/09/2025")]
    public void Given_ValidProperties_When_CreateInstance_Then_InstanceShouldBeCreated(
        string name,
        string extension,
        string storageLink,
        string createdAt
    )
    {
        var createdAtDateTime = DateTime.Parse(createdAt);
        
        var productImage = new ProductImage(name, extension, storageLink, createdAtDateTime);
        
        Assert.Equal(name, productImage.Name);
        Assert.Equal(extension, productImage.Extension);
        Assert.Equal(storageLink, productImage.StorageLink);
        Assert.Equal(createdAtDateTime, productImage.CreatedAt);
    }
    
    [Theory]
    [InlineData("bcad5023-a009-4a76-97d6-98bcd9a5565d", "Image Name", ".png", "http://somelink.com", "07/09/2025")]
    public void Given_ValidProperties_When_CreateInstanceWithId_Then_InstanceShouldBeCreated(
        string id,
        string name,
        string extension,
        string storageLink,
        string createdAt
    )
    {
        var createdAtDateTime = DateTime.Parse(createdAt);
        var idGuid = Guid.Parse(id);
        
        var productImage = new ProductImage(idGuid, name, extension, storageLink, createdAtDateTime);
        
        Assert.Equal(idGuid, productImage.Id);
        Assert.Equal(name, productImage.Name);
        Assert.Equal(extension, productImage.Extension);
        Assert.Equal(storageLink, productImage.StorageLink);
        Assert.Equal(createdAtDateTime, productImage.CreatedAt);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Given_InvalidName_When_CreateInstance_Then_ShouldThrowArgumentException(string name)
    {
        var extension = ".png";
        var storageLink = "https://somelink.com";
        var createdAt = DateTime.Now;
        var idGuid = Guid.NewGuid();
        var expectedExceptionMessage = "Name cannot be null, empty or whitespace.";
        
        var exception = Assert.Throws<ArgumentException>(() => 
            new ProductImage(idGuid, name, extension, storageLink, createdAt));
        
        Assert.Equal(expectedExceptionMessage, exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Given_InvalidExtension_When_CreateInstance_Then_ShouldThrowArgumentException(string extension)
    {
        var name = "Image Name";
        var storageLink = "https://somelink.com";
        var createdAt = DateTime.Now;
        var idGuid = Guid.NewGuid();
        var expectedExceptionMessage = "Extension cannot be null, empty or whitespace.";
        
        var exception = Assert.Throws<ArgumentException>(() => 
            new ProductImage(idGuid, name, extension, storageLink, createdAt));
        
        Assert.Equal(expectedExceptionMessage, exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Given_InvalidStorageLink_When_CreateInstance_Then_ShouldThrowArgumentException(string storageLink)
    {
        var name = "Image Name";
        var extension = ".png";
        var createdAt = DateTime.Now;
        var idGuid = Guid.NewGuid();
        var expectedExceptionMessage = "Storage link cannot be null, empty or whitespace.";
        
        var exception = Assert.Throws<ArgumentException>(() => 
            new ProductImage(idGuid, name, extension, storageLink, createdAt));
        
        Assert.Equal(expectedExceptionMessage, exception.Message);
    }

    [Theory]
    [InlineData("0001-01-01T00:00:00Z")]
    [InlineData("2100-01-01T00:00:00Z")]
    public void Given_InvalidCreatedAt_When_CreateInstance_Then_ShouldThrowArgumentException(string createdAt)
    {
        var name = "Image Name";
        var extension = ".png";
        var storageLink = "https://somelink.com";
        var idGuid = Guid.NewGuid();
        var expectedExceptionMessage = "Created at must have a valid date.";
        var createdAtDateTime = DateTimeOffset.Parse(createdAt).DateTime;
        
        var exception = Assert.Throws<ArgumentException>(() => 
            new ProductImage(idGuid, name, extension, storageLink, createdAtDateTime));
        
        Assert.Equal(expectedExceptionMessage, exception.Message);
    }
}