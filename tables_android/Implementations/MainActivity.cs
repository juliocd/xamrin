﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.ObjectModel;
using tables_android.Implementations;

namespace tables_android
{
    [Activity(Label = "tables_android", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button simpleTableButton = FindViewById<Button>(Resource.Id.simpleTableButton);
            Button adapterTableButton = FindViewById<Button>(Resource.Id.adapterTableButton);
            Button tablaSimpleBoton = FindViewById<Button>(Resource.Id.tablaSimpleBoton);
            Button tablaAdaptadorBoton = FindViewById<Button>(Resource.Id.tablaAdaptadorBoton);

            simpleTableButton.Click += SimpleTableButton_Click;
            adapterTableButton.Click += AdapterTableButton_Click;
            tablaSimpleBoton.Click += (object sender, System.EventArgs e) => {
                Button button = (Button)sender;

                var intent = new Intent(this, typeof(TablaSimpleActivity));
                intent.PutExtra("titulo", "Tabla Simple");
                StartActivity(intent);
            };
            tablaAdaptadorBoton.Click += TablaAdaptadorBoton_Click;

        }

        void TablaAdaptadorBoton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(TablaAdaptadorActivity));
            intent.PutExtra("titulo", "Tabla Adaptador");
            StartActivity(intent);
        }

        void SimpleTableButton_Click(object sender, System.EventArgs e)
        {
            string[] data = {
                "Colombia", "Brasil", "Alemania", "Holanda",
                "Monaco","Mongolia","Montserrat","Morocco","Mozambique","Myanmar","Namibia",
                "Iceland","India","Indonesia","Iran","Iraq","Ireland","Israel",
                "United States","United States Minor Outlying Islands","Uruguay"
            };
            var activity = new Intent(this, typeof(SimpleTableActivity));
			activity.PutExtra("title", "Tabla simple");
            activity.PutExtra("data", data);
			StartActivity(activity);
        }

        void AdapterTableButton_Click(object sender, System.EventArgs e)
        {
			var activity = new Intent(this, typeof(AdapterTableActivity));
			activity.PutExtra("title", "Tabla con adaptador");
			StartActivity(activity);
        }
    }
}

