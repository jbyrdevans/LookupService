using System;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;
using System.Globalization;

namespace ZIPCodeLookup.Models
{
	public partial class ZIPEntities : DbContext
	{
		public ZIPEntities()
			: base("name=ZIPEntities")
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

		public ZIP ParseZIP(string s)
		{
			return new ZIP() 
				{
					//TODO
				};
		}

		public DbSet<ZIP> ZIPs { get; set; }
		public DbSet<Version> Versions { get; set; }
	}
}
