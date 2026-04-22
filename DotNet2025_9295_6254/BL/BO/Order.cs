using System.Collections.Generic;

namespace BO;

public class Order
{
    public bool IsPreferredClient { get; init; }
    public List<ProductInOrder> Products { get; init; } = [];
    public double FinalPrice { get; set; }
    public override string ToString() => this.ToStringProperty();

}
