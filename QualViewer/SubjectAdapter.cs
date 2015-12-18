using System;
using Android.Widget;
using System.Collections.Generic;
using Core;
using Android.App;
using Android;
using System.Linq;

namespace QualViewer
{
	public class SubjectAdapter : BaseAdapter
	{
		private Activity activity;
		private List<Subject> subjects;

		public SubjectAdapter (Activity _activity, List<Subject> _subjects)
		{
			this.activity = _activity;

			this.subjects = _subjects;
			if (subjects == null) {
				subjects = new List<Subject> ();
			}
		}

		public override int Count {
			get {
				return subjects.Count;
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

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			var view = convertView ?? activity.LayoutInflater.Inflate (Android.Resource.Layout.SimpleListItem1, parent, false);
			var subjectName = view.FindViewById<TextView> (Android.Resource.Id.Text1);
			subjectName.SetTextColor (Android.Graphics.Color.DarkGray);
			var subject = subjects [position];
			subjectName.Text = subject.title;
			if (!string.IsNullOrEmpty (subject.colour)) {
				var colour = Android.Graphics.Color.ParseColor (subject.colour);
				view.SetBackgroundColor (colour);
			} else {
				view.SetBackgroundColor(Android.Graphics.Color.WhiteSmoke);
			}
			return view;
		}
	}
}

