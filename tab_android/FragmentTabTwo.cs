
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
    
	public class FragmentTabTwo : Fragment
	{

		public static FragmentTabTwo newInstance()
		{
			var fragment = new FragmentTabTwo();
			return fragment;
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.fragment_tab_2, container, false);
			Button defaultButton = view.FindViewById<Button>(Resource.Id.buttonTab2);
			defaultButton.Click += (sender, e) =>
			{
				Toast.MakeText(inflater.Context, "Estas en el fragment 2", ToastLength.Short).Show();
			};
			return view;
		}
	}
}
