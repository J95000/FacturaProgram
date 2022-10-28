using AppDistribuidor.Models;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppDistribuidor.ViewModels
{
    public class FotoViewModel : FotoModel
    {

        
        public Command CapturarComando { get; set; }
       
        public FotoViewModel()
        {
            CapturarComando = new Command(TomarFoto);
            Fotico = ImageSource.FromUri(new Uri("https://i.ibb.co/njxyvPL/descarga.png"));
             
        }

        private async void TomarFoto()
        {
            var camara = new StoreCameraMediaOptions();
            camara.PhotoSize = PhotoSize.Small;
            camara.SaveToAlbum = true;
            var foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(camara);
            if(foto != null)
            {

                VariablesGlobales.stream = foto.GetStream();
                VariablesGlobales.Bandera = 1;
                Fotico = ImageSource.FromStream(() => {
                    return foto.GetStream();
                    } );
            }

        }

    }
}
