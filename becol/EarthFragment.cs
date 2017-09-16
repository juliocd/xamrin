using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace becol
{
    public class EarthFragment : Fragment
    {

		public static Fragment NewInstance()
		{
			Fragment fragment = new EarthFragment();
			Bundle args = new Bundle();
			return fragment;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
            
            View rootView = inflater.Inflate(Resource.Layout.earth_fragment, container, false);

            Button goPopulationBtn = rootView.FindViewById<Button>(Resource.Id.goPopulationBtn);
            goPopulationBtn.Click += delegate {

                var activity2 = new Intent(rootView.Context, typeof(PopulationActivity));
				StartActivity(activity2);
			};

			return rootView;
		}
    }
}
