namespace BlApi;

public interface IProduct
{
    // DAL methods (example signatures)
    BO.Product? Get(int id);
    IEnumerable<BO.Product> GetAll();
    void Add(BO.Product product);
    void Update(BO.Product product);
    void Delete(int id);

    // Additional method
    void GetActiveSalesForProduct(BO.ProductInOrder productInOrder, bool isPreferredClient);
}
