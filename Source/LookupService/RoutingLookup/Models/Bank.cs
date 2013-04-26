using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoutingLookup.Models
{
	public class Bank
	{
		[Key]
		public string RoutingNumber { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string ZipPlus4 { get; set; }
		public string Phone { get; set; }
		public string OfficeTypeId { get; set; }
		public string ServicingFrbRoutingNumber { get; set; }
		public string RecordTypeId { get; set; }
		public DateTime DateLastChange { get; set; }
		public string NewRoutingNumber { get; set; }
		public string StateCodeId { get; set; }
		public string DataViewCodeId { get; set; }
	}
}