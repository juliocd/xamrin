
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace tables_android
{
    [Activity(Label = "SimpleTable")]
    public class SimpleTableActivity : Activity
    {
        String[] data;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SimpleTable);

            string titleText = Intent.GetStringExtra("title") ?? "Data not available";
            TextView titleTextView = FindViewById<TextView>(Resource.Id.titleTextView_simpleTable);
            titleTextView.Text = titleText;

            data = Intent.GetStringArrayExtra("data");
            ListView countriesListView = FindViewById<ListView>(Resource.Id.countriesListView_simplsTable);

            ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.SimpleListItem, data);

            countriesListView.Adapter = adapter;

            countriesListView.ItemClick += CountriesListView_ItemClick;
        }

        void CountriesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, "Usted ha seleccionado " + data[e.Position] + " en la posición " + e.Position,
			ToastLength.Short).Show();
        }
    }
}
