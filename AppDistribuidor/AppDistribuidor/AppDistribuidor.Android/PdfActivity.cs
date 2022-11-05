using Android.App;
using Android.Graphics.Pdf;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using System.Net.Http;

namespace AppDistribuidor.Droid
{
    [Activity(Label = "PdfActivity")]
    public class PdfActivity : Activity
    {

        public static PdfRenderer pdfRenderer;
        public static int idMovimiento;

        public static PdfRenderer PdfRenderer { get => pdfRenderer; set => pdfRenderer = value; }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("¿Esta Seguro de Anular la Factura?");
            builder.SetMessage("Se Anulara la Factura");
            builder.SetPositiveButton("Anular", async (sender, e) =>
            {
                HttpClient httpClient = new HttpClient(new Xamarin.Android.Net.AndroidClientHandler());

                var resstring = await httpClient.GetAsync($"http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Actualizar_Movimiento_Facturacion/{idMovimiento}/{DateTime.Now}/DE");
                string res = Convert.ToString(resstring);
                if (res == "true")
                {
                    AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    dialog.SetTitle("Factura Anulada");
                    dialog.SetMessage("Se Anuló la Factura");
                    dialog.SetPositiveButton("Aceptar", (sender, e) =>
                    {

                    });
                    dialog.Show();
                }
                else
                {
                    AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    dialog.SetTitle("No se Pudo Anular la Factura");
                    dialog.SetMessage("No se Anuló la Factura");
                    dialog.SetPositiveButton("Cerrar", (sender, e) =>
                    {

                    });
                    dialog.Show();
                }
            });
            builder.SetNegativeButton("Cancelar", (sender, e) =>
            {
                Console.WriteLine("no");
            });
            RelativeLayout ll = new RelativeLayout(this);
            ImageView pdfImageView = new ImageView(this);
            Button btnAnular = new Button(this);
            btnAnular.Text = "Anular Factura";
            btnAnular.Click += delegate
            {
                builder.Show();
            };

            ll.AddView(pdfImageView, new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
            ll.AddView(btnAnular);
            var pdfBitmap = pdfRenderer.GetBitmapFromRender();
            pdfImageView.SetImageBitmap(pdfBitmap);
            this.AddContentView(ll, new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
            // Create your application here
        }
    }
}