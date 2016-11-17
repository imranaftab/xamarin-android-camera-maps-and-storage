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

namespace NKitchen
{
    [Activity(Label = "Cart")]
    public class CartActivity : Activity
    {
        private TextView txt_Total;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CartLayout);
            Find_View();

        }

        private void Find_View()
        {
            txt_Total = FindViewById<TextView>(Resource.Id.lbl_CartTotal);
            var localContacts = Application.Context.GetSharedPreferences("MyContacts", FileCreationMode.Private);
            txt_Total.Text = "Rs/- "+ localContacts.GetString("TotalPrice", null)  ;
        }
    }
}