using System;
using System.ComponentModel.DataAnnotations;

namespace ZIPCodeLookup.Models
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