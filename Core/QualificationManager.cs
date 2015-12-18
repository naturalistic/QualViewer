using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
	public class QualificationManager
	{
		private const string URL = "https://api.gojimo.net/api/v4/qualifications";
		private static QualificationManager qualManager;

		private List<Qualification> qualifications;
		private QualificationManager() {}

		private static void Init() {
			if (qualManager == null) {
				qualManager = new QualificationManager ();
			}
		}	

		public static List<Qualification> GetQualifications() {
			Init ();
			return qualManager.qualifications;
		}

		// For persistance could add sqlite db integration to store / retreive 
		public static async Task UpdateQualifications() {
			Init ();
			var qualificationResult = await HttpHelper.Get<List<Qualification>>(URL);
			qualManager.qualifications = qualificationResult.Item1;
		}

		public static Qualification GetQualification(string id) {
			Init ();
			foreach (var qualification in qualManager.qualifications) {
				if (qualification.id == id) {
					return qualification;
				}
			}
			return null;
		}
	}
}