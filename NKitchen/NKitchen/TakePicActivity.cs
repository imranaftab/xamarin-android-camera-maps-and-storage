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
using Android.Provider;
using Java.IO;
using Android.Graphics;
using NKitchen.Utilities;

namespace NKitchen
{
    [Activity(Label = "TakePicActivity")]
    public class TakePicActivity : Activity
    {
        private Button btn_TakePic;
        private ImageView PicImage;
        private File imgFile;
        private File imgDirectory;
        private Bitmap imgBitmap;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TakePicLayout);
            imgDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "myDishes");
            if (!imgDirectory.Exists())
            {
                imgDirectory.Mkdirs();
            }
            Find_Views();
            Attach_Event();
        }

        
        private void Attach_Event()
        {
            btn_TakePic.Click += Btn_TakePic_Click;
        }

        
        private void Btn_TakePic_Click(object sender, EventArgs e)
        {
            //start camera activity
            var intent = new Intent(MediaStore.ActionImageCapture);
            imgFile = new File(imgDirectory, $"phto {Guid.NewGuid()}.jpg");
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imgFile));
            StartActivityForResult(intent, 0);
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            int height = PicImage.Height;
            int width = PicImage.Width;
            imgBitmap = ImageUtil.GetImageBitmapFromFilePath(imgFile.Path, width, height);
            if (imgBitmap != null)
            {
                PicImage.SetImageBitmap(imgBitmap);
                imgBitmap = null;
            }
            GC.Collect();
        }
        private void Find_Views()
        {
            btn_TakePic = FindViewById<Button>(Resource.Id.btn_TakePic);
            PicImage = FindViewById<ImageView>(Resource.Id.PicImage);
        }
    }
}