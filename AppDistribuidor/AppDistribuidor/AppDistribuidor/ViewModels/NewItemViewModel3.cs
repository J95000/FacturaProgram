using AppDistribuidor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDistribuidor.ViewModels
{

    public class NewItemViewModel3 : BaseViewModel
    {
        private string cantidad;
        private string precio;
        private string gasto;
        //private string idProdu;

        public NewItemViewModel3()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(precio)
                && !String.IsNullOrWhiteSpace(gasto)
                && !String.IsNullOrWhiteSpace(Cantidad);
        }

        public string Precio
        {
            get => precio;
            set => SetProperty(ref precio, value);
        }
        //public string IdProdu
        //{
        //    get => idProdu;
        //    set => SetProperty(ref idProdu, value);
        //}

        public string Gasto
        {
            get => gasto;
            set => SetProperty(ref gasto, value);
        }
        public string Cantidad
        {
            get => cantidad;
            set => SetProperty(ref cantidad, value);
        }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
         
        private async void OnSave()
        {
            int conti = VariablesGlobales.Conta + 1;


            Item newItem = new Item()
            {
                Id = "1",
                Precio = Precio,
                Cantidad = Cantidad,
                Text = conti + ".- " + Gasto,
                Description = "     Cantidad: " + Cantidad + "    Precio: " + Precio + " Bs."
            };
            
            //await DataStore.AddItemAsync(newItem);
            VariablesGlobales.Conta = conti;
            
            await Shell.Current.GoToAsync("..");
        }
    }
}
