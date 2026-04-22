using System.Runtime;

namespace BO;

public class Sale
{
    public int Id { get; init; }
    public int ProductId { get; init; }
    public int amount { get; init; }
    public int count_to_sale { get; init; }
    public bool to_club { get; init; }
    public DateTime start_date { get; set; }
    public DateTime end_date { get; set; }
    public override string ToString() => this.ToStringProperty();


}
