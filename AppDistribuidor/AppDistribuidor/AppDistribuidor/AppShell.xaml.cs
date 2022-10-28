using AppDistribuidor.ViewModels;
using AppDistribuidor.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppDistribuidor
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(NewItemPage2), typeof(NewItemPage2));
            Routing.RegisterRoute(nameof(NuevoGastoPage), typeof(NuevoGastoPage));
        }
        
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
