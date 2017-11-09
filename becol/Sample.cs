using System;
using Android.Content;

namespace becol
{
    public class Sample : Java.Lang.Object
    {
        internal int titleResId;
        internal int descriptionResId;
        internal Intent intent;

        public Sample(int titleResId, int descriptionResId, Intent intent){
            Initialize(titleResId, descriptionResId, intent);
        }

		public Sample(int titleResId, int descriptionResId, Context c, Type t)
		{
			Initialize(titleResId, descriptionResId, new Intent(c, t));
		}

		private void Initialize(int pTitleResId, int pDescriptionResId, Intent pIntent)
		{
			this.intent = pIntents;
			this.titleResId = pTitleResId;
			this.descriptionResId = pDescriptionResId;
		}
    }
}
