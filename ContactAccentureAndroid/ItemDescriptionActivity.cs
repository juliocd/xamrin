
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace ContactAccentureAndroid
{
    [Activity(Label = "ItemDescriptionActivity")]
    public class ItemDescriptionActivity : Activity
    {
        HttpClient client;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            client = new HttpClient();

            SetContentView(Resource.Layout.ItemDescription);

            string nombre = Intent.GetStringExtra("name") ?? "";
            string ubicacion = Intent.GetStringExtra("position") ?? "";
            string username = Intent.GetStringExtra("username") ?? "";
            string imagen = Intent.GetStringExtra("image") ?? "";

            ImageView contactImageView = FindViewById<ImageView>(Resource.Id.contactImageView);
            TextView contactNametextView = FindViewById<TextView>(Resource.Id.contactNametextView);
            TextView contactPositionTextView = FindViewById<TextView>(Resource.Id.contactPositionTextView);
            TextView contactUsernameTextView = FindViewById<TextView>(Resource.Id.contactUsernameTextView);
			Button moreInformationGetButton = FindViewById<Button>(Resource.Id.moreInformationGetButton);
			Button moreInformationPostButton = FindViewById<Button>(Resource.Id.moreInformationPostButton);
            TextView moreInformationTextView = FindViewById<TextView>(Resource.Id.moreInformationTextView);

			int imageId = Resource.Drawable.Icon;
			switch (imagen)
			{
				case "socrates":
					imageId = Resource.Drawable.socrates;
					break;
				case "platon":
					imageId = Resource.Drawable.platon;
					break;
				case "newton":
					imageId = Resource.Drawable.newton;
					break;
				case "aristoteles":
					imageId = Resource.Drawable.aristoteles;
					break;
			}
			contactImageView.SetImageResource(imageId);

            contactNametextView.Text = nombre;
            contactPositionTextView.Text = ubicacion;
            contactUsernameTextView.Text = username;

            moreInformationGetButton.Click += async (sender, e) =>
            {
                moreInformationTextView.Text = await MoreInformationGet();
            };

			moreInformationPostButton.Click += async (sender, e) =>
			{
				moreInformationTextView.Text = await MoreInformationPost();
			};
        }

		async Task<string> MoreInformationGet()
		{
			string RestUrl = "http://services.groupkt.com/country/get/all";
			var uri = new Uri(string.Format(RestUrl, string.Empty));
			var response = await client.GetAsync(uri);

			string items = "";

			if (response.IsSuccessStatusCode)
			{
				items = await response.Content.ReadAsStringAsync();
			}

            return items;
		}

		async Task<string> MoreInformationPost()
		{
			string RestUrl = "http://130.211.138.52/app.php/cuentas";
			var uri = new Uri(string.Format(RestUrl, string.Empty));

            DataPost item = new DataPost();

            item.documento = "123456";
            item.nombre = "Julio Diaz";

			var json = JsonConvert.SerializeObject(item);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);

			string items = "";

			if (response.IsSuccessStatusCode)
			{
				items = await response.Content.ReadAsStringAsync();
			}

			return items;
		}

        internal class DataPost{
            public string documento { get; set; }
            public string nombre { get; set; }

            public DataPost(){
                
            }
        }
    }
}
