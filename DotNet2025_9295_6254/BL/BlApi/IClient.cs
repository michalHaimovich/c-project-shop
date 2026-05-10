using BO;
namespace BlApi;

public interface IClient : Icrud<Client>
{
    bool Exists(int id);

}






