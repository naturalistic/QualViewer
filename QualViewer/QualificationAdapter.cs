using System;
using Android.Widget;
using System.Collections.Generic;
using Core;
using Android.App;
using Android;
using System.Linq;

namespace QualViewer
{
	public class QualificationAdapter : BaseAdapter
	{
		private Activity activity;
		private List<Qualification> qualifications;

		public QualificationAdapter (Activity _activity, List<Qualification> _qualifications)
		{
			this.activity = _activity;

			this.qualifications = _qualifications;
			if (qualifications == null) {
				qualifications = new List<Qualification> ();
			}
		}

		public override int Count {
			get {
				return qualifications.Count;
			}
		}

		// not used
		public override long GetItemId (int position)
		{
			return position;
		}

		// not used
		public override Java.Lang.Object GetItem (int position)
		{
			return null; 
		}

		public Qualification GetQualification(int position) {
			return qualifications [position];
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			var view = convertView ?? activity.LayoutInflater.Inflate (Android.Resource.Layout.SimpleListItem2, parent, false);
			var qualName = view.FindViewById<TextView> (Android.Resource.Id.Text1);
			var qualDetail = view.FindViewById<TextView> (Android.Resource.Id.Text2);
			qualName.Text = qualifications [position].name;
			var country = qualifications [position].country;
			qualDetail.Text = country==null ? "Unknown Country" : country.name;
			return view;
		}
	}
}

