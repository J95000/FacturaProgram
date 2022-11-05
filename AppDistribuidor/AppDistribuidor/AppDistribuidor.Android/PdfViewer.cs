using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics.Pdf;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppDistribuidor.Droid;
using AppDistribuidor.Services;
using Java.IO;

[assembly: Xamarin.Forms.Dependency(typeof(PdfViewer))]
namespace AppDistribuidor.Droid
{
    public class PdfViewer : IPdfViewer
    {
        public async Task Open(byte[] pdf)
        {
            var client = new HttpClient();


            var f = new Java.IO.File(MainActivity.CurrentActivity.CacheDir, "factura.pdf");

            FileOutputStream output = new FileOutputStream(f);
            await output.WriteAsync(pdf);
            output.Close();

            var pdfFileDescriptor = ParcelFileDescriptor.Open(f, ParcelFileMode.ReadOnly);
            var renderer = new PdfRenderer(pdfFileDescriptor);

            PdfActivity.PdfRenderer = renderer;
            MainActivity.CurrentActivity.StartActivity(new Intent(MainActivity.CurrentActivity, typeof(PdfActivity)));
        }
    }
}