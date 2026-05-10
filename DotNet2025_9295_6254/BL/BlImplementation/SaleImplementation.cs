using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class SaleImplementation : BlApi.ISale
    {
            private DalApi.IDal _dal = DalApi.Factory.Get;
            
   public int Create(BO.Sale sale)
            {
          try
            {
              return _dal.Sale.Create(sale.convert());
         }
      catch (DO.DalAlreadyExistsException ex)
                {
             throw new BO.BlAlreadyExistsException($"Failed to add sale with ID {sale.Id}: Sale already exists.", ex);
                }
                catch (Exception ex)
                {
            throw new BO.BlInvalidInputException($"Failed to add sale with ID {sale.Id}: {ex.Message}", ex);
     }
            }
    
            public void Delete(int id)
            {
    try
     {
                 _dal.Sale.Delete(id);
                }
       catch (DO.DalDoesNotExistException ex)
                {
        throw new BO.BlDoesNotExistException($"Failed to delete sale with ID {id}: Sale does not exist.", ex);
      }
         catch (Exception ex)
                {
      throw new BO.BlInvalidInputException($"Failed to delete sale with ID {id}: {ex.Message}", ex);
           }
            }
    
            public BO.Sale? Get(int id)
     {
            try
                {
         var dalSale = _dal.Sale.Read(id);
         return dalSale?.convert();
                }
                catch (DO.DalDoesNotExistException ex)
     {
                  throw new BO.BlDoesNotExistException($"Failed to get sale with ID {id}: Sale does not exist.", ex);
                }
                catch (Exception ex)
             {
              throw new BO.BlInvalidInputException($"Failed to get sale with ID {id}: {ex.Message}", ex);
     }
        }
          public BO.Sale? Get(Func<BO.Sale, bool> filter)
        {
            try
            {
                var dalSales = _dal.Sale.ReadAll();
                var boSales = dalSales.Select(s => s.convert());
                return boSales.FirstOrDefault(filter);
            }
            catch (Exception ex)
            {
                throw new BO.BlInvalidInputException($"Failed to get sale with filter: {ex.Message}", ex);
            }
        }
            public IEnumerable<BO.Sale> GetAll(Func<BO.Sale, bool> filter)
          {
      try
          {
                    var dalSales = _dal.Sale.ReadAll();
                  if (filter == null)
                      return dalSales.Select(s => s.convert()).ToList();
                  return dalSales.Select(s => s.convert()).Where(filter).ToList();
     }
            catch (Exception ex)
             {
               throw new BO.BlInvalidInputException($"Failed to get all sales: {ex.Message}", ex);
         }
     }

       public void Update(BO.Sale sale)
     {
     try
      {
         _dal.Sale.Update(sale.convert());
    }
                catch (DO.DalDoesNotExistException ex)
    {
         throw new BO.BlDoesNotExistException($"Failed to update sale with ID {sale.Id}: Sale does not exist.", ex);
}
          catch (Exception ex)
    {
                    throw new BO.BlInvalidInputException($"Failed to update sale with ID {sale.Id}: {ex.Message}", ex);
             }
        }
    }
}
