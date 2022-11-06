using AppDistribuidor.Models;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDistribuidor.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string cantidad;
        private string precio;
        private string producto;
        private string idProdu;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            VenderCommand = new Command(GenerarVenta);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(precio)
                && !String.IsNullOrWhiteSpace(producto) 
                && !String.IsNullOrWhiteSpace(Cantidad);
        }

        public string Precio
        {
            get => precio;
            set => SetProperty(ref precio, value);
        }
        public string IdProdu
        { 
            get => idProdu;
            set => SetProperty(ref idProdu, value);
        }

        public string Producto
        {
            get => producto;
            set => SetProperty(ref producto, value);
        }
        public string Cantidad
        {
            get => cantidad;
            set => SetProperty(ref cantidad, value);
        }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command VenderCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        private async void GenerarVenta()
        {
            await Shell.Current.GoToAsync("..");
        }
        private async void OnSave()
        {
            if (isInt32(Cantidad))
            {
                int conti = VariablesGlobales.Conta + 1;


                ProductoVenta newItem = new ProductoVenta()
                {
                    IdProducto = int.Parse(IdProdu),
                    NombreProducto = producto,
                    Precio = decimal.Parse(Precio),
                    Cantidad = byte.Parse(Cantidad),
                };
                VariablesGlobales.Conta = conti;
                VariablesGlobales.Total += decimal.Parse(Precio) * byte.Parse(Cantidad);
                await DataStore.AddProductoAsync(newItem);
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("Cantidad no valida ");
            }
           // This will pop the current page off the navigation stack
          // await Shell.Current.GoToAsync("..");
        }

        public bool isInt32(String num)
        {
            try
            {
                Int32.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
