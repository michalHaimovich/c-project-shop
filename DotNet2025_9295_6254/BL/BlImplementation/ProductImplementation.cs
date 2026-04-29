using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DO;

namespace BlImplementation
{
    internal class ProductImplementation : BlApi.IProduct
    {
    private DalApi.IDal _dal = DalApi.Factory.Get;

  public BO.Product? Get(int id)
   {
       try
            {
    var dalProduct = _dal.Product.Read(id);
   return dalProduct?.convert();
     }
     catch (DO.DalDoesNotExistException ex)
     {
 throw new BO.BlDoesNotExistException($"Failed to get product with ID {id}: Product does not exist.", ex);
            }
  catch (Exception ex)
  {
          throw new BO.BlInvalidInputException($"Failed to get product with ID {id}: {ex.Message}", ex);
  }
        }

  public BO.Product? Get(Func<BO.Product, bool> filter)
        {
      try
  {
       var dalProducts = _dal.Product.ReadAll();
   var boProducts = dalProducts.Select(p => p.convert());
      return boProducts.FirstOrDefault(filter);
    }
   catch (Exception ex)
          {
 throw new BO.BlInvalidInputException($"Failed to get product with filter: {ex.Message}", ex);
 }
  }

  public IEnumerable<BO.Product> GetAll()
        {
  try
          {
     var dalProducts = _dal.Product.ReadAll();
   return dalProducts.Select(p => p.convert()).ToList();
     }
      catch (Exception ex)
          {
    throw new BO.BlInvalidInputException($"Failed to get all products: {ex.Message}", ex);
    }
    }

 public void Add(BO.Product product)
        {
     try
         {
        _dal.Product.Create(product.convert());
              }
 catch (DO.DalAlreadyExistsException ex)
           {
    throw new BO.BlAlreadyExistsException($"Failed to add product with ID {product.Id}: Product already exists.", ex);
}
    catch (Exception ex)
       {
       throw new BO.BlInvalidInputException($"Failed to add product with ID {product.Id}: {ex.Message}", ex);
       }
   }

        public void Update(BO.Product product)
        {
      try
  {
   _dal.Product.Update(product.convert());
  }
       catch (DO.DalDoesNotExistException ex)
      {
        throw new BO.BlDoesNotExistException($"Failed to update product with ID {product.Id}: Product does not exist.", ex);
   }
   catch (Exception ex)
         {
        throw new BO.BlInvalidInputException($"Failed to update product with ID {product.Id}: {ex.Message}", ex);
      }
  }

        public void Delete(int id)
        {
       try
 {
_dal.Product.Delete(id);
        }
   catch (DO.DalDoesNotExistException ex)
     {
  throw new BO.BlDoesNotExistException($"Failed to delete product with ID {id}: Product does not exist.", ex);
    }
           catch (Exception ex)
             {
         throw new BO.BlInvalidInputException($"Failed to delete product with ID {id}: {ex.Message}", ex);
    }
  }

        public void GetActiveSalesForProduct(BO.ProductInOrder productInOrder, bool isPreferredClient)
 {
      // Implementation for getting active sales for product
        throw new NotImplementedException();
        }
    }
}
