using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppDistribuidor
{
    public class PageSplash : ContentPage
    {
        Image splashImage;
        public PageSplash()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "https://i.ibb.co/GnyftJz/logo-San-Antonio.png",
                WidthRequest = 300,
                HeightRequest = 150
            };

            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(splashImage,
              new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));


            sub.Children.Add(splashImage);
            this.BackgroundColor = Color.FromHex("#429de3");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 2000);

            Application.Current.MainPage = new Views.LoginPage();

           // Application.Current.MainPage = new Views.InicioPage();




        }
    }
}