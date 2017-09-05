
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

namespace tables_android.Implementations
{
    [Activity(Label = "TablaSimple")]
    public class TablaSimpleActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TablaSimple);

            TextView titulo = FindViewById<TextView>(Resource.Id.textView1);
            ListView listaNombres = FindViewById<ListView>(Resource.Id.listView1);

            titulo.Text = Intent.GetStringExtra("titulo") ?? "No encontrado";

			string[] data = {
				"Colombia", "Brasil", "Alemania", "Holanda",
				"Monaco","Mongolia","Montserrat","Morocco","Mozambique","Myanmar","Namibia",
				"Iceland","India","Indonesia","Iran","Iraq","Ireland","Israel",
				"United States","United States Minor Outlying Islands","Uruguay"
			};

			ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.SimpleListItem, data);

			listaNombres.Adapter = adapter;

            listaNombres.ItemClick += ListaNombres_ItemClick;
        }

        void ListaNombres_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

        }
    }
}
