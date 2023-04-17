using System.Linq;

namespace OnlineOrdersManagement.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Items { get; }

        T Add(T item);

        void Update(T item, int id);

        void Delete(T item);
    }
}