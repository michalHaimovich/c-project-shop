namespace BlApi;

public interface IProduct : Icrud<BO.Product>
{
    void GetActiveSalesForProduct(BO.ProductInOrder productInOrder, bool isPreferredClient);
}
