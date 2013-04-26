using System;
using System.Web.Http;
using ZIPCodeLookup.Models;
using ZIPCodeLookup.Processors;

namespace ZIPCodeLookup.Controllers
{
	public class UpdateController : ApiController
	{
		// GET update?password=secret
		public bool Get(string password)
		{
			if (password == "DCGeverm0re")
			{
				var context = new ZIPEntities();
				var processor = new UpdateProcessor();
				try
				{
					processor.Update(context);
				}
				catch (Exception ex)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}
}