using AppDistribuidor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDistribuidor.ViewModels
{
    public class NewItemViewModel2 : BaseViewModelPrestamo
    {
        private string cantidad;
        private string precio;
        private string producto;
        private string idProdu;

        public NewItemViewModel2()
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
            //Realizar Venta


            await Shell.Current.GoToAsync("..");
        }
        private async void OnSave()
        {
            int conti = VariablesGlobales.Conta + 1;


            ProductoPrestamo newItem = new ProductoPrestamo()
            {
                IdProducto = int.Parse(IdProdu),
                NombreProducto = producto,
                Precio = decimal.Parse(Precio),
                Cantidad = byte.Parse(Cantidad),
            };
            VariablesGlobales.Conta = conti;
            VariablesGlobales.TotalPrestamo += decimal.Parse(Precio) * byte.Parse(Cantidad);
            await DataStorePrestamos.AddProductoAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
