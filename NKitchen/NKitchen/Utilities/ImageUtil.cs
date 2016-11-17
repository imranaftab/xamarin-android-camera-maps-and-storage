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
using Android.Graphics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NKitchen.Utilities
{
    public class ImageUtil
    {

        public static Bitmap GetImageBitmapFromFilePath(string fileName, int width, int height)
        {
            BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(fileName, options);

            //Next we calculate the ratio that we need to resize the image by 
            //in order to fit the requested dimensions

            int outHeight = options.OutHeight;
            int outWidth = options.OutWidth;
            int inSampleSize = 1;

            if (outHeight > height || outWidth > width)
            {
                inSampleSize = outWidth > outHeight ? outHeight / height : outWidth / width;
            }

            //Now we  will load the image and have BitmapFactory resize it for us
            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;

            Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

            return resizedBitmap;

        }
        public static Bitmap GetImgFromURL(string url)
        {
            Bitmap img = null;
            try
            {
                using (var client = new WebClient())
                {
                    var imageData = client.DownloadData(url);
                    if (imageData != null && imageData.Length > 0)
                        img = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);

                }

            }
            catch (Exception)
            {

            }
            return img;
        }
    }
}