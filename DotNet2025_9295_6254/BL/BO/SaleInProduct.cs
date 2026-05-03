namespace BO;

public class SaleInProduct
{
    public int SaleId { get; init; }
    public int Amount_to_sale { get; init; }
    public double Price_per_one { get; init; }
    public bool IsForAllClients { get; init; }
    public override string ToString() => this.ToStringProperty();

}
