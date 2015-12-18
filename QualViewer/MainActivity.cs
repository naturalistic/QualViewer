using Android.App;
using Android.Widget;
using Android.OS;
using Core;
using System.Threading.Tasks;

namespace QualViewer
{
	[Activity (Label = "Qualifications", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private static int count = 1;
		private ListView qualListView;
		private QualificationAdapter adapter;
		private bool initialised = false;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.Main);

			qualListView = FindViewById<ListView> (Resource.Id.qualificationListView);

			var swipeRefreshLayout = FindViewById<Android.Support.V4.Widget.SwipeRefreshLayout> (Resource.Id.swipe_container);
			swipeRefreshLayout.Refresh += async (object sender, System.EventArgs e) => {
				await LoadData();
				swipeRefreshLayout.Refreshing = false;
			};

			qualListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				if(adapter != null) {
					var id = adapter.GetQualification(e.Position).id;
					var intent = SubjectActivity.newIntent(BaseContext, id);
					StartActivity(intent);
				}
			};
		}

		protected override void OnResume ()
		{
			base.OnResume ();
			if (!initialised) {
				initialised = true;
				LoadData ();
			}
		}

		private async Task LoadData()  {
			await QualificationManager.UpdateQualifications();
			var qualifications = QualificationManager.GetQualifications ();
			if (qualifications == null) {	// assume null == offline, TODO: add status to determine other causes of error
				var builder = new AlertDialog.Builder (this);
				builder.SetPositiveButton (Android.Resource.String.Ok, (s, e) => {});
				var dialog = builder.Create ();
				dialog.SetTitle ("Offline");
				dialog.SetMessage ("Qualifications are not available when you are offline, please try again later");
				dialog.Show ();
			}
			adapter = new QualificationAdapter (this, QualificationManager.GetQualifications ()); 
			qualListView.Adapter = adapter;
		}
	}
}


