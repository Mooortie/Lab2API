using Newtonsoft.Json;
using System.Net;


namespace Lab2API.Models
{
	public class addanime
	{
		public int id { get; set; }

		public string name { get; set; }

		
		public string episodes { get; set; }

		
		public string completed { get; set; }

		
		public string raiting { get; set; }
	}
}
