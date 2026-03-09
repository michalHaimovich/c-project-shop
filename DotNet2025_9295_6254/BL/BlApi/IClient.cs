using BO;
namespace BlApi;

public interface IClient
{
    // DAL methods (example signatures)
    Client? Get(int id);
    Client? Read(Func<T, bool> filter);
    IEnumerable<Client> GetAll();
    void Create(Client client);
    void Update(Client client);
    void Delete(int id);

    // Additional method
    bool Exists(int id);
}






