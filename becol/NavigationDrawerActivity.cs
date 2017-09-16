
using System;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace becol
{
    [Activity(Label = "Navigation Drawer", MainLauncher = true, Icon = "@mipmap/icon")]
    public class NavigationDrawerActivity : Activity, LinkAdapter.OnItemClickListener
    {

        private DrawerLayout mDrawerLayout;
        private RecyclerView mDrawList;
        private ActionBarDrawerToggle mDrawerToggle;

        private string mDrawerTitle;
        private String[] mLinkTitles;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_navigation_drawer);

            mDrawerTitle = this.Title;
            mLinkTitles = this.Resources.GetStringArray(Resource.Array.links_array);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mDrawList = FindViewById<RecyclerView>(Resource.Id.left_drawer);

            mDrawerLayout.SetDrawerShadow(Resource.Drawable.drawer_shadow, GravityCompat.Start);
            mDrawList.HasFixedSize = true;
            mDrawList.SetLayoutManager(new LinearLayoutManager (this));

            mDrawList.SetAdapter(new LinkAdapter(mLinkTitles, this));
            this.ActionBar.SetDisplayHomeAsUpEnabled(true);
            this.ActionBar.SetHomeButtonEnabled(true);

            mDrawerToggle = new MyActionBarDrawerToggle(this, mDrawerLayout,
                 Resource.String.drawer_open,
                 Resource.String.drawer_close);

            mDrawerLayout.AddDrawerListener(mDrawerToggle);
            if (savedInstanceState == null)
                selectItem(0);
        }

        internal class MyActionBarDrawerToggle : ActionBarDrawerToggle
        {
            NavigationDrawerActivity owner;

            public MyActionBarDrawerToggle (NavigationDrawerActivity activity, DrawerLayout layout, int openRes, int closeRes)
                : base (activity, layout, openRes, closeRes){
                owner = activity;
            }

            public override void OnDrawerClosed (View drawerView){
                owner.ActionBar.Title = owner.Title;
                owner.InvalidateOptionsMenu();
            }

            public override void OnDrawerOpened (View drawerView){
                owner.ActionBar.Title = owner.mDrawerTitle;
                owner.InvalidateOptionsMenu();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            this.MenuInflater.Inflate(Resource.Menu.navigation_drawer, menu);
            return true;
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            bool drawOpen = mDrawerLayout.IsDrawerOpen(mDrawList);
            menu.FindItem(Resource.Id.action_websearch).SetVisible(!drawOpen);
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if(mDrawerToggle.OnOptionsItemSelected(item)){
                return true;
            }

            switch(item.ItemId){
                case Resource.Id.action_websearch:

                    Intent intent = new Intent(Intent.ActionWebSearch);
                    intent.PutExtra(SearchManager.Query, this.ActionBar.Title);
                    if(intent.ResolveActivity(this.PackageManager) != null){
                        StartActivity(intent);
                    }else{
                        Toast.MakeText(this, Resource.String.app_not_available, ToastLength.Long).Show();
                    }

                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public void OnClick(View view, int position){
            selectItem(position);
        }

        private void selectItem(int position){

            var fragmentManager = this.FragmentManager;
            var ft = fragmentManager.BeginTransaction();

            switch(position){
                case 2:
					ft.Replace(Resource.Id.content_frame, EarthFragment.NewInstance());
                    break;
                default:
					ft.Replace(Resource.Id.content_frame, LinkFragment.NewInstance(position));
                    break;
            }
            ft.Commit();

            Title = mLinkTitles[position];
            mDrawerLayout.CloseDrawer(mDrawList);
        }

        protected override void OnTitleChanged (Java.Lang.ICharSequence title, Color color){
            this.ActionBar.Title = title.ToString();
        }

        protected override void OnPostCreate(Bundle savedInstanceState){
            base.OnPostCreate(savedInstanceState);
            mDrawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Configuration newConfig){
            base.OnConfigurationChanged(newConfig);
            mDrawerToggle.OnConfigurationChanged(newConfig);
        }
    }
}
