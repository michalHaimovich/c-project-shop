using DO;

namespace BlApi;

public interface ISale
{
    // DAL methods (example signatures)
    BO.Sale? Get(int id);
   
    IEnumerable<BO.Sale> GetAll();
    void Add(BO.Sale sale);
    void Update(BO.Sale sale);
    void Delete(int id);
}
