using InventoryTrack.Domain.Entities;

namespace InventoryTrack.Domain.UnitTests.Entities;

public class CategoryConstructors
{
    [Theory]
    [InlineData("bcad5023-a009-4a76-97d6-98bcd9a5565d", "Test Category")]
    public void Given_IdAndName_When_CreateInstance_Then_InstanceShouldBeCreated(string id, string name)
    {
        var categoryId = Guid.Parse(id);
        
        var category = new Category(categoryId, name);
        
        Assert.NotNull(category);
        Assert.Equal(categoryId, category.Id);
        Assert.Equal(name, category.Name);
    }
    
    [Theory]
    [InlineData("Test Category")]
    public void Given_Name_When_CreateInstance_Then_InstanceShouldBeCreatedWithNewId(string name)
    {
        var category = new Category(name);
        
        Assert.NotNull(category);
        Assert.NotEqual(category.Id, Guid.Empty);
        Assert.Equal(name, category.Name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Given_NullOrEmptyName_When_CreateInstance_Then_ShouldThrowArgumentException(string name)
    {
        const string expectedExceptionMessage = "Name cannot be null, empty or whitespace.";
        
        var exception = Assert.Throws<ArgumentException>(() => new Category(name));

        Assert.Equal(expectedExceptionMessage, exception.Message);
    }
}