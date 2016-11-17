using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace NKitchen
{
    [Activity(Label = "Imran Aftab", Icon = "@drawable/icon", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button btn_Exit;
        private Button btn_About;
        private Button btn_TakePic;
        private Button btn_DishesList;
        private Button btn_Cart;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);

            Find_Views();
            Attach_Events();

        }

        private void Attach_Events()
        {
            btn_Exit.Click += Btn_Exit_Click;
            btn_About.Click += Btn_About_Click;
            btn_TakePic.Click += Btn_TakePic_Click;
            btn_DishesList.Click += Btn_DishesList_Click;
            btn_Cart.Click += Btn_Cart_Click; ;
        }

        private void Btn_Cart_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CartActivity));
            StartActivity(intent);
        }

        private void Btn_DishesList_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(NKitchenMenu));
            StartActivity(intent);
        }

        private void Btn_TakePic_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePicActivity));
            StartActivity(intent);
        }

        private void Btn_About_Click(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        private void Find_Views()
        {
            btn_Exit = FindViewById<Button>(Resource.Id.btn_Exi);
            btn_About = FindViewById<Button>(Resource.Id.btn_About);
            btn_TakePic = FindViewById<Button>(Resource.Id.btn_CamptureImage);
            btn_DishesList = FindViewById<Button>(Resource.Id.btn_DishList);
            btn_Cart = FindViewById<Button>(Resource.Id.btn_Cart);
        }

        private void Btn_Exit_Click(object sender, System.EventArgs e)
        {
            this.Finish();
        }
    }
}

