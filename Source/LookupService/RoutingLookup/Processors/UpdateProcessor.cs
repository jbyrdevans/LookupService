using RoutingLookup.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace RoutingLookup.Processors
{
	public class UpdateProcessor
	{
		public void Update(BankEntities context)
		{
			var currentVersion = context.Versions.Where(a => a.Type == "RoutingLookup").FirstOrDefault();
			if (currentVersion == null)
			{
				currentVersion = new Models.Version() { Type = "RoutingLookup", LastUpdateAttempt = DateTime.Now, LastUpdateSuccess = DateTime.Parse("01/01/1900") };
				context.Versions.Add(currentVersion);
			}
			else
			{
				currentVersion.LastUpdateAttempt = DateTime.Now;
			}

			if (DateTime.Now.Date > currentVersion.LastUpdateSuccess.Date)
			{
				//HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("http://www.fededirectory.frb.org/FedACHdir.txt");
				HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("http://www.fededirectory.frb.org/updatesForACH.cfm");
				rq.Method = "POST";
				rq.ContentType = "application/x-www-form-urlencoded";
				byte[] bytedata = Encoding.UTF8.GetBytes("sinceDate=" + currentVersion.LastUpdateSuccess.ToString("MM/dd/yyyy"));
				rq.ContentLength = bytedata.Length;
				using (var requestStream = rq.GetRequestStream())
				{
					requestStream.Write(bytedata, 0, bytedata.Length);
					requestStream.Close();
				}

				using (var rs = (HttpWebResponse)rq.GetResponse())
				{
					using (var stream = rs.GetResponseStream())
					{
						using (var readStream = new StreamReader(stream, System.Text.Encoding.GetEncoding("utf-8")))
						{

							var responseBuilder = new StringBuilder();
							var bufferSize = 256;
							Char[] read = new Char[bufferSize];
							int count = readStream.Read(read, 0, bufferSize);

							while (count > 0)
							{
								String str = new String(read, 0, count);
								responseBuilder.Append(str);
								count = readStream.Read(read, 0, bufferSize);
							}
							var response = responseBuilder.ToString();
							var bankItems = response.Split(new string[] { "\r\n" }, StringSplitOptions.None);

							var itemsAdded = 0;
							var itemsModified = 0;
							foreach (var bankItem in bankItems)
							{
								if (bankItem.Length >= 9)
								{
									var updatedBank = context.ParseBank(bankItem);
									var existingBank = context.Banks.Find(updatedBank.RoutingNumber);
									if (existingBank == null)
									{
										itemsAdded++;
										context.Banks.Add(updatedBank);
									}
									else
									{
										itemsModified++;
										context.Entry<Bank>(existingBank).CurrentValues.SetValues(updatedBank);
									}
								}
							}
							currentVersion.LastUpdateItemsAdded = itemsAdded;
							currentVersion.LastUpdateItemsModified = itemsModified;
							currentVersion.LastUpdateSuccess = DateTime.Now;
							context.SaveChanges();

							rs.Close();
							readStream.Close();
						}
					}
				}
			}			
		}
	}
}