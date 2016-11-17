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
using NKitchen.Model;

namespace NKitchen.ViewModel
{
    public class DishViewModel
    {
        public static List<Dish> getAllDishes()
        {
            List<Dish> lstDish = new List<Dish> {
                new Dish {  Id =1,Name="Biryani",Price=100,ImageURL="http://www.desifoodtruck.com/gallery/037.jpg", Description="If there is such a thing as foods of the God, it is undoubtedly the biryani. The magic of biryani lies in the way rice is transformed into something ambrosial."   },
                new Dish {  Id=2,Name="Seekh Kabab",Price=200,ImageURL="http://lh3.googleusercontent.com/-ysMvmXrN_wk/UxApr6KTn8I/AAAAAAAAA3w/PNw9CibeMM0/s1260/SeekhKabab.jpg", Description="Beef Seekh Kababs are spicy kababs made from smooth minced mixture and spices. It is very easy to prepare and gives you perfect taste of seekh kebab."    },
                new Dish {  Id=3,Name="Mutton Karahi",Price=300,ImageURL="http://www.webistinc.net/websites/e8829a46-3909-4c30-ab59-0959649bfc90/images/images/slides/2.jpg", Description="You may have tried many sought of mutton karahis but once you undertake this recipe of Masala Mutton Karahi, you will no longer like any other such recipe. Attempt this and confirm it by yourself."    },
                new Dish {  Id=4,Name="Chicken Tikka",Price=100,ImageURL="http://www.itspotluck.com/upload/registration/chicken_skewers-wallpaper-800x480.jpg", Description="Chicken tikka is always favorite BBQ meal, it is cooked over red hot coal in picnics and outdoor gathering. You may try this at home by simply roasting in oven or even cooking on your pan. It either tastes amazing."    },
                new Dish {  Id=5,Name="Chicken Korma",Price=100,ImageURL="http://img.buzzfeed.com/buzzfeed-static/static/2015-02/10/7/campaign_images/webdr10/15-delicious-desi-food-recipes-tweaked-to-be-heal-2-12791-1423569844-16_dblbig.jpg", Description=""    },
                new Dish {  Id=6,Name="Naan",Price=100,ImageURL="http://dhatoday.com/wp-content/uploads/2013/02/Desi-Cuisine-DHA-Karachi-Traditional-Food-in-Clean-Environment-9.jpg", Description="Qorma is a traditional recipe originating in Central or Western Asia. Kormas are typically made by marinating the main ingredient in yogurt and spices like ginger and garlic. It is then cooked in its own juices and a gravy made of onions, lots of tomatoes, green chillies and whole spices like cinnamon, cardamom, cloves, coriander, cumin, etc. Kormas can range from mild to medium hot and taste nice with breads like Chapatis or naan."    },
                new Dish {  Id=7,Name="Samosa",Price=100,ImageURL="https://dncache-mauganscorp.netdna-ssl.com/thumbseg/1175/1175796-bigthumbnail.jpg", Description="Naan, one of the daily breads of Pakistan, is dense and chewy, almost like focaccia but thinner. If you don't have a pizza peel, use the back of a baking sheet to transfer the dough to a hot pizza stone. You can also bake naan on a heavy baking sheet lined with parchment paper."    },
                new Dish {  Id=8,Name="Gol Gappay",Price=100,ImageURL="http://3.imimg.com/data3/TV/PT/MY-6395905/pure-desi-food-service-250x250.jpg", Description="Also known as pani puri, it has a touch of every flavour like tart, sour, spicy & salty. Gol gappay is really mouth watering and most popular street snack food in India/Pakistan that can be enjoyed any time!"    },
                new Dish {  Id=9,Name="Jalaybi",Price=100,ImageURL="http://3.bp.blogspot.com/_9f8xwh8RVMY/Sp_x8C6tqAI/AAAAAAAAAOo/QSmD_S8H6xk/s400/p2.jpg", Description="Jalebi is a well-known Pakistani sweet. It's an eye-candy of sweet lovers and they keep looking for recipes of Jalebi sweet. Jalebis are cooked at bakeries and sweet shops regularly however people buy it at certain events, occasions and at times of happiness. In the month of holy Ramadan, jalebi, imarti and other similar sweets become more in demand."    },
                new Dish {  Id=10,Name="Shami Kabab",Price=100,ImageURL="http://www.fauziaskitchenfun.com/sites/default/files/chicken%20shamis.jpg", Description="Shaami kabab (also known as Shami kebab) is a very famous variation of kabab in South Asia region. Shami kababs belong to Pakistani, Indian, Afghan and Bangladeshi cuisine. It is made with minced beef added with eggs and some other spices. It is deemed as a perfect snack item for evenings, an add-on with rice and as a dish for guests. We will learn the recipe of shami kabab today. Find how to make pakistani shami kababs (recipe by Chef Rahat) below."    },
                new Dish {  Id=11,Name="Chicken Shashlik",Price=100,ImageURL="http://monal.themonal.com/wp-content/uploads/2014/06/Chicken-shashlik.jpg", Description="With the blunt side of a heavy knife lightly pound the chicken. Combine all ingredients for shashlik except oil and marinate the chicken pieces in it for ½ hour"    }
            };
            return lstDish;
        }
        public static Dish getDishById(int id)
        {
            if (id < 0)
                return null;
            return getAllDishes()[id];
        }

    }
}