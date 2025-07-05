using InventoryTrack.Domain.Common;

namespace InventoryTrack.Domain.UnitTests.Common;

public class BaseEntityConstructor
{
    [Fact]
    public void Given_ParameterlessConstructor_When_CreateInstance_Then_GeneratesValidIdentifier()
    {
        // Arrange (Given) (implicit)
        
        // Act (When)
        var baseEntity = new BaseEntity();
        
        // Assert (Then)
        Assert.NotEqual(baseEntity.Id, Guid.Empty);
    }
    
    [Fact]
    public void Given_ObjectInitializer_When_DefinedId_Then_IdMustBeSet()
    {
        // Arrange
        var expectedId = Guid.NewGuid();

        // Act
        var baseEntity = new BaseEntity { Id = expectedId };

        // Assert
        Assert.Equal(expectedId, baseEntity.Id);
    }
}