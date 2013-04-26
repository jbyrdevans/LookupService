using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using ZIPCodeLookup.Models;

namespace ZIPCodeLookup.Processors
{
	public class UpdateProcessor
	{
		public void Update(ZIPEntities context)
		{
			var currentVersion = context.Versions.Where(a => a.Type == "ZIPCodeLookup").FirstOrDefault();
			if (currentVersion == null)
			{
				currentVersion = new Models.Version() { Type = "ZIPCodeLookup", LastUpdateAttempt = DateTime.Now, LastUpdateSuccess = DateTime.Parse("01/01/1900") };
				context.Versions.Add(currentVersion);
			}
			else
			{
				currentVersion.LastUpdateAttempt = DateTime.Now;
			}

			int itemsAdded = 0;
			int itemsModified = 0;
			string remoteFile = "http://www.unitedstateszipcodes.org/zip_code_database.csv";
			string localFile = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + @"\download\zip_code_database.csv";
			
			var webClient = new WebClient();
			webClient.DownloadFile(remoteFile, localFile);

			using (var reader = new StreamReader(localFile))
			{
				while (reader.Peek() >= 0)
				{
					var zipLine = reader.ReadLine();
					if (zipLine != null)
					{
						List<ZIP> updatedZIPs = ParseZipLine(zipLine);
						if (updatedZIPs != null)
						{
							foreach (var updatedZIP in updatedZIPs)
							{
								var existingZIP = context.ZIPs.Find(updatedZIP.ZIPCode);
								if (existingZIP == null)
								{
									itemsAdded++;
									context.ZIPs.Add(updatedZIP);
								}
								else
								{
									itemsModified++;
									context.Entry<ZIP>(existingZIP).CurrentValues.SetValues(updatedZIP);
								}
							}
						}
					}
				}
			}

			currentVersion.LastUpdateItemsAdded = itemsAdded;
			currentVersion.LastUpdateItemsModified = itemsModified;
			currentVersion.LastUpdateSuccess = DateTime.Now;
			context.SaveChanges();
		}

		private List<ZIP> ParseZipLine(string zipLine)
		{
			var result = new List<ZIP>();

			var zipItems = zipLine.Split(',');
			try
			{
				int.Parse(zipItems[0]);
			}
			catch
			{
				return null;
			}

			result.Add(new ZIP()
			{
				ZIPCode = zipItems[0],
				City = zipItems[2],
				State = zipItems[5],
				Latitude = Double.Parse(zipItems[9]),
				Longitude = Double.Parse(zipItems[10]),
				Country = zipItems[12]
			});
			return result;
		}
	}
}