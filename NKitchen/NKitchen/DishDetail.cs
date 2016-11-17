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
using NKitchen.Utilities;
using NKitchen.ViewModel;
using NKitchen.Model;

namespace NKitchen
{
    [Activity(Label = "Imran Foods", Icon = "@drawable/icon")]
    public class DishDetail : Activity
    {
        private ImageView img_Dish;
        private TextView lbl_DishName;
        private TextView lbl_DishDiscription;
        private TextView lbl_DishPrice;
        private EditText txt_OrderNoOfItems;
        private Button btn_Cancel;
        private Button btn_Buy;

        private Dish dish;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.DishDetail);

            var selDishId = Intent.Extras.GetInt("DishId", 0);
            dish = DishViewModel.getDishById(selDishId);

            init_DishDetails();
            load_DishDetails();
            attach_Events();
        }

        private void attach_Events()
        {
            btn_Buy.Click += Btn_Buy_Click;
        }
        public void Btn_Buy_Click(object sender, EventArgs ev)
        {
            var d = new AlertDialog.Builder(this);

            int noOfItems;
            if (Int32.TryParse(txt_OrderNoOfItems.Text, out noOfItems))
            {
                d.SetTitle("Item added to Cart!");
                d.SetMessage( txt_OrderNoOfItems.Text + " " + lbl_DishName.Text + " added to cart. Total Cost = "+Double.Parse(lbl_DishPrice.Text) * Int32.Parse(txt_OrderNoOfItems.Text));
                var localContacts = Application.Context.GetSharedPreferences("MyContacts", FileCreationMode.Private);
                var contactEdit = localContacts.Edit();
                contactEdit.PutString("Dish Name", txt_OrderNoOfItems.Text);
                contactEdit.PutString("Quantity", txt_OrderNoOfItems.Text);
                contactEdit.PutString("Price", lbl_DishPrice.Text);
                contactEdit.PutString("TotalPrice", Double.Parse(lbl_DishPrice.Text) * Int32.Parse(txt_OrderNoOfItems.Text)+"");
                contactEdit.Commit();
            }
            else
            {
                d.SetTitle("Invalid Input!");
                d.SetMessage("Please enter valid number!");
            }
            d.Show();

        }
        private void load_DishDetails()
        {
            lbl_DishName.Text = dish.Name;//"Seekh Kabab";
            lbl_DishDiscription.Text = dish.Description;// "A delicious spicy recipe of beef seekh kebab cooked on your stove. Extra tender beef seekh kebab seasoned with raw papaya and flavorful ingredients";
            lbl_DishPrice.Text = dish.Price+"";// "500 Rs/-";
            var img = ImageUtil.GetImgFromURL(dish.ImageURL);//"http://lh3.googleusercontent.com/-ysMvmXrN_wk/UxApr6KTn8I/AAAAAAAAA3w/PNw9CibeMM0/s1260/SeekhKabab.jpg");
            if (img != null)
                img_Dish.SetImageBitmap(img);
        }

        private void init_DishDetails()
        {
            lbl_DishName = FindViewById<TextView>(Resource.Id.dishNameTextView);
            lbl_DishDiscription = FindViewById<TextView>(Resource.Id.dishDescriptionTextView);
            lbl_DishPrice = FindViewById<TextView>(Resource.Id.dishPriceTextView);

            txt_OrderNoOfItems = FindViewById<EditText>(Resource.Id.itemsEditText);


            btn_Buy = FindViewById<Button>(Resource.Id.btnBuy);
            btn_Cancel = FindViewById<Button>(Resource.Id.btnCancel);

            img_Dish = FindViewById<ImageView>(Resource.Id.dishImage);

        }
    }
}