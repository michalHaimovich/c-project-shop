namespace BO;

public class SaleInProduct
{
    public int SaleId { get; init; }
    public int Quantity { get; init; }
    public double Price { get; init; }
    public bool IsForAllClients { get; init; }
    public override string ToString() => this.ToStringProperty();

}
