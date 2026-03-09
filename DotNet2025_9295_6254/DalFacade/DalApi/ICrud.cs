
namespace DalApi
{
    public interface ICrud<T>
    {
        T Read(int id);

        T Read(Func<T , bool> filter);

        List<T> ReadAll(Func<T,bool>? filter =null);

        int Create(T item);

        void Update(T item);

        void Delete(int id);
    
    }
}
