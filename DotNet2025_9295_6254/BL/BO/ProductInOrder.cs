using System.Collections.Generic;

namespace BO;

public class ProductInOrder
{
    public int ProductId { get; init; }
    public string Name { get; init; } = string.Empty;
    public double BasePrice { get; init; }
    public int Quantity { get; set; }
    public List<SaleInProduct> Sales { get; set; } = new();
    public double FinalPrice { get; set; }
    public override string ToString() => this.ToStringProperty();

}
