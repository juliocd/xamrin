﻿using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace tab_android
{
    [Activity(Label = "tab_android", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

			// Find views
            var pager = FindViewById<ViewPager>(Resource.Id.pager);
			var tabLayout = FindViewById<TabLayout>(Resource.Id.sliding_tabs);
			var adapter = new CustomPagerAdapter(this, SupportFragmentManager);
			var toolbar = FindViewById<Toolbar>(Resource.Id.my_toolbar);

			// Setup Toolbar
			SetSupportActionBar(toolbar);
			SupportActionBar.Title = "Android Tabs";

			// Set adapter to view pager
			pager.Adapter = adapter;

			// Setup tablayout with view pager
			tabLayout.SetupWithViewPager(pager);

			// Iterate over all tabs and set the custom view
			for (int i = 0; i < tabLayout.TabCount; i++)
			{
				TabLayout.Tab tab = tabLayout.GetTabAt(i);
				tab.SetCustomView(adapter.GetTabView(i));
			}
        }
    }
}

