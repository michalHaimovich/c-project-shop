namespace BO;

public class Client
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Phone { get; init; }
    public string? Address { get; init; }

    public bool IsClubMember { get; set; }
    public override string ToString() => this.ToStringProperty();



}
