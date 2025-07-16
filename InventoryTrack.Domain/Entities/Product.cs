using InventoryTrack.Domain.Common;

namespace InventoryTrack.Domain.Entities;

public class Product : BaseEntity
{
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public int MinimumStockQuantity { get; set; }
    public string BarCode { get; set; }
}