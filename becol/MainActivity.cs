using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;

namespace becol
{
    public class MainActivity : Activity, AdapterView.IOnItemClickListener
    {
        internal Sample[] mSamples;
        internal GridView mGridView;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            mSamples = new Sample[] {
				new Sample (Resource.String.navigationdraweractivity_title,
					Resource.String.navigationdraweractivity_description,
					this,
					typeof(NavigationDrawerActivity))
            };

            mGridView = FindViewById<GridView>(Android.Resource.Id.List);
            mGridView.Adapter = new SampleAdapter(this);
            mGridView.OnItemClickListener = this;
        }

        public void OnItemClick (AdapterView container, View view, int position, long id){
            StartActivity(mSamples[position].intent);
        }
    }
}

