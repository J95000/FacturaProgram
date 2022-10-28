using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppDistribuidor.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddProductoAsync(T producto);
        Task<bool> UpdateProductoAsync(T producto);
        Task<bool> DeleteProductoAsync(int id);
        Task<T> GetProductoAsync(int id);
        Task<IEnumerable<T>> GetProductosAsync(bool forceRefresh = false);

        Task<IEnumerable<T>> BorrarProductosAsync(bool forceRefresh = false);
    }
}
