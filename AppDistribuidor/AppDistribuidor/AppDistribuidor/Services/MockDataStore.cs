using AppDistribuidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDistribuidor.Services
{
    public class MockDataStore : IDataStore<ProductoVenta>
    {
        //readonly List<Item> items;
        readonly List<ProductoVenta> productos;

        public MockDataStore()
        {
            //items = new List<Item>();
            productos = new List<ProductoVenta>();

        }

      
        public async Task<bool> AddProductoAsync(ProductoVenta producto)
        {
            productos.Add(producto);
            //VariablesGlobales.Total += producto.Precio;
             
            return await Task.FromResult(true);
        }
       
        public async Task<bool> UpdateProductoAsync(ProductoVenta producto)
        {
            var oldItem = productos.Where((ProductoVenta arg) => arg.IdProducto == producto.IdProducto).FirstOrDefault();
            productos.Remove(oldItem);
            productos.Add(producto);

            return await Task.FromResult(true);
        }
     
        public async Task<bool> DeleteProductoAsync(int id)
        {
            var oldItem = productos.Where((ProductoVenta arg) => arg.IdProducto ==  id).FirstOrDefault();
            productos.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ProductoVenta> GetProductoAsync(int id)
        {
            return await Task.FromResult(productos.FirstOrDefault(s => s.IdProducto == id));
        }

        public async Task<IEnumerable<ProductoVenta>> GetProductosAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(productos);
        }
        public async Task<IEnumerable<ProductoVenta>> BorrarProductosAsync(bool forceRefresh = false)
        {
            productos.Clear();
            return await Task.FromResult(productos);
        }


        //public async Task<bool> AddItemAsync(Item item)
        //{
        //    items.Add(item);

        //    return await Task.FromResult(true);
        //}
        //public async Task<bool> UpdateItemAsync(Item item)
        //{
        //    var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
        //    items.Remove(oldItem);
        //    items.Add(item);

        //    return await Task.FromResult(true);
        //}
        //public async Task<bool> DeleteItemAsync(string id)
        //{
        //    var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
        //    items.Remove(oldItem);

        //    return await Task.FromResult(true);
        //}
        //public async Task<Item> GetItemAsync(string id)
        //{
        //    return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        //}

        //public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        //{
        //    return await Task.FromResult(items);
        //}
    }
}