
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
using tables_android.Models;

namespace tables_android.Implementations
{
    [Activity(Label = "TablaAdaptadorActivity")]
    public class TablaAdaptadorActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TablaAdaptador);

            TextView titleTextView = FindViewById<TextView>(Resource.Id.textViewAdapter);
            ListView planetsListView = FindViewById<ListView>(Resource.Id.listViewAdapter);

			string titleText = Intent.GetStringExtra("titulo") ?? "Data not available";
			titleTextView.Text = titleText;

            LoadData();


        }

        private List<Planeta> LoadData()
        {
            List<Planeta> planetas = new List<Planeta>();

			Planeta tierra = new Planeta("Tierra", "Mi hogar");
            tierra.Imagen = "earth";
			Planeta marte = new Planeta("Marte", "Planeta rojo");
			marte.Imagen = "mars";
			Planeta jupiter = new Planeta("Jupiter", "Planeta mas grande");
			jupiter.Imagen = "jupiter";
			Planeta venus = new Planeta("Venus", "El primer planeta");
			venus.Imagen = "venus";

            planetas.Add(tierra);
            planetas.Add(marte);
            planetas.Add(jupiter);
            planetas.Add(venus);

            return planetas;
        }
    }
}
