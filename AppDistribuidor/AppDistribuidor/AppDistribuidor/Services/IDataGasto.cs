using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppDistribuidor.Services
{
    public interface IDataGasto<T>
    {
        Task<bool> AddItemAsync(T gasto);
        Task<bool> UpdateItemAsync(T gasto);
        Task<bool> DeleteItemAsync(int id);
        Task<bool> VolverLlenarAsync();
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

    }
}
