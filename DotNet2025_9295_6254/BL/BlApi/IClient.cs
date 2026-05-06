using BO;
namespace BlApi;

public interface IClient
{
    Client? Get(int id);
    Client? Read(Func<Client, bool> filter);
    IEnumerable<Client> GetAll();
    void Create(Client client);
    void Update(Client client);
    void Delete(int id);
    bool Exists(int id);
    IEnumerable<Client> GetAll(Func<Client, bool> filter);
}






