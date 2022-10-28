using AppDistribuidor.Services;
using AppDistribuidor.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDistribuidor
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<MockDataStorePrestamo>();
            DependencyService.Register<MockDataGasto>();
            MainPage = new NavigationPage(new PageSplash());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
