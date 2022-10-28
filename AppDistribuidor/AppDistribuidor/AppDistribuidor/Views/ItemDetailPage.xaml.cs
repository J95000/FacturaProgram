using AppDistribuidor.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppDistribuidor.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}