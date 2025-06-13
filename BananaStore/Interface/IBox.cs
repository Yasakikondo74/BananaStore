using BananaStore.Models;

namespace BananaStore.Interface
{
    public interface IBox
    {
        Task<IEnumerable<Box>> List();
        Task<IEnumerable<Box>> List_v2();
        Task<IEnumerable<Box>> Get(Guid id);
        Task Create(Box box);
        Task Update(Box box, Guid id);
        Task Delete(Guid id);
    }
}
