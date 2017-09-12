using System;
using System.Collections.Generic;
using Android.App;
using Android.Content.Res;
using Android.Views;
using Android.Widget;
using tables_android.Models;

namespace tables_android.Content
{
	public class CusotmListAdapter : BaseAdapter<Post>
	{
		Activity context;
        List<Post> list;

		public CusotmListAdapter(Activity _context, List<Post> _list)
			: base()
		{
			this.context = _context;
			this.list = _list;
		}

		public override int Count
		{
			get { return list.Count; }
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override Post this[int position]
		{
			get { return list[position]; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;

			if (view == null)
				view = context.LayoutInflater.Inflate(Resource.Layout.ListItemRow, parent, false);

			Post item = this[position];
            TextView titulo = view.FindViewById<TextView>(Resource.Id.Title);
			titulo.Text = item.Title;
			view.FindViewById<TextView>(Resource.Id.Description).Text = item.Description;
            var imageView = view.FindViewById<ImageView>(Resource.Id.Thumbnail);

            int imageId = Resource.Drawable.default_image;
            if (item.Url != null){
                switch(item.Url){
                    case "earth":
                        imageId = Resource.Drawable.earth;
                        break;
                    case "jupiter":
                        imageId = Resource.Drawable.jupiter;
						break;
					case "mars":
                        imageId = Resource.Drawable.mars;
						break;
                }
            }
            imageView.SetImageResource(imageId);

			return view;
		}
	}
}
