using AppDistribuidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDistribuidor.Services
{
    public class MockDataStorePrestamo : IDataSotrePrestamo<ProductoPrestamo>
    {
        readonly List<ProductoPrestamo> productos;

        public MockDataStorePrestamo()
        {
            productos = new List<ProductoPrestamo>();
        }


        public async Task<bool> AddProductoAsync(ProductoPrestamo producto)
        {
            productos.Add(producto);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateProductoAsync(ProductoPrestamo producto)
        {
            var oldItem = productos.Where((ProductoPrestamo arg) => arg.IdProducto == producto.IdProducto).FirstOrDefault();
            productos.Remove(oldItem);
            productos.Add(producto);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            var oldItem = productos.Where((ProductoPrestamo arg) => arg.IdProducto == id).FirstOrDefault();
            productos.Remove(oldItem);
           
            return await Task.FromResult(true);
        }

        public async Task<ProductoPrestamo> GetProductoAsync(int id)
        {
            return await Task.FromResult(productos.FirstOrDefault(s => s.IdProducto == id));
        }

        public async Task<IEnumerable<ProductoPrestamo>> GetProductosAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(productos);
        }
        public async Task<IEnumerable<ProductoPrestamo>> BorrarProductosAsync(bool forceRefresh = false)
        {
            productos.Clear();
            return await Task.FromResult(productos);
        }
    }
}
