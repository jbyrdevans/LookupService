using System;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;
using System.Globalization;

namespace RoutingLookup.Models
{
	public partial class BankEntities : DbContext
	{
		public BankEntities()
			: base("name=BankEntities")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

		//Use with care. Bypasses model validation temporarily.
		public void SaveChangesWithoutValidation()
		{
			bool oldState = Configuration.ValidateOnSaveEnabled;
			Configuration.ValidateOnSaveEnabled = false;
			SaveChanges();
			Configuration.ValidateOnSaveEnabled = oldState;
		}

		public Bank ParseBank(string s)
		{
			return new Bank() 
				{
					RoutingNumber = s.Substring(0, 9).Trim(),
					OfficeTypeId = s.Substring(9, 1).Trim(),
					ServicingFrbRoutingNumber = s.Substring(10, 9).Trim(),
					RecordTypeId = s.Substring(19, 1).Trim(),
					DateLastChange = DateTime.ParseExact(s.Substring(20, 6), "MMddyy", CultureInfo.InvariantCulture),
					NewRoutingNumber = s.Substring(26, 9).Trim(),
					Name = s.Substring(35, 36).Trim(),
					Address = s.Substring(71, 36).Trim(),
					City = s.Substring(107, 20).Trim(),
					State = s.Substring(127, 2).Trim(),
					Zip = s.Substring(129, 5).Trim(),
					ZipPlus4 = s.Substring(134, 4).Trim(),
					Phone = s.Substring(138, 10).Trim(),
					StateCodeId = s.Substring(148, 1).Trim(),
					DataViewCodeId = s.Substring(149, 1).Trim()
				};
		}

		public DbSet<Bank> Banks { get; set; }
		public DbSet<Version> Versions { get; set; }
	}
}
