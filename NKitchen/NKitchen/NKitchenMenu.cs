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
using NKitchen.ViewModel;
using NKitchen.Model;

namespace NKitchen
{
    [Activity(Label = "Menu")]
    public class NKitchenMenu : Activity
    {
        private ListView lst;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MenuLayout);
            lst = FindViewById<ListView>(Resource.Id.menuListView);
            lst.Adapter = new MenuListAdaptor(this, DishViewModel.getAllDishes().ToList());
            lst.ItemClick += Lst_ItemClick1; ;
        }

        private void Lst_ItemClick1(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(DishDetail));
            intent.PutExtra("DishId", e.Position);
            StartActivity(intent);
        }
        
        
    }
}