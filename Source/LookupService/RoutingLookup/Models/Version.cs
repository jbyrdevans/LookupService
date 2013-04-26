using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoutingLookup.Models
{
	public class Version
	{
		[Key]
		public string Type { get; set; } 
		public DateTime LastUpdateSuccess { get; set; }
		public DateTime LastUpdateAttempt { get; set; }
		public int LastUpdateItemsModified { get; set; }
		public int LastUpdateItemsAdded { get; set; }
	}
}