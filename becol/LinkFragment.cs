using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace becol
{
    public class LinkFragment : Fragment
    {
        public const string ARG_LINK_NUMBER = "link_number";

        public LinkFragment(){
            
        }

        public static Fragment NewInstance(int position){

            Fragment fragment = new LinkFragment();
            Bundle args = new Bundle();
            args.PutInt(LinkFragment.ARG_LINK_NUMBER, position);
            fragment.Arguments = args;
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
			View rootView = inflater.Inflate(Resource.Layout.fragment_link, container, false);
            var i = this.Arguments.GetInt(ARG_LINK_NUMBER);
            var link = this.Resources.GetStringArray(Resource.Array.links_array)[i];
            var imgId = this.Resources.GetIdentifier(link.ToLower(), "drawable", this.Activity.PackageName);
            var iv = rootView.FindViewById<ImageView>(Resource.Id.image);
            iv.SetImageResource(imgId);
            this.Activity.Title = link;
			/*var linkPosition = this.Arguments.GetInt(ARG_LINK_NUMBER);
            View rootView = null;

            switch(linkPosition){
                case 0:
                    rootView = inflater.Inflate(Resource.Layout.add_new_item, container, false);
                    break;
                case 1:
                    rootView = inflater.Inflate(Resource.Layout.about_fragment, container, false);
                    break;
                default:
                    rootView = inflater.Inflate(Resource.Layout.fragment_link, container, false);
					var link = this.Resources.GetStringArray(Resource.Array.links_array)[linkPosition];
					var imgId = this.Resources.GetIdentifier(link.ToLower(), "drawable", this.Activity.PackageName);
					var iv = rootView.FindViewById<ImageView>(Resource.Id.image);
					iv.SetImageResource(imgId);
					this.Activity.Title = link;
                break;
            }*/

            return rootView;
        }
    }
}
