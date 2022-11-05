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
        public List<ProductoVenta> productos;
        public List<ProductoVenta> productosTemp;
        public MockDataStore()
        {
            //items = new List<Item>();
            productos = new List<ProductoVenta>();
            productosTemp = new List<ProductoVenta>();
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
     
        public async Task<bool> DeleteProductoAsync(int id,decimal precio)
        {
            //var oldItem = productos.Where((ProductoVenta arg) => arg.IdProducto == id).FirstOrDefault();
            var oldItem = productos.FindAll((ProductoVenta pro) => pro.IdProducto == id && pro.Precio== precio);
            foreach (var item in oldItem)
            {
                productos.Remove(item);
            }

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


    }
}