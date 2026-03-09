using System.Collections.Generic;

namespace BO;

public class Product
{
    public int Id { get; set; }
    public  ElectricalApplianceCategory category { get; set; } = string.Empty;
    public int Price { get; set; }
    public int Stock { get; set; }
    public List<SaleInProduct> Sales { get; set; } = [];
}
