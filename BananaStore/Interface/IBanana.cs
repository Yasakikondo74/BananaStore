using BananaStore.Models;

namespace BananaStore.Interface
{
    public interface IBanana
    {
        Task<IEnumerable<Banana>> List();
        Task<IEnumerable<Banana>> Get(Guid id);
        Task Create(Banana banana);
        Task Update(Banana banana, Guid id);
        Task Delete(Guid id);
    }
}
