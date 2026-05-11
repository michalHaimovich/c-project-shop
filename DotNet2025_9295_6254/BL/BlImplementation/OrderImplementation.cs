using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using BlApi;
using BO;

namespace BlImplementation
{
    internal class OrderImplementation : IOrder
    {
        IDal _dal = DalApi.Factory.Get;  
        public void SearchSaleForProduct(BO.ProductInOrder productInOrder, bool isClubMember)
        {
            var relevantSales = _dal.Sale.ReadAll(sale =>
                sale.product_id == productInOrder.ProductId &&
                sale.start_date <= DateTime.Now && sale.end_date >= DateTime.Now &&
                productInOrder.Quantity_in_order >= sale.amount_to_sale &&
                sale.count_to_sale > 0 &&
                (isClubMember ||  !sale.to_club ));

            productInOrder.Sales = relevantSales.OrderBy(sale => sale.amount_to_sale).Select(sale => sale.convert()).Select(s=> new SaleInProduct() { IsForAllClients = !s.to_club ,Price_per_one = s.cost_per_one, Amount_to_sale = s.amount_to_sale , SaleId = s.Id }).ToList();
        }

        public void CalcTotalPriceForProduct(BO.ProductInOrder productInOrder)
        {
            int remainingQuantity = productInOrder.Quantity_in_order; 
            double totalPrice = 0;                          
            List<BO.SaleInProduct> appliedSales = [];       

            if (productInOrder.Sales != null)
            {
                foreach (var sale in productInOrder.Sales)
                {
                    if (remainingQuantity < sale.Amount_to_sale)
                    {
                        continue;
                    }

                    int timesUsed = remainingQuantity / sale.Amount_to_sale;

                    totalPrice += timesUsed * sale.Amount_to_sale * sale.Price_per_one;

                    remainingQuantity -= timesUsed * sale.Amount_to_sale;

                    appliedSales.Add(sale);

                    if (remainingQuantity == 0)
                    {
                        break;
                    }
                }
            }

            totalPrice += remainingQuantity * productInOrder.BasePrice;

            productInOrder.FinalPrice_in_total = totalPrice;
            productInOrder.Sales = appliedSales;
        }
       
        public void CalcTotalPrice(Order order)
        {
            order.FinalPrice = order.Products.Select(product => { CalcTotalPriceForProduct(product); return product.FinalPrice_in_total; }).Sum();
        }

        public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int quantityToAdd)
    {
         var doProduct = _dal.Product.Read(productId);
      if (doProduct == null)
            {
                throw new BlDoesNotExistException($"Product with ID {productId} does not exist.");
            }

      var productInOrder = order.Products.FirstOrDefault(p => p.ProductId == productId);

            if (productInOrder != null)
        {
         int newQuantity = productInOrder.Quantity_in_order + quantityToAdd;

      if (newQuantity <= 0)
           {
    order.Products.Remove(productInOrder);
             CalcTotalPrice(order); 
              return new List<BO.SaleInProduct>();
                }
                if (doProduct.amount_in_stock < newQuantity)
     {
      throw new BlNotInStockException($"Not enough stock. Requested: {newQuantity}, Available: {doProduct.amount_in_stock}");
                }

     productInOrder.Quantity_in_order = newQuantity;
            }
         else
          {
          if (quantityToAdd <= 0)
                {
      throw new BlInvalidInputException("Cannot add a new product with zero or negative quantity.");
       }

        if (doProduct.amount_in_stock < quantityToAdd)
                {
     throw new BlNotInStockException($"Not enough stock. Requested: {quantityToAdd}, Available: {doProduct.amount_in_stock}");
      
    }

 productInOrder = new BO.ProductInOrder
         {
      ProductId = doProduct.id,
       Name = doProduct.product_name,
   BasePrice = doProduct.price,
           Quantity_in_order = quantityToAdd,
   Sales = new List<BO.SaleInProduct>()
     };

          order.Products.Add(productInOrder);
            }

          SearchSaleForProduct(productInOrder, order.IsPreferredClient);
            
         CalcTotalPriceForProduct(productInOrder);
        
         CalcTotalPrice(order);

     return productInOrder.Sales;
        }
        
        public void DoOrder(BO.Order order)
        {
            foreach (var productInOrder in order.Products)
            {
                var doProduct = _dal.Product.Read(productInOrder.ProductId);

                if (doProduct == null)
                {
                    throw new BlDoesNotExistException($"Product with ID {productInOrder.ProductId} does not exist in the database.");
                }

                if (doProduct.amount_in_stock < productInOrder.Quantity_in_order)
                {
                    throw new BlNotInStockException($"Cannot complete order. Not enough stock for product '{doProduct.product_name}'.");
                }

              if (productInOrder.Sales != null && productInOrder.Sales.Count > 0)
              {
                int remainingQuantityForSales = productInOrder.Quantity_in_order;
                foreach (var appliedSale in productInOrder.Sales)
                {
                    if (remainingQuantityForSales < appliedSale.Amount_to_sale)
                        continue;

                    int timesUsed = remainingQuantityForSales / appliedSale.Amount_to_sale;
                    if (timesUsed <= 0)
                        continue;

                    
                    remainingQuantityForSales -= timesUsed * appliedSale.Amount_to_sale;
                    if (remainingQuantityForSales <= 0)
                        break;
              }
            }

            _dal.Product.Update(doProduct with { amount_in_stock = doProduct.amount_in_stock - productInOrder.Quantity_in_order });
            }

        }

    }
}
