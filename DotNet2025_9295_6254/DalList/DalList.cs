

using DO;

using DalApi;

namespace Dal;

public class DalList : IDal

{
    private static DalList s_instance;
    public static IDal Instance => s_instance ??= new DalList();


    public ISale Sale => new SaleImplementation();
    public IProduct Product => new ProductImplementation(); 
    public ICustomer Customer => new CustomerImplementation(); 

    




}
