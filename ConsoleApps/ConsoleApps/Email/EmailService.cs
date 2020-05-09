using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Exchange.WebServices.Data;

namespace ConsoleApps.Email
{
    public class EmailService
    {
        public ExchangeService Service { get; set; }
        public EmailService(string username, string password)
        {
            Service = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
            Service.Credentials = new NetworkCredential(username, password);
            Service.AutodiscoverUrl(username, RedirectionCallback);
        }

        public List<Item> GetEmails()
        {
            var results = Service.FindItems(WellKnownFolderName.Inbox, new ItemView(10)).ToList();
            Service.LoadPropertiesForItems(results, PropertySet.FirstClassProperties);
            return results;
        }

        protected bool RedirectionCallback(string url)
        {
            return url.ToLower().StartsWith("https://");
        }
    }
}
