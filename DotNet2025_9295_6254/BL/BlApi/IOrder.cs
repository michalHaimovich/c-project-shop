using System.Collections.Generic;

namespace BlApi;

public interface IOrder
{
    List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int quantity);
    void CalcTotalPriceForProduct(BO.ProductInOrder productInOrder);
    void CalcTotalPrice(BO.Order order);
    void DoOrder(BO.Order order);
    void SearchSaleForProduct(BO.ProductInOrder productInOrder, bool isPreferredClient);
}
