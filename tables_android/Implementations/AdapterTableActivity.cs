using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using tables_android.Content;
using tables_android.Models;

namespace tables_android
{
    [Activity(Label = "AdapterTable")]
    public class AdapterTableActivity : Activity
    {
        List<Post> listData;
        ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AdapterTable);

            string titleText = Intent.GetStringExtra("title") ?? "Data not available";
            TextView titleTextView = FindViewById<TextView>(Resource.Id.titleTextView_adapterTable);
            titleTextView.Text = titleText;

            Post post1 = new Post();
            post1.Title = "Tierra";
            post1.Description = "Tercer planeta";
            post1.Url = "earth";
			Post post2 = new Post();
			post2.Title = "Jupiter";
			post2.Description = "Quinto planeta";
            post2.Url = "jupiter";
			Post post3 = new Post();
			post3.Title = "Marte";
			post3.Description = "Segundo planeta";
            post3.Url = "mars";

            listData = new List<Post>();
            listData.Add(post1);
            listData.Add(post2);
            listData.Add(post3);

            listView = FindViewById<ListView>(Resource.Id.messageListView);
            listView.ItemClick += HandleEventHandler;
			listView.Adapter = new CusotmListAdapter(this, listData);
        }

        void HandleEventHandler(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = listData[e.Position];
            Toast.MakeText(this, "Usted ha seleccionado " + item.Title + " en la posición " + e.Position,
                           ToastLength.Short).Show();
        }
    }
}
