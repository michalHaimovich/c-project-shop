using BO;
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
             public void Add(BO.Sale sale)
            {
                 try
                {
                     _dal.Sale.Create(sale.convert());
                }
                catch (Exception ex)
                {
                    //throw new BO.BlException($"Failed to create sale: {ex.Message}");
                }
            }
    
            public void Delete(int id)
            {
                 try { 
                    _dal.Sale.Delete(id);
                 }
                catch (Exception ex)
                {
                    //throw new BO.BlException($"Failed to delete sale with ID {id}: {ex.Message}");
                }
            }
    
            public BO.Sale? Get(int id)
            {
                try { 
                    var dalSale = _dal.Sale.Read(id);
                    return dalSale?.convert();
                }
                 catch (Exception ex)
                {
                    //throw new BO.BlException($"Failed to get sale with ID {id}: {ex.Message}");
                    return null;
                }
            }

            public IEnumerable<BO.Sale> GetAll()
            {
            try
            {
                var dalSales = _dal.Sale.ReadAll();
                return dalSales.Select(s => s.convert()).ToList();

            }
            catch (Exception ex)
            {
                //throw new BO.BlException($"Failed to get all sales: {ex.Message}");
                return Enumerable.Empty<BO.Sale>();
                }
        }

    
            public void Update(BO.Sale sale)
            {
            try
            {
                _dal.Sale.Update(sale.convert);
            }
            catch(Execution ex)
            { }
            }
    }
}
