

namespace DalApi;

public  interface IDal
{
    public ISale Sale { get; }
    public IProduct Product { get; }
    public ICustomer Customer { get; }
}
