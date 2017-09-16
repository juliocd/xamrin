using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.Design.Widget;
using ContactAccentureAndroid.Fragments;
using Android.Support.V4.View;
using System.Collections.Generic;

namespace ContactAccentureAndroid
{
    [Activity(Label = "ContactAccentureAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create UI
            SetContentView(Resource.Layout.Main);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            // Init toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            // Attach item selected handler to navigation view
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            // Create ActionBarDrawerToggle button and add it to the toolbar
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            TextView titleContacts = FindViewById<TextView>(Resource.Id.listContacTitle);
            ListView listViewContacts = FindViewById<ListView>(Resource.Id.contactListView);

            titleContacts.Text = "Lista de contactos";

            List<Contacto> listaContactos = new List<Contacto>();

            Contacto contacto1 = new Contacto();
            contacto1.Nombre = "Platon";
            contacto1.Username = "platon.pensar";
            contacto1.Ubicacion = "Grecia";
            contacto1.Imagen = "platon";
			Contacto contacto2 = new Contacto();
			contacto2.Nombre = "Newton";
			contacto2.Username = "newton.apple";
			contacto2.Ubicacion = "Inglaterra";
			contacto2.Imagen = "newton";
			Contacto contacto3 = new Contacto();
			contacto3.Nombre = "Aristoteles";
			contacto3.Username = "aristoteles.filosofar";
			contacto3.Ubicacion = "Grecia oriental";
			contacto3.Imagen = "aristoteles";
			Contacto contacto4 = new Contacto();
			contacto4.Nombre = "Socrates";
			contacto4.Username = "socrates.maestro";
			contacto4.Ubicacion = "Grecia occidental";
			contacto4.Imagen = "socrates";

            listaContactos.Add(contacto1);
            listaContactos.Add(contacto2);
            listaContactos.Add(contacto3);
            listaContactos.Add(contacto4);

            listViewContacts.Adapter = new CusotmListAdapter(this, listaContactos);

            listViewContacts.ItemClick += (sender, e) => {
                var item = listaContactos[e.Position];
                Intent descriptionContactIntent = new Intent(this, typeof(ItemDescriptionActivity));
                descriptionContactIntent.PutExtra("name", item.Nombre);
                descriptionContactIntent.PutExtra("position", item.Ubicacion);
                descriptionContactIntent.PutExtra("image", item.Imagen);
                descriptionContactIntent.PutExtra("username", item.Username);

                StartActivity(descriptionContactIntent);
            };
        }

        void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {

            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_home):
                    var trans = SupportFragmentManager.BeginTransaction();
                    trans.Add(Resource.Id.ContentFrameLayout, new ContactsFragment(), "Contacts");
                    trans.Commit();
                    break;
            }

            // Close drawer
            drawerLayout.CloseDrawers();
        }
    }
}

