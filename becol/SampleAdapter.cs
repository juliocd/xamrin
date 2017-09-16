using System;
using Android.Views;
using Android.Widget;

namespace becol
{
    public class SampleAdapter : BaseAdapter
    {
        private MainActivity owner;

        public SampleAdapter (MainActivity owner) : base (){
            this.owner = owner;
        }

        public override int Count {
            get {
                return owner.mSamples.Length;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return owner.mSamples[position];
        }

        public override long GetItemId(int position)
        {
            return (long)owner.mSamples[position].GetHashCode();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if(convertView == null){
                convertView = owner.LayoutInflater.Inflate(Resource.Layout.sample_dashboard_item, parent, false);
            }
            convertView.FindViewById<TextView> (Android.Resource.Id.Text1).SetText( (owner.mSamples[position].titleResId));
            convertView.FindViewById<TextView> (Android.Resource.Id.Text2).SetText((owner.mSamples[position].descriptionResId));

            return convertView;
        }
    }
}
