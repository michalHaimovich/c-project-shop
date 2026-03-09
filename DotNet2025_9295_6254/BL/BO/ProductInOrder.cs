using System.Collections.Generic;

namespace BO;

public class ProductInOrder
{
    public int ProductId { get; init; }
    public string Name { get; init; } = string.Empty;
    public double BasePrice { get; init; }
    public int Quantity { get; init; }
    public List<SaleInProduct> Sales { get; init; } = [];
    public double FinalPrice { get; init; }
}
