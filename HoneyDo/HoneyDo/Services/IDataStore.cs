using System.Collections.Generic;
using System.Threading.Tasks;

namespace HoneyDo.Services
{
    public interface IDataStore<T>
    {
        void Initialize();
        Task<List<T>> GetItemsAsync();
        Task<T> GetItemAsync(int id);
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
    }
}
