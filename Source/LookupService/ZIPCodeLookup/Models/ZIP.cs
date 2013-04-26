using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZIPCodeLookup.Models
{
	public class ZIP
	{
		[Key]
		[Column(Order = 0)]
		public string ZIPCode { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public DateTime DateLastChange { get; set; }
	}
}
