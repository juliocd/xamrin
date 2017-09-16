using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace ContactAccentureAndroid
{
	public class CusotmListAdapter : BaseAdapter<Contacto>
	{
		Activity context;
		List<Contacto> list;

		public CusotmListAdapter(Activity _context, List<Contacto> _list)
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

		public override Contacto this[int position]
		{
			get { return list[position]; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;

			if (view == null)
				view = context.LayoutInflater.Inflate(Resource.Layout.ListItemRow, parent, false);

			TextView nombre = view.FindViewById<TextView>(Resource.Id.NombreTextView);
			TextView username = view.FindViewById<TextView>(Resource.Id.UsernameTextView);
			TextView ubicacion = view.FindViewById<TextView>(Resource.Id.UbicacionTextView);
			ImageView imagen = view.FindViewById<ImageView>(Resource.Id.perfilImageView);

			Contacto item = this[position];
            nombre.Text = item.Nombre;
            username.Text = item.Username;
            ubicacion.Text = item.Ubicacion;

            int imageId = Resource.Drawable.Icon;
            switch(item.Imagen){
                case "socrates":
                    imageId = Resource.Drawable.socrates;
                    break;
				case "platon":
                    imageId = Resource.Drawable.platon;
					break;
				case "newton":
                    imageId = Resource.Drawable.newton;
					break;
				case "aristoteles":
                    imageId = Resource.Drawable.aristoteles;
					break;
            }

            imagen.SetImageResource(imageId);

			return view;
		}
	}
}
