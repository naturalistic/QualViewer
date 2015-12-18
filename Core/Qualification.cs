using System;
using System.Collections.Generic;

namespace Core
{
	public class Qualification
	{
		public string id { get; set; }
		public string name { get; set; }
		public Country country { get; set; }
		public List<Subject> subjects { get; set; }
		public string link { get; set; }
		public IList<DefaultProduct> default_products { get; set; }
	}

	// in same class file for simplicity, could split out for reuse
	public class Country
	{
		public string code { get; set; }
		public string name { get; set; }
		public DateTime created_at { get; set; }
		public DateTime updated_at { get; set; }
		public string link { get; set; }
	}

	public class Subject
	{
		public string id { get; set; }
		public string title { get; set; }
		public string link { get; set; }
		public string colour { get; set; }
	}

	public class Info
	{
		public string meta { get; set; }
	}

	public class Asset
	{
		public string id { get; set; }
		public object copyright { get; set; }
		public string meta { get; set; }
		public int? size { get; set; }
		public string content_type { get; set; }
		public DateTime created_at { get; set; }
		public DateTime updated_at { get; set; }
		public string path { get; set; }
		public string unzipped_base_url { get; set; }
		public List<Info> info { get; set; }
		public string link { get; set; }
	}

	public class Publisher
	{
		public string id { get; set; }
		public string title { get; set; }
		public string link { get; set; }
	}

	public class DefaultProduct
	{
		public string id { get; set; }
		public string title { get; set; }
		public string link { get; set; }
		public string ios_iap_id { get; set; }
		public List<object> store_ids { get; set; }
		public string type { get; set; }
		public List<Asset> assets { get; set; }
		public Publisher publisher { get; set; }
		public string author { get; set; }
	}
}

