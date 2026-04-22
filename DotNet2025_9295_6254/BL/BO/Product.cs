using System.Collections.Generic;

namespace BO;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public  ElectricalApplianceCategory category { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
    public List<SaleInProduct> Sales { get; set; } = [];
    public override string ToString() => this.ToStringProperty();

}
