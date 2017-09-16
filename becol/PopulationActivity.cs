using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace becol
{
    [Activity(Label = "Navigation Drawer")]
	public class PopulationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.earth_pop);

			this.ActionBar.SetDisplayHomeAsUpEnabled(true);
			this.ActionBar.SetHomeButtonEnabled(true);
			//You can now use and reference the ActionBar
			this.ActionBar.Title = "Hello from Toolbar";
        }

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
            Finish();
            return true;
		}
    }
}
