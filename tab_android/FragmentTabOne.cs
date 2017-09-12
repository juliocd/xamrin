
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;

namespace tab_android
{
    
	public class FragmentTabOne : Fragment
	{

		public static FragmentTabOne newInstance()
		{
            var fragment = new FragmentTabOne();
			return fragment;
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
            var view = inflater.Inflate(Resource.Layout.fragment_tab_1, container, false);
            Button defaultButton = view.FindViewById<Button>(Resource.Id.buttonTab1);
            defaultButton.Click += (sender, e) => {
                Toast.MakeText(inflater.Context, "Estas en el fragment 1", ToastLength.Short).Show();
            };
			return view;
		}
	}
}
