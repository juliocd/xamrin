using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace becol
{
    public class LinkAdapter : RecyclerView.Adapter
    {
        private String[] mDataset;
        private OnItemClickListener mListener;

        public interface OnItemClickListener{
            void OnClick(View view, int position);
        }

        public class ViewHolder : RecyclerView.ViewHolder{
            public readonly TextView textView;
            public ViewHolder(TextView v) : base(v){
                textView = v;
            }
        }

        public LinkAdapter(string[] myDataSet, OnItemClickListener listener){
            mDataset = myDataSet;
            mListener = listener;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType){
            var vi = LayoutInflater.From(parent.Context);
            var v = vi.Inflate(Resource.Layout.drawer_list_item, parent, false);
            var tv = v.FindViewById<TextView>(Android.Resource.Id.Text1);
            return new ViewHolder(tv);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var newHolder = (ViewHolder)holder;
            newHolder.textView.Text = mDataset[position];
            newHolder.textView.Click += (object sender, EventArgs args) => {
                mListener.OnClick((View) sender, position);
            };
        }

        public override int ItemCount
        {
            get
            {
                return mDataset.Length;
            }
        }
    }
}
