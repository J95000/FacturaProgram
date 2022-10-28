using AppDistribuidor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppDistribuidor.Services
{
    public class MockDataGasto : IDataGasto<EGasto>
    {
        readonly List<EGasto> gastos = new List<EGasto>();
        EGasto gasto;
        public MockDataGasto()
        {

            Llenar();

        }
        public static async Task<List<EGasto>> Obtener_Gasto_Id_Usuario_Fecha(string idUsuario)
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Gasto_Id_Usuario_Fecha" + "/" + idUsuario);
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            List<EGasto> eUsuarioCompleja = JsonConvert.DeserializeObject<List<EGasto>>(data);
            return eUsuarioCompleja;

        }
        public void Llenar()
        {

            try
            {

                //VERIFICAR INTERNET


                List<EGasto> gastoss = Task.Run(() => Obtener_Gasto_Id_Usuario_Fecha(VariablesGlobales.IdUsuario.ToString())).GetAwaiter().GetResult();

                gastos.Clear();
                foreach (EGasto eEGasto in gastoss)
                {

                    gasto = new EGasto()
                    {
                        
                        Cantidad = eEGasto.Cantidad,
                        Cont = eEGasto.Cont,
                        Estado = eEGasto.Estado,
                        FechaModificacion = eEGasto.FechaModificacion,
                        FechaRegistro = eEGasto.FechaRegistro,
                        IdAprovador = eEGasto.IdAprovador,
                        IdGasto = eEGasto.IdGasto,
                        IdTipoGasto = eEGasto.IdTipoGasto,
                        IdUsuario = eEGasto.IdUsuario,
                         NombreTipoGasto = eEGasto.NombreTipoGasto,
                        Precio = eEGasto.Precio


                    };
                    gastos.Add(gasto);
                    //VariablesGlobales.Conta = EGasto.Cont;
                }
            }
            catch (Exception)
            {
                //CAPTURAR EX

            }
           


        }
        public async Task<bool> AddItemAsync(EGasto item)
        {
            // SWNegocioAquacorp.SWNegocioAquacorpClient client = new SWNegocioAquacorp.SWNegocioAquacorpClient();
            gastos.Add(item);
            // client.Insertar_Existencia(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(EGasto item)
        {
            var oldItem = gastos.Where((EGasto arg) => arg.IdGasto == item.IdGasto).FirstOrDefault();
            gastos.Remove(oldItem);
            gastos.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = gastos.Where((EGasto arg) => arg.IdGasto == id).FirstOrDefault();
            gastos.Remove(oldItem);
            Llenar();
            return await Task.FromResult(true);
        }

        public async Task<bool> VolverLlenarAsync()
        {
            Llenar();
            return await Task.FromResult(true);
        }

        public static async Task<EGasto> Obtener_Gasto_Id_Gasto(string IdGasto)
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Gasto_Id_Gasto" + "/" + IdGasto);
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            EGasto eExistenciaCortaCompleja = JsonConvert.DeserializeObject<EGasto>(data);
            return eExistenciaCortaCompleja;

        }
        public async Task<EGasto> GetItemAsync(int id)
        {
             EGasto eExistenciaCortaCompleja = Task.Run(() => Obtener_Gasto_Id_Gasto(id.ToString())).GetAwaiter().GetResult();
             
            await Task.Delay(10);
         
            EGasto eGasto = new EGasto() {
                Cantidad = eExistenciaCortaCompleja.Cantidad,
                Cont = eExistenciaCortaCompleja.Cont,
                Estado = eExistenciaCortaCompleja.Estado,
                FechaModificacion = eExistenciaCortaCompleja.FechaModificacion,
                FechaRegistro = eExistenciaCortaCompleja.FechaRegistro,
                IdAprovador = eExistenciaCortaCompleja.IdAprovador,
                IdGasto = eExistenciaCortaCompleja.IdGasto,
                IdTipoGasto = eExistenciaCortaCompleja.IdTipoGasto,
                IdUsuario = eExistenciaCortaCompleja.IdUsuario,
                NombreTipoGasto = eExistenciaCortaCompleja.NombreTipoGasto,
                Precio = eExistenciaCortaCompleja.Precio
            };


            return eGasto;
        }

        public async Task<IEnumerable<EGasto>> GetItemsAsync(bool forceRefresh = false)
        {
            //Llenar();
            return await Task.FromResult(gastos);
        }




    }
}
