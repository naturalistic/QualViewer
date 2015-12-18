using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Core;

namespace QualViewer
{
	[Activity (Label = "Subjects", ParentActivity=typeof(MainActivity))]			
	public class SubjectActivity : Activity
	{
		private static string EXTRA_QUALIFICATION_ID = "com.devdaniel.qualviewer.qualification.id";

		private ListView subjectListView;
		private SubjectAdapter subjectAdapter;

		public static Intent newIntent(Context packageContext, string id) {
			var intent = new Intent (packageContext, typeof(SubjectActivity));
			intent.PutExtra (EXTRA_QUALIFICATION_ID, id);
			return intent;
		}

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.SubjectActivity);

			string id = Intent.GetStringExtra (EXTRA_QUALIFICATION_ID);
			var qualification = QualificationManager.GetQualification (id); // safe even if id is null
			if (qualification == null) {
				return;
			}
			subjectListView = FindViewById<ListView> (Resource.Id.subjectListView);

			if (qualification.subjects == null || !qualification.subjects.Any ()) {
				subjectListView.Visibility = ViewStates.Gone;
				var noSubjectsTextView = FindViewById<TextView> (Resource.Id.noSubjectsTextView);
				noSubjectsTextView.Visibility = ViewStates.Visible;
			}
			subjectAdapter = new SubjectAdapter (this, qualification.subjects);
			subjectListView.Adapter = subjectAdapter; 
		}
	}
}