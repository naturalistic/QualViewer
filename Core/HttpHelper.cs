using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Diagnostics;

namespace Core
{
	public static class HttpHelper
	{
		public static async Task<Tuple<T,HttpHelperStatus>> Get<T> (string url) 
		{
			try {
				using (HttpClient client = new HttpClient()) 
				{
					var response = await client.GetAsync (url);
					var responseString = await response.Content.ReadAsStringAsync(); 
					if (response.IsSuccessStatusCode) {
						var receiveObject = JsonConvert.DeserializeObject<T> (responseString);
						return new Tuple<T,HttpHelperStatus> (receiveObject, HttpHelperStatus.Ok);
					}
					return new Tuple<T, HttpHelperStatus> (default(T), HttpHelperStatus.Error);	
				}
			} catch (Exception e) 
			{
				Debug.WriteLine (String.Format ("[HttpHelper.Get] Request URL: {0}, Exception: {1}", url, e.Message));
				return Tuple.Create(default(T), HttpHelperStatus.Error);
			} 
		}
	}

	public enum HttpHelperStatus
	{
		Error,
		Ok,
	}
}

