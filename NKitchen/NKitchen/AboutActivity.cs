using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;

namespace NKitchen
{
    [Activity(Label = "About", Icon = "@drawable/icon")]
    public class AboutActivity : Activity
    {
        private WebView view;
        private Button btn_Call;
        private Button btn_GeoImran;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AboutLayout);

            Find_View();
            Attach_Event();
        }

        private void Find_View()
        {
            view = FindViewById<WebView>(Resource.Id.AboutWebView);
            btn_Call = FindViewById<Button>(Resource.Id.btn_CallImran);
            btn_GeoImran = FindViewById<Button>(Resource.Id.btn_GeoImran);

            const string text = "<html style=\"Background:#333;color:#fff; \" ><body><p  align=\"justify\">" +
                "Imran currently works as a professional mobile application developer on the Xamarin platform for over 1 year, with several apps published on iOS, Android, and Windows stores. In his spare time, he teach computer programming to students, write open source code on GitHub and develop application for social cause." +
                "</p></body></html>";
            view.LoadData(text, "text/html", "utf-8");

        }

        private void Attach_Event()
        {
            btn_Call.Click += Btn_Call_Click;
            btn_GeoImran.Click += Btn_GeoImran_Click;
        }

        private void Btn_GeoImran_Click(object sender, EventArgs e)
        {
            //Android.Net.Uri imranLocUri = Android.Net.Uri.Parse("geo:31.465903,74.272831(Imran)");
            //Intent mapIntent = new Intent(Intent.ActionView, imranLocUri);
            //StartActivity(mapIntent);

            var intent = new Intent(this, typeof(MapsActivity));
            StartActivity(intent);



        }

        private void Btn_Call_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse("tel:" + "+923218802245"));
            StartActivity(intent);

        }
    }
}